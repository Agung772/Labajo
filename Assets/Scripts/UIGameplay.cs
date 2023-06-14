using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameplay : MonoBehaviour
{
    public static UIGameplay instance;

    public
    GameObject bookUI;

    public Transform spawnDialogBox;
    public Transform spawnScreenStory;

    public GameSetting gameSetting;

    public NotifScreen notifScreen;
    private void Awake()
    {
        instance = this;

        gameSetting.LoadGameSetting();
    }

    bool bookBool;
    public void BookUI()
    {
        if (!bookBool)
        {
            bookBool = true;
            bookUI.SetActive(true);
            bookUI.GetComponent<BookUI>().StartBookUI();
        }
        else
        {
            bookBool = false;
            bookUI.SetActive(false);
            bookUI.GetComponent<BookUI>().ExitBookUI();

        }
    }

    public void MapUI()
    {
        if (!bookBool)
        {
            bookBool = true;
            bookUI.SetActive(true);
            bookUI.GetComponent<BookUI>().StartBookUI();
            bookUI.GetComponent<BookUI>().MapUI();
        }
        else if (bookBool && !bookUI.GetComponent<BookUI>().mapUISC.gameObject.activeInHierarchy)
        {
            bookUI.GetComponent<BookUI>().MapUI();
        }
        else if (bookBool && bookUI.GetComponent<BookUI>().mapUISC.gameObject.activeInHierarchy)
        {
            bookBool = false;
            bookUI.SetActive(false);
            bookUI.GetComponent<BookUI>().ExitBookUI();
        }
    }

    public void NotifUI(bool active, string value)
    {
        if (active)
        {
            notifScreen.gameObject.SetActive(true);
            notifScreen.notif.text = value;
        }
        else
        {
            notifScreen.gameObject.SetActive(false);
            notifScreen.notif.text = null;
        }
    }
}
