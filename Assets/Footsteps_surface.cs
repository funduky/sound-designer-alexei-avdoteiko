using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps_surface : MonoBehaviour
{


    public AK.Wwise.Event inputsound;
    bool playerismoving;
    public float walkingspeed;
    public LayerMask lm;


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


    void CallFootsteps ()
    {
        if (playerismoving == true)
        {
            //Debug.Log ("Player is moving");
            if (Physics.Raycast(gameObject.transform.position, Vector3.down, out RaycastHit hit, 1f, lm))
            {
                AkSoundEngine.SetSwitch("Surface", hit.collider.tag, gameObject);

            }
            inputsound.Post(gameObject);
            Debug.Log(hit.collider.tag);
        }
    }


    void Start()
    {
        InvokeRepeating("CallFootsteps", 0, walkingspeed);
    }


}
