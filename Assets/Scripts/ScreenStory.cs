using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenStory : MonoBehaviour
{
    public Text text;
    public string[] textStory;

    int index;
    [SerializeField] Animator animator;

    private void Start()
    {
        StartScreenStory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartScreenStory();
        }
    }

    void StartScreenStory()
    {
        if (index == textStory.Length)
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                animator.SetTrigger("Exit");
                yield return new WaitForSeconds(2);
                Destroy(gameObject);
            }
        }
        else
        {
            text.text = textStory[index].ToString();
        }

        index++;
    }
}
