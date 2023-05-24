using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSampah : MonoBehaviour
{
    public TextMeshPro text;

    private void Start()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        transform.eulerAngles = GameplayManager.instance.kamera.transform.eulerAngles;
    }
}
