using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisiManager : MonoBehaviour
{
    public Quest[] quest;

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
