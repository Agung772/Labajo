using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool ground;
    public bool cd;

    private void OnTriggerEnter(Collider other)
    {
        //ground = true;

    }

    private void OnTriggerStay(Collider other)
    {
        if (!ground && !cd)
        {
            PlayerController.instance.GroundEnter();
            ground = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ground = false;
    }

    public void Cd()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            cd = true;
            yield return new WaitForSeconds(0.5f);
            cd = false;
        }

    }
}
