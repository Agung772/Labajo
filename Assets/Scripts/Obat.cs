using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obat : MonoBehaviour
{
    Sprite fotoObat;

    public string namaObat;
    public string deskripsiObat;

    public void TransferData()
    {
        fotoObat = GetComponent<Image>().sprite;
        BookUI.instance.itemUISC.DetailMakananUI(fotoObat, namaObat, deskripsiObat);
    }
}
