using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startemitter : MonoBehaviour {
    //Time Point Streaming
    public TimePointStreamingEmitter _emitter;

    public static uint _current = 0;
    public static uint _timepoint_count = 0;
    public float desired_frequency = 200.0f;
    public uint sample_rate;
    //ViveTracker
    public GameObject ViveHand;

    public VicinityManager VM;


    public static Ultrahaptics.Vector3[] _positions;
    public static float[] _intensities;

    public void Start()
    {

    }

    void Awake()
    {

    }

    // Converts a Leap Vector directly to a UH Vector3
    Ultrahaptics.Vector3 LeapToUHVector(Leap.Vector vec)
    {
        return new Ultrahaptics.Vector3(vec.x, vec.y, vec.z);
    }





    // Update on every frame
    public void Update()
    {

        // The Leap Motion can see a hand, so get its palm position
        // Convert to our vector class, and then convert to our coordinate space

        //Vive Tracker Position
        Ultrahaptics.Vector3 uhPalmPosition = new Ultrahaptics.Vector3(ViveHand.transform.position.x, ViveHand.transform.position.y, ViveHand.transform.position.z);

        // Leap Motion hand position


        // From here, we can establish how many timepoints there are in a single "iteration" of the cosine wave
        for (int i = 0; i < _timepoint_count; i++)
        {
            float intensity = VM.intensity * (1.0f - (float)Math.Cos(2.0f * Math.PI * i / _timepoint_count));
            // Set a constant position of 20cm above the array
            _positions[i] = new Ultrahaptics.Vector3(0.0f, 0.0f, 0.3f);
            _intensities[i] = (intensity);

        }

        _emitter.setEmissionCallback(callback, null);



    }

    static void callback(TimePointStreamingEmitter emitter, OutputInterval interval, TimePoint deadline, object user_obj)
    {
        // For each time point in this interval...
        foreach (var tpoint in interval)
        {
            // For each control point available at this time point...
            for (int i = 0; i < tpoint.count(); ++i)
            {
                // Set the relevant data for this control point
                var point = tpoint.persistentControlPoint(i);
                point.setPosition(_positions[_current]);
                point.setIntensity(_intensities[_current]);
                point.enable();
            }
            // Increment the counter so that we get the next "step" next time
            _current = (_current + 1) % _timepoint_count;
        }
    }

    void OnApplicationQuit()
    {
        _emitter.stop();
    }

    void OnEnable()
    {
        // Create a timepoint streaming emitter
        // Note that this automatically attempts to connect to the device, if present
        _emitter = new TimePointStreamingEmitter();




        //Remove Cap
        _emitter.setExtendedOption("solverCappingConstant", "3000");

        // Inform the SDK how many control points you intend to use
        // This also calculates the resulting sample rate in Hz, which is returned to the user
        sample_rate = _emitter.setMaximumControlPointCount(1);
        _timepoint_count = (uint)(sample_rate / desired_frequency);

        //Initalize Positions and Intensities
        _positions = new Ultrahaptics.Vector3[_timepoint_count];
        _intensities = new float[_timepoint_count];

    }
}
