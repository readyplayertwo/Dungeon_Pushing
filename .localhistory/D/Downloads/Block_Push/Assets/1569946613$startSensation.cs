using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSensation : MonoBehaviour
{

    public startemitter CE;
    public float intensity;
    public GameObject cube;
    public GameObject steamvr;

    public Vector3 start = new Vector3(-12.326f,0.51f, 9.475f);
    public Vector3 end = new Vector3(-12.326f, 0.51f, 10.069f);

    // Use this for initialization
    void Start()
    {
        intensity = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {

        // Debug.Log("ButtonVicinityManager OnTriggerExit");
        if (other.name == "HandTrackedBlock")
        {
            Debug.Log("Collided");
            // Use a proxy object, attached to the hand, to actuate the button.
            CE._emitter.start();
        }


    }

    public void OnTriggerStay(Collider other)
    {

        // Debug.Log("ButtonVicinityManager OnTriggerExit");
        if (other.name == "HandTrackedBlock")
        {
            Debug.Log("Collided");
            // Use a proxy object, attached to the hand, to actuate the button.
            cube.transform.position = Vector3.MoveTowards(start, end, 5f);

        }
    }
}
