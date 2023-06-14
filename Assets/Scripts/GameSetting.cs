using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameSetting : MonoBehaviour
{
    public static GameSetting instance;
    [SerializeField]
    Dropdown sizeScreenDD;

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

    public UniversalRenderPipelineAsset URPSetting;

    public FieldInfo lwrpaShadowField = null;

    Resolution[] resolutions;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        LoadGameSetting();
    }

    public void LoadGameSetting()
    {
        AudioManager.instance.LoadVolume();

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

        if (GameSave.instance.bayangan == 1) { bayanganToggle.isOn = true; SetBayangan(true); }
        else { bayanganToggle.isOn = false; SetBayangan(false); }

        if (GameplayManager.instance != null)
        {
            GameplayManager.instance.SetSensitivitasCam(sensitifMouseSlider.value * 10);

            GameplayManager.instance.SetKecerahanMatahari(kecerahanMatahariSlider.value * 10);

            GameplayManager.instance.SetFieldOfView(fieldOfViewSlider.value * 100);


        }

        //Screen
        resolutions = Screen.resolutions;
        sizeScreenDD.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (i > 9)
            {
                string resuliton = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(resuliton);
                print(i);
            }


        }
        sizeScreenDD.AddOptions(options);
        sizeScreenDD.value = (int)GameSave.instance.sizeScreen;
        sizeScreenDD.RefreshShownValue();
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
            lwrpaShadowField = URPSetting.GetType().GetField("m_MainLightShadowsSupported", BindingFlags.NonPublic | BindingFlags.Instance);
            lwrpaShadowField.SetValue(URPSetting, true);
        }
        else
        {
            GameSave.instance.SaveSetting(GameSave.instance._Bayangan, 0);
            lwrpaShadowField = URPSetting.GetType().GetField("m_MainLightShadowsSupported", BindingFlags.NonPublic | BindingFlags.Instance);
            lwrpaShadowField.SetValue(URPSetting, false);
        }

    }

    public void SetSizeScreen(int value)
    {
        Resolution resolution = resolutions[value + 10];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        print(resolution);
        GameSave.instance.SaveSizeScreen(value);
    }
}
