﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{


    public AK.Wwise.Event inputsound;
    bool playerismoving;
    public float walkingspeed;


    void Update()
    {
        if (Input.GetAxis("Vertical") >= 0.01f || Input.GetAxis("Horizontal") >= 0.01f || Input.GetAxis("Vertical") <= -0.01f || Input.GetAxis("Horizontal") <= -0.01f)
        {
            //Debug.Log ("Player is moving");
            playerismoving = true;
        }
        else if (Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0)
        {
            //Debug.Log ("Player is not moving");
            playerismoving = false;
        }
    }


    void CallFootsteps()
    {
        if (playerismoving == true)
        {
            //Debug.Log ("Player is moving");
            inputsound.Post(this.gameObject);
        }
    }


    void Start()
    {
        InvokeRepeating("CallFootsteps", 0, walkingspeed);
    }


   // void OnDisable()
   // {
   //     playerismoving = false;
   // }
}
