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
    private void Awake()
    {
        Application.targetFrameRate = 60;
        instance = this;
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

    private void Update()
    {

    }

    public void Transisi(string condition)
    {
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

