using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    Animator transisi;

    public Font font;
    public bool bla;
    private void OnValidate()
    {
        Text[] text = FindObjectsOfType<Text>();
        for (int i = 0; i < text.Length; i++)
        {
            text[i].font = font;
        }
    }
    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }
    private void Start()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(0.1f);

        }

        print(Display.main.renderingHeight + " x " + Display.main.renderingWidth);
    }


    public void Transisi(string condition)
    {
        transisi.gameObject.SetActive(true);
        if (condition == "Start")
        {
            transisi.SetTrigger("Start");
        }
        else if (condition == "Exit")
        {
            transisi.SetTrigger("Exit");
        }        
        else if (condition == "StartExit")
        {
            transisi.SetTrigger("StartExit");
        }
    }

    public void SetGrafik(int value)
    {
        QualitySettings.SetQualityLevel(value);
    }

}

