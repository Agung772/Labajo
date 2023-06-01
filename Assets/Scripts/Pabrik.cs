using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pabrik : MonoBehaviour
{
    public bool active;
    public GameObject particleAsep;
    public GameObject particleLimbah;

    public void Operation(bool value)
    {
        if (value)
        {
            particleAsep.SetActive(true);
            particleLimbah.SetActive(true);
        }
        else
        {
            particleAsep.SetActive(false);
            particleLimbah.SetActive(false);
        }
    }
}
