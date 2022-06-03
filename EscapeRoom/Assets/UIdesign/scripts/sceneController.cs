using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour
{
    [SerializeField] GameObject loadingScrene;
    [SerializeField] Slider loadingSlider;
    [SerializeField] Text loadingText;
    private List<Button> buttons;
    //private float loadingProgress = 0.0f;
    private bool switchFade = true;

    public void changeSceneTo(string scaneName)
    {
        StartCoroutine(LoadLevelAsync(scaneName));
    }
    public void changeSceneTo(int sceneId)
    {
        StartCoroutine(LoadLevelAsync(sceneId));
    }

    IEnumerator LoadLevelAsync(string scaneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scaneName);
        loadingScrene.SetActive(true);

        int i = 0;
        int j = 0;
        while (!operation.isDone)
        {
            ++i;
            if ((i % 2) == 0)
                j++;

            var loadingProgress = operation.progress/* Mathf.Clamp01(operation.progress / .9f)*/;
            loadingText.text = $"Loading scene {getCharAnimation(j)} {loadingProgress * 100.0f} %";
            //Debug.Log($"Loading progress -> {loadingProgress} %");
            loadingSlider.value = loadingProgress;
            if (switchFade)
                StartCoroutine(FadeIn());
            else
                StartCoroutine(FadeOut());

            if (j >= 4)
                j = 0;
            yield return null;
        }
    }

    IEnumerator LoadLevelAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        loadingScrene.SetActive(true);

        int i = 0;
        int j = 0;
        while (!operation.isDone)
        {
            ++i;
            if ((i % 2) == 0)
                j++;

            var loadingProgress = operation.progress/* Mathf.Clamp01(operation.progress / .9f)*/;
            loadingText.text = $"Loading scene {getCharAnimation(j)} {loadingProgress * 100.0f} %";
            //Debug.Log($"Loading progress -> {loadingProgress} %");
            loadingSlider.value = loadingProgress;
            if (j >= 4)
                j = 0;
            yield return null;
        }
    }

    private char getCharAnimation(int animationFrame)
    {
        switch (animationFrame)
        {
            case 0:
                return '-';
            case 1:
                return '\\';
            case 2:
                return '|';
            case 3:
                return '/';
            default:
                return '-';
        }
    }

    IEnumerator FadeIn()
    {
        for(float alpha = 0.2f; alpha <= 1.0f; alpha += 0.05f)
        {
            var color = loadingText.color;
            color.a = alpha;
            loadingText.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        switchFade = false;
    }

    IEnumerator FadeOut()
    {
        for (float alpha = 1.0f; alpha >= 0.2f; alpha -= 0.05f)
        {
            var color = loadingText.color;
            color.a = alpha;
            loadingText.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        switchFade = true;
    }

    public void closeApplication()
    {
        Application.Quit();
    }
}
