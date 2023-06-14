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

    public GameObject notifPrefab;
    [SerializeField] Transform spawn;

    public Font font;
    public bool bla;
    private void OnValidate()
    {
        Text[] text = FindObjectsOfType<Text>();
        for (int i = 0; i < text.Length; i++)
        {
            text[i].font = font;
        }

        Button[] sfxButtons = FindObjectsOfType<Button>();
        for (int i = 0; i < sfxButtons.Length; i++)
        {

            if (sfxButtons[i].gameObject.GetComponent<SetButtonAudio>() == null)
            {
                sfxButtons[i].gameObject.AddComponent<SetButtonAudio>();
                print(i + 1);
            }
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            //GameSave.instance.DeleteData();
            PlayerPrefs.DeleteAll();
        }
        if (Input.GetKeyDown(KeyCode.End))
        {
            Debug();
        }
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
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(1);
                transisi.gameObject.SetActive(false);
            }
        }        
        else if (condition == "StartExit")
        {
            transisi.SetTrigger("StartExit");
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(2);
                transisi.gameObject.SetActive(false);
            }
        }
    }

    public void SetGrafik(int value)
    {
        QualitySettings.SetQualityLevel(value);
    }

    public void SpawnNotif(string value)
    {
        if (spawn.childCount != 0)
        {
            Destroy(spawn.GetChild(0).gameObject);
        }
        GameObject temp = Instantiate(notifPrefab, spawn);
        temp.GetComponent<Notif>().notifText.text = value;
    }

    public GameObject debugUI;
    bool debug;
    public void Debug()
    {
        if (!debug)
        {
            debug = true;
            debugUI.SetActive(true);
            GameSave.instance.DebugData(debugUI.transform.GetChild(1).GetComponent<Text>(), debugUI.transform);
        }
        else
        {
            debug = false;
            debugUI.SetActive(false);
        }
    }

}

