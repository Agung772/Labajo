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

