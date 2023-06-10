using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool ground;

    private void OnTriggerEnter(Collider other)
    {
        //ground = true;

    }

    private void OnTriggerStay(Collider other)
    {
        if (!ground)
        {
            PlayerController.instance.GroundEnter();
            ground = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ground = false;
    }
}
