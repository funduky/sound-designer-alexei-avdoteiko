using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jump_sound : MonoBehaviour
    
{
    public AK.Wwise.Event Jump;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump.Post(gameObject);
        }

    }

}
