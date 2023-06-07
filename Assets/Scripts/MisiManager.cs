using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisiManager : MonoBehaviour
{
    public QuestComplate questComplate;
    public GameObject notifMisiPrefab;

    public Quest[] quest;

    public GameObject[] detectMisi;
    public GameObject[] dialogManager;
    public GameObject[] screenStoryManager;
    public GameObject[] npc;

    private void Start()
    {
        StartData();
        LoadData();


        var dataQuest = GameSave.instance.dataQuest;
        //Set opening
        if (dataQuest.questIndex[0] == 0)
        {
            dataQuest.SaveData(0, 1);
        }
        //Load misi
        for (int i = 0; i < dataQuest.titleQuest.Length; i++)
        {
            if (dataQuest.questIndex[i] == 1)
            {
                StartMisi(i + ", 1");
                break;
            }

        }

        for (int i = 0; i < quest.Length; i++)
        {
            //GameSave.instance.dataQuest.SaveData(i, 1);
        }
    }

    void StartData()
    {
        detectMisi = new GameObject[transform.GetChild(0).childCount + 1];
        for (int i = 0; i < detectMisi.Length; i++)
        {
            if (i != 0) detectMisi[i] = transform.GetChild(0).GetChild(i - 1).gameObject;
        }

        dialogManager = new GameObject[transform.GetChild(1).childCount + 1];
        for (int i = 0; i < dialogManager.Length; i++)
        {
            if (i != 0) dialogManager[i] = transform.GetChild(1).GetChild(i - 1).gameObject;
        }

        screenStoryManager = new GameObject[transform.GetChild(2).childCount + 1];
        for (int i = 0; i < screenStoryManager.Length; i++)
        {
            if (i != 0) screenStoryManager[i] = transform.GetChild(2).GetChild(i - 1).gameObject;
        }

        npc = new GameObject[transform.GetChild(3).childCount + 1];
        for (int i = 0; i < npc.Length; i++)
        {
            if (i != 0) npc[i] = transform.GetChild(3).GetChild(i - 1).gameObject;
        }

        var dataQuest = GameSave.instance.dataQuest;

        quest = new Quest[dataQuest.titleQuest.Length];

        //Clear child
        QuestUI questUI = UIGameplay.instance.bookUI.GetComponent<BookUI>().m_QuestUI;
        int childContent = questUI.content.childCount;
        for (int i = 0; i < childContent; i++)
        {
            Destroy(questUI.content.GetChild(i).gameObject);
        }

        //Spawn NewC hild
        for (int i = 0; i < dataQuest.titleQuest.Length; i++)
        {
            if (i != 0)
            {
                GameObject temp = Instantiate(questUI.questPrefab, questUI.content);
                temp.name = "Misi (" + i + ")";
                quest[i] = temp.GetComponent<Quest>();
            }

        }
    }
    void LoadData()
    {
        var dataQuest = GameSave.instance.dataQuest;
        dataQuest.LoadData();

        for (int i = 0; i < dataQuest.titleQuest.Length; i++)
        {
            if (i != 0)
            {
                if (dataQuest.questIndex[i] == 0)
                {
                    quest[i].kondisi.sprite = quest[i].lockKondisi;
                }
                else if (dataQuest.questIndex[i] == 1)
                {
                    quest[i].kondisi.sprite = null;
                    quest[i].titleText.text = dataQuest.titleQuest[i];
                }
                else if (dataQuest.questIndex[i] == 2)
                {
                    quest[i].kondisi.sprite = quest[i].unlockKondisi;
                    quest[i].titleText.text = dataQuest.titleQuest[i];
                }
            }
        }
       
    }

    public void StartMisi(string index)
    {
        var dataQuest = GameSave.instance.dataQuest;
        if (index == "0, 1")
        {
            screenStoryManager[1].SetActive(true);
        }
        else if (index == "1, 1")
        {
            dataQuest.SaveData(1, 1);
            dialogManager[1].SetActive(true);
            npc[1].SetActive(true);
        }
        else if (index == "1, 2")
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                detectMisi[1].SetActive(true);
                SpawnNotifMisi(dataQuest.titleQuest[1]);
                yield return new WaitForSeconds(3);
                SpawnNotifMisi("Tekan Esc untuk melihat peta dan misi");
            }

        }
        else if (index == "1, 3")
        {
            screenStoryManager[2].SetActive(true);
        }
        else if (index == "1, 4")
        {
            dialogManager[2].SetActive(true);
        }
        else if (index == "2, 1")
        {
            dataQuest.SaveData(0, 2);
            dataQuest.SaveData(1, 2);
            dataQuest.SaveData(2, 1);
            detectMisi[2].SetActive(true);
            npc[1].SetActive(false);
            npc[2].SetActive(true);
            SpawnNotifMisi(dataQuest.titleQuest[2]);
        }
        else if (index == "2, 2")
        {
            screenStoryManager[3].SetActive(true);
        }
        else if (index == "2, 3")
        {
            dialogManager[3].SetActive(true);
        }
        else if (index == "3, 1")
        {
            dataQuest.SaveData(2, 2);
            dataQuest.SaveData(3, 1);
            detectMisi[3].SetActive(true);
            npc[2].SetActive(false);
            npc[3].SetActive(true);
            SpawnNotifMisi(dataQuest.titleQuest[3]);
        }
        else if (index == "3, 2")
        {
            screenStoryManager[4].SetActive(true);
        }
        else if (index == "4, 1")
        {
            dataQuest.SaveData(3, 2);
            dataQuest.SaveData(4, 1);
            detectMisi[4].SetActive(true);
            npc[3].SetActive(false);
            npc[4].SetActive(true);
            SpawnNotifMisi(dataQuest.titleQuest[4]);
        }
        else if (index == "4, 2")
        {
            screenStoryManager[5].SetActive(true);
        }
        else if (index == "4, 3")
        {
            dataQuest.SaveData(4, 2);
            dataQuest.SaveData(5, 2);

            SpawnNotifMisi(dataQuest.titleQuest[5]);
            print("Misi selesai");
            GameSave.instance.SaveQuest(1);
            questComplate.IsComplate = true;
            npc[4].SetActive(false);

            Npc[] npcs = FindObjectsOfType<Npc>();
            for (int i = 0; i < npcs.Length; i++)
            {
                npcs[i].LoadData();
            }
        }

        LoadData();
    }
    public void ExitMisi(int index)
    {
        var dataQuest = GameSave.instance.dataQuest;
        if (index == 0)
        {
            dataQuest.SaveData(0, 1);
        }
        else if (index == 1)
        {
            dataQuest.SaveData(1, 2);
        }
        else if (index == 2)
        {
            dataQuest.SaveData(2, 2);
        }
        LoadData();
    }

    public void SpawnNotifMisi(string value)
    {
        GameObject temp = Instantiate(notifMisiPrefab, UIGameplay.instance.spawnDialogBox);
        temp.GetComponent<NotifMisi>().titleText.text = value;
        Destroy(temp.gameObject, 4.5f);
    }
}
