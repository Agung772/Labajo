using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenStoryManager : MonoBehaviour
{
    public bool quick;

    public string[] textStory;

    public GameObject screenStoryPrefab;

    public UnityEvent ExitTrigger;

    private void Start()
    {
        GameObject temp = Instantiate(screenStoryPrefab, UIGameplay.instance.spawnScreenStory);
        temp.GetComponent<ScreenStory>().textStory = textStory;
        temp.GetComponent<ScreenStory>().StartScreenStory();
        temp.GetComponent<ScreenStory>().manager = this;
        PlayerController.instance.operation = false;

        if (quick)
        {
            temp.GetComponent<Animator>().SetTrigger("Quick");
        }
        else
        {
            temp.GetComponent<Animator>().SetTrigger("Start");
        }
    }

    public void Exit()
    {
        PlayerController.instance.operation = true;
        ExitTrigger.Invoke();
        Destroy(gameObject);
    }
}
