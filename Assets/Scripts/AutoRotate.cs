using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    new Transform camera;
    new Transform light;

    public Transform render, shadow;
    private void Awake()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        light = GameObject.FindGameObjectWithTag("Light").transform;

        shadow.eulerAngles = new Vector3(0, light.eulerAngles.y, 0);


        //float randomScale = Random.Range(1, 3);
        //render.localScale = new Vector3(randomScale, randomScale, 0);
    }

    private void Update()
    {
        render.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);

    }
}
