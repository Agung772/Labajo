using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject loadingUI;
    public Image loadingBar;
    public TextMeshProUGUI loadingText;
    public void PindahScene(string sceneName)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            loadingBar.fillAmount = 0;
            loadingText.text = 0 + "%";

            GameManager.instance.Transisi("Start");

            yield return new WaitForSeconds(1);
            loadingUI.SetActive(true);
            loadingUI.GetComponent<Animator>().SetTrigger("Start");
            yield return new WaitForSeconds(1);

            var loadScene = SceneManager.LoadSceneAsync(sceneName);
            loadScene.allowSceneActivation = false;

            while (!loadScene.isDone)
            {
                loadingBar.fillAmount = loadScene.progress / 0.9f;
                loadingText.text = (loadScene.progress / 0.9f * 100).ToString("F0") + "%";

                if (loadScene.progress >= 0.9f)
                {
                    yield return new WaitForSeconds(1);
                    loadScene.allowSceneActivation = true;
                    loadingUI.GetComponent<Animator>().SetTrigger("Exit");

                    yield return new WaitForSeconds(1);
                    loadingUI.SetActive(false);
                    GameManager.instance.Transisi("Exit");
                }
            }

            yield return null;
        }
    }
}
