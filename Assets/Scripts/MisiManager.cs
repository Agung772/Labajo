using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisiManager : MonoBehaviour
{
    public Quest[] quest;

    public GameObject[] detectMisi;
    public GameObject[] dialogManager;
    public GameObject[] screenStoryManager;

    private void Start()
    {
        StartData();
        LoadData();

        for (int i = 0; i < quest.Length; i++)
        {
            GameSave.instance.dataQuest.SaveData(i, 1);
        }
    }

    void StartData()
    {
        detectMisi = new GameObject[transform.GetChild(0).childCount];
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            detectMisi[i] = transform.GetChild(0).GetChild(i).gameObject;
        }

        dialogManager = new GameObject[transform.GetChild(1).childCount];
        for (int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            dialogManager[i] = transform.GetChild(1).GetChild(i).gameObject;
        }

        screenStoryManager = new GameObject[transform.GetChild(2).childCount];
        for (int i = 0; i < transform.GetChild(2).childCount; i++)
        {
            screenStoryManager[i] = transform.GetChild(2).GetChild(i).gameObject;
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

    public void Misi1()
    {
        print("Kedetek");
    }


}
