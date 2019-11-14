using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Manager : MonoBehaviour {

    public GameObject Block1;
    public GameObject Block2;
    public GameObject Block3;
    public GameObject Block4;

    public Light FirstAnswer;
    public Light SecondAnswer;
    public Light ThirdAnswer;
    public Light FourthAnswer;


    public int[] Order;
    public int[] UserOrder;

    public bool IsOnePushed;
    public bool IsTwoPushed;
    public bool IsThreePushed;
    public bool IsFourPushed;


    // Use this for initialization
    void Start () {
        Order = new int[4];
        Order[0] = 4;
        Order[1] = 2;
        Order[2] = 1;
        Order[3] = 3;
    }
	
	// Update is called once per frame
	void Update () {
	}



}
