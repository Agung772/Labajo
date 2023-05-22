using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameplay : MonoBehaviour
{
    public static UIGameplay instance;

    [SerializeField]
    GameObject bookUI;
    private void Awake()
    {
        instance = this;
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
}
