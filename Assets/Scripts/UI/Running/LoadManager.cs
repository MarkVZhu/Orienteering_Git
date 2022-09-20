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

    public static LoadManager Instance;
    private float waitInterval;
    private bool canShowLoadScreen;
    private float mount;

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (loadScreen)
        {
            mount = Random.Range(4, 8f) / 100;
            waitInterval = Random.Range(1, 4f) / 10;
            slider = loadScreen.GetComponentInChildren<Slider>();
        }

        if (BGMManager.Instance && SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 0)
            BGMManager.Instance.LevelMusicChange(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResultBeforeLoadNextLevel()
    {
        StartCoroutine(LevelResulScreen());
    }

    public void LoadLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            BGMManager.Instance.MuteLevelMusic();
            BackToMainmenu();
        }
        else
        {
            StartCoroutine(LoadLevelEx());
        }
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

    //Load next level
    public IEnumerator LoadLevelEx()
    {
        if (loadScreen)
        {
            loadScreen.SetActive(true);
            BGMManager.Instance.MuteLevelMusic();

            AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

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
        else
        {
            SceneManager.LoadScene(4);
        }
    }

    public IEnumerator LoadLevelExWithLoadPage(int nextLevelNumber, GameObject loadScreen)
    {
        loadScreen.SetActive(true);
        BGMManager.Instance.MuteLevelMusic();

        AsyncOperation operation = SceneManager.LoadSceneAsync(nextLevelNumber);

        operation.allowSceneActivation = false;

        Slider slider = loadScreen.GetComponentInChildren<Slider>();
        Text text = loadScreen.GetComponentInChildren<Text>();

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

    public void LoadLevelExWithLoadPageButton(int nextLevelNumber, GameObject loadScreen)
    {
        StartCoroutine(LoadLevelExWithLoadPage(nextLevelNumber, loadScreen));
    }

    public void BackToMainmenu()
    {
        SceneManager.LoadScene(0);
    }

    public bool GetCanShowLoadScreen()
    {
        return canShowLoadScreen;
    }
}
