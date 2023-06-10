using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DetectMisi : MonoBehaviour
{
    public UnityEvent unityEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.InteraksiSfx();

            Destroy(gameObject);
            unityEvent.Invoke();



        }
    }
}
