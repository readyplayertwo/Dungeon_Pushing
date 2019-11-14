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

    public VicinityManager VM;


    List<int> Order = new List<int>();

    public bool IsOnePushed;
    public bool IsTwoPushed;
    public bool IsThreePushed;
    public bool IsFourPushed;

    List<int> UserOrder = new List<int>();

    // Use this for initialization
    void Start () {
        Order.Add(4);
        Order.Add(2);
        Order.Add(3);
        Order.Add(1);



    }

    // Update is called once per frame
    void Update () {

        if (VM.IsOnePushed == true)
        {
            UserOrder.Add(1);
        }


        if (VM.IsTwoPushed == true)
        {
            UserOrder.Add(2);
        }


        if (VM.IsThreePushed == true)
        {
            UserOrder.Add(3);
        }

        if (VM.IsFourPushed == true)
        {
            UserOrder.Add(4);
        }


    }



}
