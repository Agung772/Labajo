using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenStoryManager : MonoBehaviour
{
    public string[] textStory;

    public GameObject screenStoryPrefab;

    private void Start()
    {
        GameObject temp = Instantiate(screenStoryPrefab, UIGameplay.instance.spawnScreenStory);
        temp.GetComponent<ScreenStory>().textStory = textStory;
        temp.GetComponent<ScreenStory>().StartScreenStory();
        temp.GetComponent<ScreenStory>().manager = gameObject;
        PlayerController.instance.operation = false;
    }
}
