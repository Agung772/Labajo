using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestComplate : MonoBehaviour
{
    public Pabrik pabrik;
    public WaterMat waterMat;
    public GameObject sampah;

    private void Start()
    {
        IsComplate = false;
    }
    bool isComplate;
    public bool IsComplate
    {
        get { return isComplate; }
        set
        {
            isComplate = value;
            Condition();
        }
    }
    void Condition()
    {
        if (IsComplate == true)
        {
            pabrik.Operation(false);
            waterMat.meshRenderer.material = waterMat.bersih;
            sampah.SetActive(false);
        }
        else
        {
            pabrik.Operation(true);
            waterMat.meshRenderer.material = waterMat.limbah;
            sampah.SetActive(true);
        }
    }
}
