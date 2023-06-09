using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public float volumeBGM;
    public float volumeSFX;

    [SerializeField]
    AudioSource audioSourceBGM;
    [SerializeField]
    AudioSource audioSourceSFX;

    public AudioClip
        homeBGM,
        gameplayBGM;

    public AudioClip
        walkSfx,
        buttonSfx,
        interaksiSfx,
        lompat1Sfx,
        lompat2Sfx;

    string _VolumeBGM = "VolumeBGM";
    string _VolumeSFX = "VolumeSFX";
    string _DefaultVolume = "DefaultVolume";

    private void Awake()
    {
        if (instance == null) instance = this;


        LoadVolume();
    }
    private void Start()
    {

    }

    public void LoadVolume()
    {
        if (PlayerPrefs.GetFloat(_DefaultVolume) == 0)
        {
            PlayerPrefs.SetFloat(_DefaultVolume, 1);
            PlayerPrefs.SetFloat(_VolumeBGM, 0.1f);
            PlayerPrefs.SetFloat(_VolumeSFX, 0.6f);
        }

        volumeBGM = PlayerPrefs.GetFloat(_VolumeBGM);
        volumeSFX = PlayerPrefs.GetFloat(_VolumeSFX);

        audioSourceBGM.volume = volumeBGM;
        audioSourceSFX.volume = volumeSFX;

        AudioSource[] aS = GameObject.FindObjectsOfType<AudioSource>();
        for (int i = 0; i < aS.Length; i++)
        {
            if (aS[i].gameObject.name != "AudioSourceBGM")
            {
                aS[i].volume = volumeSFX;
            }

        }
    }
    public void ValueBGM(float value)
    {
        volumeBGM = value;
        audioSourceBGM.volume = volumeBGM;
        PlayerPrefs.SetFloat(_VolumeBGM, volumeBGM);
        volumeBGM = Mathf.Clamp(volumeBGM, 0, 1);
    }
    public void ValueSFX(float value)
    {
        volumeSFX = value;
        audioSourceSFX.volume = volumeSFX;
        PlayerPrefs.SetFloat(_VolumeSFX, volumeSFX);
        volumeSFX = Mathf.Clamp(volumeSFX, 0, 1);

        AudioSource[] aS = GameObject.FindObjectsOfType<AudioSource>();
        for (int i = 0; i < aS.Length; i++)
        {
            if (aS[i].gameObject.name != "AudioSourceBGM")
            {
                aS[i].volume = volumeSFX;
            }

        }
    }

    AudioSource walk;
    public void SetWalkSFX(bool value)
    {
        if (value)
        {
            if (walk == null)
            {
                walk = Instantiate(audioSourceSFX, transform);
                walk.clip = walkSfx;
                walk.gameObject.name = "AudioWalk";
                walk.loop = true;
            }
            walk.Play();
        }
        else
        {
            if (walk == null)
            {
                walk = Instantiate(audioSourceSFX, transform);
                walk.clip = walkSfx;
                walk.gameObject.name = "AudioWalk";
                walk.loop = true;
            }
            walk.Stop();
        }

    }

    public void HomeBGM() { audioSourceBGM.clip = homeBGM; audioSourceBGM.Play(); }
    public void GameplayBGM() { audioSourceBGM.clip = gameplayBGM; audioSourceBGM.Play(); }
    public void ButtonSfx() { audioSourceSFX.PlayOneShot(buttonSfx); }
    public void InteraksiSfx() { audioSourceSFX.PlayOneShot(interaksiSfx); }
    public void Lompat1Sfx() { audioSourceSFX.PlayOneShot(lompat1Sfx); }
    public void Lompat2Sfx() { audioSourceSFX.PlayOneShot(lompat2Sfx); }
}
