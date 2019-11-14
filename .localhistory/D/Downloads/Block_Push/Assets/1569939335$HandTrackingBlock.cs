﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrackingBlock : MonoBehaviour
{
    public GameObject ViveHand;

    private bool hasValueForName = false;

    public Leap.Controller controller;
    public Leap.Frame frame;
    public Leap.Vector position


    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        controller = new Leap.Controller();
        Leap.Frame frame = controller.Frame();
        List<Leap.Hand> hands = frame.Hands;

        Leap.Hand fristHand = hands[0];
        position = hands[0].PalmPosition;

        Vector3 pos = Leap.Unity.UnityVectorExtension.ToVector3(position);


        // Attach to the palm
        // Vive Tracker
        //Vector3 pos = new Vector3(ViveHand.transform.position.x - 0.2f, ViveHand.transform.position.y + 1.0f, ViveHand.transform.position.z - 0.5f);

        //Vector3 pos = new Vector3(ViveHand.transform.position.x, ViveHand.transform.position.y, ViveHand.transform.position.z);

        transform.position = pos;

        //if (!pos.Equals(UnityEngine.Vector3.zero))
        //{
        //    // If non-zero, orientate to the hand surface
        //    Vector3 dir = new Vector3(hand.Direction.x, hand.Direction.y, 0.0f);
        //    Vector3 norm =new Vector3(hand.PalmNormal.x, hand.PalmNormal.y, 0.0f);

        //    transform.rotation = Quaternion.LookRotation(dir, norm);
        //}

    }
}
