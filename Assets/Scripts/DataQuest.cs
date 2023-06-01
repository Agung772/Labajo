using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataQuest : MonoBehaviour
{
    public string[] titleQuest;
    public float[] questIndex;

    string _questIndex = "_questIndex";

    public void LoadData()
    {
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
        for (int i = 0; i < questIndex.Length; i++)
        {
            if (i != 0)
            {
                PlayerPrefs.DeleteKey(_questIndex + i);
            }
        }
    }
}
