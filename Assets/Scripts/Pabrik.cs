using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pabrik : MonoBehaviour
{
    public bool active;
    public GameObject particle;

    public void Operation(bool value)
    {
        if (value)
        {
            particle.SetActive(true);
        }
        else
        {
            particle.SetActive(false);
        }
    }
}
