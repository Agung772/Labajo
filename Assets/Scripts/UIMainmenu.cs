using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainmenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        AudioManager.instance.HomeBGM();
    }
}
