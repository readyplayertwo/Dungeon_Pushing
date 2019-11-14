using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSensation : MonoBehaviour {

    public CustomEmitter CE;
    public float intensity;
    

    // Use this for initialization
    void Start () {
        intensity = 0.5f;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        
        // Debug.Log("ButtonVicinityManager OnTriggerExit");
        if (other.name == "HandTrackedBlock")
        {
            // Use a proxy object, attached to the hand, to actuate the button.
            CE.Start();

        }
    }
}
