using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogManager : MonoBehaviour
{
    [Serializable]
    public struct IsiDialog
    {
        public string namaDialog;
        public string isiDialog;
    }


    public List<IsiDialog> dialogList;

    public GameObject dialogBox;
    int dialogIndex;

    bool isUse;
    private void Start()
    {
        StartDialogBox();

        PlayerController.instance.operation = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartDialogBox();
        }
    }

    void StartDialogBox()
    {
        if (isUse) return;

        if (UIGameplay.instance.spawnDialogBox.childCount != 0)
        {
            Destroy(UIGameplay.instance.spawnDialogBox.GetChild(0).gameObject);
        }

        if (dialogIndex == dialogList.Count)
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                isUse = true;
                yield return new WaitForSeconds(0.5f);
                Destroy(gameObject);
                PlayerController.instance.operation = true;
            }

        }
        else
        {
            GameObject temp = Instantiate(dialogBox, UIGameplay.instance.spawnDialogBox);
            temp.GetComponent<DialogBox>().NamaText.text = dialogList[dialogIndex].namaDialog.ToString();
            temp.GetComponent<DialogBox>().isiDialogText.text = dialogList[dialogIndex].isiDialog.ToString();
        }
        dialogIndex++;
    }
}
