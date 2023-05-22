using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Makanan : MonoBehaviour
{
    Sprite fotoMakanan;

    public string namaMakanan;
    public string deskripsiMakanan;

    public void TransferData()
    {
        fotoMakanan = GetComponent<Image>().sprite;
        BookUI.instance.itemUISC.DetailMakananUI(fotoMakanan, namaMakanan, deskripsiMakanan);
    }
}
