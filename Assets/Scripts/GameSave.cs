using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    public static GameSave instance;

    //Value save
    public float isSave;

    public Vector3 posisiPlayer;
    public float koin;
    public float questComplate;


    //Setting
    [Space]
    public float sizeScreen;
    public float sensitifMouse;
    public float kecerahanMatahari;
    public float fieldOfView;
    public float bayangan;

    public DataQuest dataQuest;

    //Anti typo -------------------------------------
    [HideInInspector]
    public string _DefaultGame = "DefaultGame";
    public string _DefaultSetting = "DefaultSetting";

    //Player
    [HideInInspector]
    public string
        _IsSave = "_IsSave",

        _PosisiPlayerX = "PosisiPlayerX",
        _PosisiPlayerY = "PosisiPlayerY",
        _PosisiPlayerZ = "PosisiPlayerZ",
        
        _Koin = "Koin",
        _QuestComplate = "QuestComplate";

    //Setting
    [HideInInspector]
    public string
        _SizeScreen = "_SizeScreen",
        _SensitifMouse = "SensitifMouse",
        _KecerahanMatahari = "KecerahanMatahari",
        _FieldOfView = "FieldOfView",
        _Bayangan = "Bayangan";

    private void Awake()
    {
        if (instance == null) instance = this;

        DefaultData();
        LoadData();
    }
    private void Start()
    {

    }

    public void DebugData(UnityEngine.UI.Text template, Transform parent)
    {
        UnityEngine.UI.Text temp = Instantiate(template, parent);
        temp.text = _IsSave + isSave;
        temp.rectTransform.localPosition = new Vector3(0, temp.rectTransform.localPosition.y + 100, 0);

        UnityEngine.UI.Text temp1 = Instantiate(template, parent);
        temp1.text = _DefaultGame + PlayerPrefs.GetFloat(_DefaultSetting);
        temp1.rectTransform.localPosition = new Vector3(0, temp1.rectTransform.localPosition.y + 200, 0);
    }

    void DefaultData()
    {
        if (PlayerPrefs.GetFloat(_DefaultSetting) == 0)
        {
            PlayerPrefs.SetFloat(_DefaultSetting, 1);

            SaveSetting(_SizeScreen, 0);
            SaveSetting(_SensitifMouse, 2);
            SaveSetting(_KecerahanMatahari, 2);
            SaveSetting(_FieldOfView, 60);
            SaveSetting(_Bayangan, 1);

            SaveSizeScreen(11);
        }

        if (PlayerPrefs.GetFloat(_DefaultGame) == 0)
        {
            PlayerPrefs.SetFloat(_DefaultGame, 1);
            SavePosisiPlayer(90.23f, 5.89f, -203.34f);
        }

    }

    public void LoadData()
    {
        isSave = PlayerPrefs.GetFloat(_IsSave);

        posisiPlayer = new Vector3
            (PlayerPrefs.GetFloat(_PosisiPlayerX),
            PlayerPrefs.GetFloat(_PosisiPlayerY),
            PlayerPrefs.GetFloat(_PosisiPlayerZ));

        koin = PlayerPrefs.GetFloat(_Koin);
        questComplate = PlayerPrefs.GetFloat(_QuestComplate);

        //Setting
        sizeScreen = PlayerPrefs.GetFloat(_SizeScreen);
        sensitifMouse = PlayerPrefs.GetFloat(_SensitifMouse);
        kecerahanMatahari = PlayerPrefs.GetFloat(_KecerahanMatahari);
        fieldOfView = PlayerPrefs.GetFloat(_FieldOfView);
        bayangan = PlayerPrefs.GetFloat(_Bayangan);
    }

    public void SaveKoin(float value)
    {
        PlayerPrefs.SetFloat(_Koin, value);
        LoadData();
    }
    public void SaveQuest(float value)
    {
        PlayerPrefs.SetFloat(_QuestComplate, value);
        LoadData();
    }
    public void SavePosisiPlayer(float x, float y, float z)
    {
        PlayerPrefs.SetFloat(_PosisiPlayerX, x);
        PlayerPrefs.SetFloat(_PosisiPlayerY, y);
        PlayerPrefs.SetFloat(_PosisiPlayerZ, z);
        LoadData();
    }

    public void SaveSetting(string nameSave, float value)
    {
        if (nameSave == _SizeScreen)
        {
            PlayerPrefs.SetFloat(_SizeScreen, value);
            sizeScreen = value;
        }
        else if (nameSave == _SensitifMouse)
        {
            PlayerPrefs.SetFloat(_SensitifMouse, value);
            sensitifMouse = value;
        }
        else if (nameSave == _KecerahanMatahari)
        {
            PlayerPrefs.SetFloat(_KecerahanMatahari, value);
            kecerahanMatahari = value;
        }
        else if (nameSave == _FieldOfView)
        {
            PlayerPrefs.SetFloat(_FieldOfView, value);
            fieldOfView = value;
        }
        else if (nameSave == _Bayangan)
        {
            PlayerPrefs.SetFloat(_Bayangan, value);
            bayangan = value;
        }
    }
    public void SaveSizeScreen(float value)
    {
        PlayerPrefs.SetFloat(_SizeScreen, value);

        LoadData();
    }
    public void DeleteData()
    {
        PlayerPrefs.DeleteKey(_IsSave);

        PlayerPrefs.DeleteKey(_PosisiPlayerX);
        PlayerPrefs.DeleteKey(_PosisiPlayerY);
        PlayerPrefs.DeleteKey(_PosisiPlayerZ);

        PlayerPrefs.DeleteKey(_Koin);
        PlayerPrefs.DeleteKey(_QuestComplate);

        PlayerPrefs.DeleteKey(_DefaultGame);

        dataQuest.DeleteData();

        DefaultData();
        LoadData();
        dataQuest.LoadData();

    }
}
