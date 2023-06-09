using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    bool useFreeLook;
    public float sensitivitasCam = 2;

    public Camera kamera;

    public CinemachineFreeLook cinemachineFreeLook;

    [SerializeField]
    Light matahari;
    public float kecerahanMatahari;

    public GameObject textSampah;

    public GameSetting gameSetting;

    private void Awake()
    {
        instance = this;

        kecerahanMatahari = matahari.intensity;
    }

    private void Start()
    {
        CursorVisible(false);
        gameSetting.LoadGameSetting();

        AudioManager.instance.GameplayBGM();

    }

    private void Update()
    {
        CursorPlayer();
        SensitivitasCam();


        if (Input.GetKeyUp(KeyCode.Escape))
        {
            UIGameplay.instance.BookUI();

            AudioManager.instance.ButtonSfx();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            UIGameplay.instance.MapUI();


            AudioManager.instance.ButtonSfx();
        }

        //if (Input.GetKeyDown(KeyCode.Equals))
        //{

        //    Time.timeScale += 0.1f;
        //    print(Time.timeScale);
        //}
        //if (Input.GetKeyDown(KeyCode.Minus))
        //{
        //    if (Time.timeScale > 0)
        //    {
        //        Time.timeScale -= 0.1f;
        //    }
        //    print(Time.timeScale);
        //}
    }

    bool cursorPlayerAuto;
    void CursorPlayer()
    {
        if (!cursorPlayerAuto) return;

        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            useFreeLook = false;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            useFreeLook = true;
        }
    }

    public void CursorVisible(bool condition)
    {
        if (condition)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            useFreeLook = false;

            cursorPlayerAuto = false;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            useFreeLook = true;

            cursorPlayerAuto = true;
        }
    }

    public void SetSensitivitasCam(float value)
    {
        sensitivitasCam = value;
    }
    void SensitivitasCam()
    {
        if (useFreeLook)
        {
            cinemachineFreeLook.m_YAxis.m_MaxSpeed = sensitivitasCam;
            cinemachineFreeLook.m_XAxis.m_MaxSpeed = sensitivitasCam * 60;
        }
        else
        {
            cinemachineFreeLook.m_YAxis.m_MaxSpeed = 0;
            cinemachineFreeLook.m_XAxis.m_MaxSpeed = 0;
        }
    }


    public void SetKecerahanMatahari(float value)
    {
        matahari.intensity = value;
    }
    public void SetFieldOfView(float value)
    {
        cinemachineFreeLook.m_Lens.FieldOfView = (int)value;
    }
}
