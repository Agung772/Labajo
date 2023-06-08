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

    [HideInInspector] public ScreenStoryManager manager;

    bool isUse;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartScreenStory();
            AudioManager.instance.ButtonSfx();
        }
    }

    public void StartScreenStory()
    {
        if (isUse) return;

        if (index == textStory.Length)
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                isUse = true;
                animator.SetTrigger("Exit");
                yield return new WaitForSeconds(1);
                manager.Exit();
                yield return new WaitForSeconds(1);
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
