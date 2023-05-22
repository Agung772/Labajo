using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookUI : MonoBehaviour
{
    public static BookUI instance;

    [SerializeField]
    GameObject coverUI;

    [Space]

    [SerializeField]
    GameObject itemUI;

    [Space]

    [SerializeField]
    GameObject questUI;

    [Space]

    [SerializeField]
    GameObject mapUI;

    [Space]

    [SerializeField]
    GameObject settingUI;

    [Space]

    [SerializeField]
    RectTransform itemButton;
    [SerializeField]
    RectTransform questButton;
    [SerializeField]
    RectTransform mapButton;
    [SerializeField]
    RectTransform settingButton;

    [Space]

    public ItemUI itemUISC;
    public MapUI mapUISC;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ClickButton("");
    }
    
    public void StartBookUI()
    {
        FalseUI();
        coverUI.SetActive(true);
        GameplayManager.instance.CursorVisible(true);
        PlayerController.instance.operation = false;
        ClickButton("");
    }
    public void ExitBookUI()
    {
        FalseUI();
        GameplayManager.instance.CursorVisible(false);
        PlayerController.instance.operation = true;
    }


    public void MakananUI()
    {
        FalseUI();

        itemUI.SetActive(true);
        itemUISC.MakananUI();
        ClickButton("itemButton");
    }

    public void QuestUI()
    {
        FalseUI();

        questUI.SetActive(true);
        ClickButton("questButton");
    }
    public void MapUI()
    {
        if (!mapUI.activeInHierarchy)
        {
            FalseUI();

            mapUI.SetActive(true);
            mapUISC.MiniMap(true);
            ClickButton("mapButton");
        }

    }
    public void SettingUI()
    {
        FalseUI();

        settingUI.SetActive(true);
        ClickButton("settingButton");
    }
    public void FalseUI()
    {
        coverUI.SetActive(false);

        itemUI.SetActive(false);

        questUI.SetActive(false);

        mapUI.SetActive(false);
        mapUISC.MiniMap(false);

        settingUI.SetActive(false);
    }

    float posXButton, widthButton;
    bool saveButton;
    public void ClickButton(string namaButton)
    {
        if (!saveButton)
        {
            saveButton = true;
            posXButton = itemButton.anchoredPosition.x;
            widthButton = itemButton.sizeDelta.x;
        }


        itemButton.anchoredPosition = new Vector2(posXButton, itemButton.anchoredPosition.y);
        questButton.anchoredPosition = new Vector2(posXButton, questButton.anchoredPosition.y);
        mapButton.anchoredPosition = new Vector2(posXButton, mapButton.anchoredPosition.y);
        settingButton.anchoredPosition = new Vector2(posXButton, settingButton.anchoredPosition.y);

        itemButton.sizeDelta = new Vector2(widthButton, itemButton.sizeDelta.y);
        questButton.sizeDelta = new Vector2(widthButton, questButton.sizeDelta.y);
        mapButton.sizeDelta = new Vector2(widthButton, mapButton.sizeDelta.y);
        settingButton.sizeDelta = new Vector2(widthButton, settingButton.sizeDelta.y);

        if (namaButton == "itemButton")
        {
            itemButton.anchoredPosition = new Vector2(posXButton + 20, itemButton.anchoredPosition.y);
            itemButton.sizeDelta = new Vector2(widthButton + 40, itemButton.sizeDelta.y);
        }
        else if (namaButton == "questButton")
        {
            questButton.anchoredPosition = new Vector2(posXButton + 20, questButton.anchoredPosition.y);
            questButton.sizeDelta = new Vector2(widthButton + 40, questButton.sizeDelta.y);
        }
        else if (namaButton == "mapButton")
        {
            mapButton.anchoredPosition = new Vector2(posXButton + 20, mapButton.anchoredPosition.y);
            mapButton.sizeDelta = new Vector2(widthButton + 40, mapButton.sizeDelta.y);
        }
        else if (namaButton == "settingButton")
        {
            settingButton.anchoredPosition = new Vector2(posXButton + 20, settingButton.anchoredPosition.y);
            settingButton.sizeDelta = new Vector2(widthButton + 40, settingButton.sizeDelta.y);
        }
        else
        {
            //null
        }
    }
}
