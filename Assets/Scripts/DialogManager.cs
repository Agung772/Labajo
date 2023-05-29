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
        if (transform.childCount != 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }

        if (dialogIndex == dialogList.Count)
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(1);
                Destroy(gameObject);
                PlayerController.instance.operation = true;
            }

        }
        else
        {
            GameObject temp = Instantiate(dialogBox, transform);
            temp.GetComponent<DialogBox>().NamaText.text = dialogList[dialogIndex].namaDialog.ToString();
            temp.GetComponent<DialogBox>().isiDialogText.text = dialogList[dialogIndex].isiDialog.ToString();
        }
        dialogIndex++;
    }
}
