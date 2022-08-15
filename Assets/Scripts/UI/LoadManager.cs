using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public GameObject loadScreen;
    public GameObject resultScreen;
    public GameObject continueText;
    public Text text;
    private Slider slider;
    

    private float waitInterval;
    private bool canShowLoadScreen;
    private float mount;

    private void Start()
    {
        mount = Random.Range(4,8f)/100;
        waitInterval = Random.Range(1, 4f) / 10;
        slider = loadScreen.GetComponentInChildren<Slider>();
        if (BGMManager.Instance)
            BGMManager.Instance.LevelMusicChange(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResultBeforeLoadNextLevel()
    {
        StartCoroutine(LevelResulScreen());
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelEx());
    }

   private IEnumerator LevelResulScreen()
    {
        if (resultScreen && continueText)
        {
            resultScreen.SetActive(true);
            yield return new WaitForSeconds(3f);
            continueText.SetActive(true);
        }
        canShowLoadScreen = true;
        yield return null;
    }

    public IEnumerator LoadLevelEx()
    {
        LoadLevelEx(SceneManager.GetActiveScene().buildIndex + 1);
        yield return null;
    }

    public IEnumerator LoadLevelEx(int nextLevelNumber)
    {
        loadScreen.SetActive(true);
        BGMManager.Instance.MuteLevelMusic();

        AsyncOperation operation = SceneManager.LoadSceneAsync(nextLevelNumber);

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            if (slider.value < 0.59)
            {
                slider.value = operation.progress / 1.5f;
                text.text = (int)(slider.value * 100) + "%";
            }
            else if (slider.value < 0.98)
            {
                yield return new WaitForSeconds(waitInterval);
                slider.value += mount;
                text.text = (int)(slider.value * 100) + "%";
            }
            else
            {
                slider.value = 1;
                text.text = "Walk to continue";
                if (Input.GetKeyDown(KeyCode.W))
                {
                    operation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }

    public bool GetCanShowLoadScreen()
    {
        return canShowLoadScreen;
    }
}
