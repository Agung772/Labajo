using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUI : MonoBehaviour
{
    [SerializeField]
    GameObject cameraRenderMap;


    public void MiniMap(bool condition)
    {
        if (!condition)
        {
            cameraRenderMap.SetActive(false);
        }
        else if (condition)
        {
            cameraRenderMap.SetActive(true);
        }
    }
}
