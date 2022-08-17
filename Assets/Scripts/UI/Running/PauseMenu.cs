using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //public PauseMenu instance;
    public GameObject pausePanel;
    private bool canPause = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pausePanel&& canPause)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        canPause = false;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        canPause = true;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMainmenu()
    {
        Time.timeScale = 1f; // To ensure yield return new WaitForSeconds() can function normally
        LoadManager.Instance.BackToMainmenu();
    }
}
