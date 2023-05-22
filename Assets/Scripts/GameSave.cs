using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    public static GameSave instance;

    //Value save
    public Vector3 posisiPlayer;


    //Setting
    [Space]
    public float grafik;
    public float sensitifMouse;
    public float kecerahanMatahari;
    public float fieldOfView;
    public float bayangan;

    //Anti typo -------------------------------------
    [HideInInspector]
    public string _Default = "Default";

    //Player
    [HideInInspector]
    public string
        _PosisiPlayerX = "PosisiPlayerX",
        _PosisiPlayerY = "PosisiPlayerY",
        _PosisiPlayerZ = "PosisiPlayerZ";

    //Setting
    [HideInInspector]
    public string
        _Grafik = "Grafik",
        _SensitifMouse = "SensitifMouse",
        _KecerahanMatahari = "KecerahanMatahari",
        _FieldOfView = "FieldOfView",
        _Bayangan = "Bayangan";

    private void Awake()
    {
        instance = this;

        DefaultData();
        LoadData();
    }
    private void Start()
    {

    }

    void DefaultData()
    {
        if (PlayerPrefs.GetFloat(_Default) == 0)
        {
            PlayerPrefs.SetFloat(_Default, 1);

            SaveSetting(_Grafik, 2);
            SaveSetting(_SensitifMouse, GameSetting.instance.sensitifMouseDefault);
            SaveSetting(_KecerahanMatahari, GameSetting.instance.kecerahanMatahariDefault);
            SaveSetting(_FieldOfView, GameSetting.instance.fieldOfViewDefault);
            SaveSetting(_Bayangan, 1);
        }

    }

    void LoadData()
    {
        posisiPlayer = new Vector3
            (PlayerPrefs.GetFloat(_PosisiPlayerX),
            PlayerPrefs.GetFloat(_PosisiPlayerY),
            PlayerPrefs.GetFloat(_PosisiPlayerZ));

        //Setting
        grafik = PlayerPrefs.GetFloat(_Grafik);
        sensitifMouse = PlayerPrefs.GetFloat(_SensitifMouse);
        kecerahanMatahari = PlayerPrefs.GetFloat(_KecerahanMatahari);
        fieldOfView = PlayerPrefs.GetFloat(_FieldOfView);
        bayangan = PlayerPrefs.GetFloat(_Bayangan);
    }

    public void SaveSetting(string nameSave, float value)
    {
        if (nameSave == _Grafik)
        {
            PlayerPrefs.SetFloat(_Grafik, value);
            grafik = value;
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
}
