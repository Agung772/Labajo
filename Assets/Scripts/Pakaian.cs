using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pakaian : MonoBehaviour
{
    Sprite fotoPakaian;

    public string namaPakaian;
    public string deskripsiPakaian;

    public void TransferData()
    {
        fotoPakaian = GetComponent<Image>().sprite;
        BookUI.instance.itemUISC.DetailMakananUI(fotoPakaian, namaPakaian, deskripsiPakaian);
    }
}
