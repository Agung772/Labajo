using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minuman : MonoBehaviour
{
    Sprite fotoMinuman;

    public string namaMinuman;
    public string deskripsiMinuman;

    public void TransferData()
    {
        fotoMinuman = GetComponent<Image>().sprite;
        BookUI.instance.itemUISC.DetailMinumanUI(fotoMinuman, namaMinuman, deskripsiMinuman);
    }
}
