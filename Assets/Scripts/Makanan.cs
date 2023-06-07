using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Makanan : MonoBehaviour
{
    Sprite fotoMakanan;

    public string namaMakanan;
    public string deskripsiMakanan;

    private void OnEnable()
    {
        if (namaMakanan == "Kompyang")
        {
            if (GameSave.instance.dataQuest.kompyang == 1)
            {
                GetComponent<Button>().interactable = true;
            }
            else
            {
                GetComponent<Button>().interactable = false;
            }
        }
        else if (namaMakanan == "Kolo ")
        {
            if (GameSave.instance.dataQuest.kolo == 1)
            {
                GetComponent<Button>().interactable = true;
            }
            else
            {
                GetComponent<Button>().interactable = false;
            }
        }
    }

    public void TransferData()
    {
        fotoMakanan = GetComponent<Image>().sprite;
        BookUI.instance.itemUISC.DetailMakananUI(fotoMakanan, namaMakanan, deskripsiMakanan);
    }
}
