using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public GameObject loadScreen;
    public Slider slider;
    public Text text;
    private float waitInterval;
    private float mount;

    private void Start()
    {
        mount = Random.Range(4,8f)/100;
        waitInterval = Random.Range(1, 4f) / 10;
    }

    public void LoadNextLevel()
    {
        StartCoroutine(Loadlevel());
    }

   private IEnumerator Loadlevel()
    {
        loadScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            if(slider.value < 0.59)
            {
                slider.value = operation.progress / 1.5f;
                text.text = (int)(slider.value * 100) + "%";
            }
            else if(slider.value < 0.98)
            {
                yield return new WaitForSeconds(waitInterval);
                slider.value += mount;
                text.text = (int)(slider.value * 100) + "%";
            }
            else
            {
                slider.value = 1;
                text.text = "Walk to continue";
                if(Input.GetKeyDown(KeyCode.W))
                {
                    operation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}
