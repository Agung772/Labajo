using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetButtonAudio : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetAudio);
    }

    void SetAudio()
    {
        AudioManager.instance.ButtonSfx();
    }
}
