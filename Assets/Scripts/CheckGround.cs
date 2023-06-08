using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool ground;

    private void OnTriggerEnter(Collider other)
    {
        ground = true;
        PlayerController.instance.GroundEnter();
    }

    private void OnTriggerExit(Collider other)
    {
        ground = false;
    }
}
