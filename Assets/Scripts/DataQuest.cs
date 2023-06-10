using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataQuest : MonoBehaviour
{
    public float kompyang;
    public float kolo;

    public string[] titleQuest;
    public float[] questIndex;

    [HideInInspector]
    public string 
        _questIndex = "_questIndex",
        _kompyang = "_kompyang",
        _kolo = "_kolo";

    public void LoadData()
    {
        kompyang = PlayerPrefs.GetFloat(_kompyang);
        kolo = PlayerPrefs.GetFloat(_kolo);

        questIndex = new float[titleQuest.Length];
        for (int i = 0; i < questIndex.Length; i++)
        {
            questIndex[i] = PlayerPrefs.GetFloat(_questIndex + i);
        }
    }

    public void SaveData(int index, int value)
    {
        PlayerPrefs.SetFloat(_questIndex + index, value);
        questIndex[index] = value;
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteKey(_kompyang);
        PlayerPrefs.DeleteKey(_kolo);

        for (int i = 0; i < questIndex.Length; i++)
        {
            PlayerPrefs.DeleteKey(_questIndex + i);
        }
    }
}
