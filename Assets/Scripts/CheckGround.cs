using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool ground;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground")) ground = true;

        ground = true;
        PlayerController.instance.animator.SetBool("Unjump", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground")) ground = false;

        ground = false;
        PlayerController.instance.animator.SetTrigger("Jump");
        PlayerController.instance.animator.SetBool("Unjump", false);
    }
}
