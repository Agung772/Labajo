using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    [SerializeField]
    Transform minimapCam;
    float positionZ = 500;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float verticalMouse = Input.GetAxis("Mouse Y");
            positionZ -= verticalMouse * 15;

        }


        positionZ += Input.GetAxis("Mouse ScrollWheel") * 100;
        minimapCam.localPosition = new Vector3(0, 300, positionZ);
        positionZ = Mathf.Clamp(positionZ, -80 + 10, 1565 - 10);


    }
}
