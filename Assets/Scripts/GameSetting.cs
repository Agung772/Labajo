using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetting : MonoBehaviour
{
    public static GameSetting instance;

    [SerializeField]
    Dropdown grafikGameDD;

    [Space]
    [SerializeField]
    Slider volumeBGMSlider;
    [SerializeField]
    Text volumeBGMText;
    [SerializeField]
    Slider volumeSFXSlider;
    [SerializeField]
    Text volumeSFXText;

    [Space]
    [SerializeField]
    float sensitifMouse;
    public float sensitifMouseDefault = 2;
    [SerializeField]
    Slider sensitifMouseSlider;
    [SerializeField]
    Text senMouseText;

    [Space]
    [SerializeField]
    float kecerahanMatahari;
    public float kecerahanMatahariDefault = 3;
    [SerializeField]
    Slider kecerahanMatahariSlider;
    [SerializeField]
    Text kecerahanMatahariText;

    [Space]
    [SerializeField]
    float fieldOfView;
    public float fieldOfViewDefault = 60;
    [SerializeField]
    Slider fieldOfViewSlider;
    [SerializeField]
    Text fieldOfViewText;

    [Space]
    [SerializeField]
    Toggle bayanganToggle;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        LoadGameSetting();
    }

    void LoadGameSetting()
    {
        grafikGameDD.value = (int)GameSave.instance.grafik;
        QualitySettings.SetQualityLevel(grafikGameDD.value);
        print((int)GameSave.instance.grafik);

        volumeBGMSlider.value = AudioManager.instance.volumeBGM;
        volumeBGMText.text = (volumeBGMSlider.value * 100).ToString("F1") + "%";
        volumeSFXSlider.value = AudioManager.instance.volumeSFX;
        volumeSFXText.text = (volumeSFXSlider.value * 100).ToString("F1") + "%";

        sensitifMouse = GameSave.instance.sensitifMouse;
        sensitifMouseSlider.value = sensitifMouse / 10;
        senMouseText.text = (sensitifMouseSlider.value * 100).ToString("F1") + "%";

        kecerahanMatahari = GameSave.instance.kecerahanMatahari;
        kecerahanMatahariSlider.value = kecerahanMatahari / 10;
        kecerahanMatahariText.text = (kecerahanMatahariSlider.value * 100).ToString("F1") + "%";

        fieldOfView = GameSave.instance.fieldOfView;
        fieldOfViewSlider.value = fieldOfView / 100;
        fieldOfViewText.text = (fieldOfViewSlider.value * 100).ToString("F0");

        if (GameSave.instance.bayangan == 1) bayanganToggle.isOn = true;
        else bayanganToggle.isOn = false;

        if (GameplayManager.instance != null)
        {
            GameplayManager.instance.SetSensitivitasCam(sensitifMouseSlider.value * 10);

            GameplayManager.instance.SetKecerahanMatahari(kecerahanMatahariSlider.value * 10);

            GameplayManager.instance.SetFieldOfView(fieldOfViewSlider.value * 100);
        }
    }

    public void SetGrafik(int value)
    {
        QualitySettings.SetQualityLevel(value);

        GameSave.instance.SaveSetting(GameSave.instance._Grafik, value);
    }

    public void SetBGM(float value)
    {
        AudioManager.instance.ValueBGM(value);
        volumeBGMText.text = (value * 100).ToString("F1");
    }
    public void SetSFX(float value)
    {
        AudioManager.instance.ValueSFX(value);
        volumeSFXText.text = (value * 100).ToString("F1");
    }
    public void SetSensitifMouse(float value)
    {
        senMouseText.text = (value * 100).ToString("F1") + "%";
        if (GameplayManager.instance != null)
        {
            GameplayManager.instance.SetSensitivitasCam(value * 10);
        }

        GameSave.instance.SaveSetting(GameSave.instance._SensitifMouse, value * 10);
    }
    public void DefaultSensitifMouse()
    {
        sensitifMouse = sensitifMouseDefault;
        sensitifMouseSlider.value = sensitifMouse / 10;
        senMouseText.text = (sensitifMouseSlider.value * 100).ToString("F1") + "%";
        if (GameplayManager.instance != null)
        {
            GameplayManager.instance.SetSensitivitasCam(sensitifMouseSlider.value * 10);
        }

        GameSave.instance.SaveSetting(GameSave.instance._SensitifMouse, sensitifMouseSlider.value * 10);
    }

    public void SetKecerahanMatahari(float value)
    {
        kecerahanMatahariText.text = (value * 100).ToString("F1") + "%";
        if (GameplayManager.instance != null)
        {
            GameplayManager.instance.SetKecerahanMatahari(value * 10);
        }

        GameSave.instance.SaveSetting(GameSave.instance._KecerahanMatahari, value * 10);
    }
    public void DefaultKecerahanMatahari()
    {
        kecerahanMatahari = kecerahanMatahariDefault;
        kecerahanMatahariSlider.value = kecerahanMatahari / 10;
        kecerahanMatahariText.text = (kecerahanMatahariSlider.value * 100).ToString("F1") + "%";
        if (GameplayManager.instance != null)
        {
            GameplayManager.instance.SetKecerahanMatahari(kecerahanMatahariSlider.value * 10);
        }

        GameSave.instance.SaveSetting(GameSave.instance._KecerahanMatahari, kecerahanMatahariSlider.value * 10);
    }
    public void SetFieldOfView(float value)
    {
        fieldOfViewText.text = (value * 100).ToString("F0");
        if (GameplayManager.instance != null)
        {
            GameplayManager.instance.SetFieldOfView(value * 100);
        }

        GameSave.instance.SaveSetting(GameSave.instance._FieldOfView, value * 100);
    }
    public void DefaultFieldOfView()
    {
        fieldOfView = fieldOfViewDefault;
        fieldOfViewSlider.value = fieldOfView / 100;
        fieldOfViewText.text = (fieldOfViewSlider.value * 100).ToString("F0");
        if (GameplayManager.instance != null)
        {
            GameplayManager.instance.SetFieldOfView(fieldOfViewSlider.value * 100);
        }

        GameSave.instance.SaveSetting(GameSave.instance._FieldOfView, fieldOfViewSlider.value * 100);
    }

    public void SetBayangan(bool value)
    {
        if (value)
        {
            GameSave.instance.SaveSetting(GameSave.instance._Bayangan, 1);
        }
        else
        {
            GameSave.instance.SaveSetting(GameSave.instance._Bayangan, 0);
        }

    }
}
