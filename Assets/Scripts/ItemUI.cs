using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public GameObject makananUI;
    [SerializeField]
    GameObject detailMakananUI;

    [SerializeField]
    GameObject minumanUI;
    [SerializeField]
    GameObject detailMinumanUI;

    [SerializeField]
    GameObject pakaianUI;
    [SerializeField]
    GameObject detailPakaianUI;

    [SerializeField]
    GameObject obatUI;
    [SerializeField]
    GameObject detailObatUI;

    [SerializeField]
    RectTransform makananButton;
    [SerializeField]
    RectTransform minumanButton;
    [SerializeField]
    RectTransform pakaianButton;
    [SerializeField]
    RectTransform obatButton;

    public void MakananUI()
    {
        FalseUI();

        makananUI.SetActive(true);
        FalseButton("makananButton");
    }
    public void DetailMakananUI(Sprite foto, string nama, string deskripsi)
    {
        FalseUI();

        detailMakananUI.SetActive(true);

        var dmUI = detailMakananUI.GetComponent<DetailUI>();

        dmUI.foto.sprite = foto;
        dmUI.nama.text = nama;
        dmUI.deskripsi.text = deskripsi;
    }
    public void MinumanUI()
    {
        FalseUI();

        minumanUI.SetActive(true);
        FalseButton("minumanButton");
    }
    public void DetailMinumanUI(Sprite foto, string nama, string deskripsi)
    {
        FalseUI();

        detailMinumanUI.SetActive(true);

        var dmUI = detailMinumanUI.GetComponent<DetailUI>();

        dmUI.foto.sprite = foto;
        dmUI.nama.text = nama;
        dmUI.deskripsi.text = deskripsi;
    }
    public void PakaianUI()
    {
        FalseUI();

        pakaianUI.SetActive(true);
        FalseButton("pakaianButton");
    }
    public void DetailPakaianUI(Sprite foto, string nama, string deskripsi)
    {
        FalseUI();

        detailPakaianUI.SetActive(true);

        var dmUI = detailPakaianUI.GetComponent<DetailUI>();

        dmUI.foto.sprite = foto;
        dmUI.nama.text = nama;
        dmUI.deskripsi.text = deskripsi;
    }
    public void ObatUI()
    {
        FalseUI();

        obatUI.SetActive(true);
        FalseButton("obatButton");
    }
    public void DetailObatUI(Sprite foto, string nama, string deskripsi)
    {
        FalseUI();

        detailObatUI.SetActive(true);

        var dmUI = detailObatUI.GetComponent<DetailUI>();

        dmUI.foto.sprite = foto;
        dmUI.nama.text = nama;
        dmUI.deskripsi.text = deskripsi;
    }
    void FalseUI()
    {
        makananUI.SetActive(false);
        detailMakananUI.SetActive(false);

        minumanUI.SetActive(false);
        detailMinumanUI.SetActive(false);

        pakaianUI.SetActive(false);
        detailPakaianUI.SetActive(false);

        obatUI.SetActive(false);
        detailObatUI.SetActive(false);
    }

    Vector2 posButton;
    bool savePosButton;
    void FalseButton(string namaButton)
    {
        if (!savePosButton)
        {
            savePosButton = true;
            posButton = makananButton.sizeDelta;
        }

        makananButton.sizeDelta = posButton;
        minumanButton.sizeDelta = posButton;
        pakaianButton.sizeDelta = posButton;
        obatButton.sizeDelta = posButton;

        float sizeClick = 1.1f;
        if (namaButton == "makananButton")
        {
            makananButton.sizeDelta = posButton * sizeClick;
        }
        else if (namaButton == "minumanButton")
        {
            minumanButton.sizeDelta = posButton * sizeClick;
        }
        else if (namaButton == "pakaianButton")
        {
            pakaianButton.sizeDelta = posButton * sizeClick;
        }
        else if (namaButton == "obatButton")
        {
            obatButton.sizeDelta = posButton * sizeClick;
        }
    }
}
