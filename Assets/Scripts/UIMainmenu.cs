using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainmenu : MonoBehaviour
{
    public GameObject popupNewgame;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        AudioManager.instance.HomeBGM();
    }

    public void Newgame()
    {
        if (GameSave.instance.isSave == 1)
        {
            popupNewgame.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetFloat(GameSave.instance._IsSave, 1);
            GameSave.instance.LoadData();
            GameManager.instance.GetComponent<UIManager>().PindahScene("Gameplay");

        }
    }

    public void YesNewgame()
    {
        GameSave.instance.DeleteData();
        PlayerPrefs.SetFloat(GameSave.instance._IsSave, 1);
        GameSave.instance.LoadData();
        GameManager.instance.GetComponent<UIManager>().PindahScene("Gameplay");
    }

    public void Loadgame()
    {
        if (GameSave.instance.isSave == 1)
        {
            GameManager.instance.GetComponent<UIManager>().PindahScene("Gameplay");
        }
        else
        {
            GameManager.instance.SpawnNotif("Belom ada data yang tersimpan, Mulai game yuk");

        }
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}
