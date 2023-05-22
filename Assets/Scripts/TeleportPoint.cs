using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : MonoBehaviour
{
    public string namaTempat;
    private void OnMouseDown()
    {
        PlayerController.instance.SetPosition(transform.GetChild(0).position);
    }
}
