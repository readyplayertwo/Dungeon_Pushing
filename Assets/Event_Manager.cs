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

    public GameObject Wall;

    public VicinityManager VM1;
    public VicinityManager VM2;
    public VicinityManager VM3;
    public VicinityManager VM4;



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

        if (VM1.IsOnePushed == true )
        {
            UserOrder.Add(1);
        }


        if (VM2.IsTwoPushed == true)
        {
            UserOrder.Add(2);
        }


        if (VM3.IsThreePushed == true)
        {
            UserOrder.Add(3);
        }

        if (VM4.IsFourPushed == true)
        {
            UserOrder.Add(4);
        }

        if(UserOrder.Count == 4 && UserOrder != Order)
        {
            FirstAnswer.color = Color.red;
            SecondAnswer.color = Color.red;
            ThirdAnswer.color = Color.red;
            FourthAnswer.color = Color.red;

            UserOrder = null;

            VM1.IsOnePushed = false;
            VM2.IsTwoPushed = false;
            VM3.IsThreePushed = false;
            VM4.IsFourPushed = false;

        }

        if(UserOrder.Count != 4)
        {
            FirstAnswer.color = Color.yellow;
            SecondAnswer.color = Color.yellow;
            ThirdAnswer.color = Color.yellow;
            FourthAnswer.color = Color.yellow;
        }

        if (UserOrder == Order)
        {
            FirstAnswer.color = Color.green;
            SecondAnswer.color = Color.green;
            ThirdAnswer.color = Color.green;
            FourthAnswer.color = Color.green;


            Wall.SetActive(false);

        }

    }



}
