using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickCone : MonoBehaviour
{
    public bool refresh;
    public LineRenderer lineRenderer;
    //public MeshCollider meshCollider;

    private void OnValidate()
    {
        int childCount = transform.childCount;
        lineRenderer.positionCount = childCount;

        for (int i = 0; i < childCount; i++)
        {
            lineRenderer.SetPosition(i, transform.GetChild(i).position);
        }

    }
}
