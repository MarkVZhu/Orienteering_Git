using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //public PauseMenu instance;
    public GameObject pausePanel;
    private bool canPause = true;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pausePanel&& canPause)
        {
            if (GameObject.Find("Player").GetComponent<PlayerControl>().canInput)
                PauseGame();
        }
    }

    public void PauseGame()
    {
        canPause = false;
        pausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        canPause = true;
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public void BackToMainmenu()
    {
        Time.timeScale = 1f; // To ensure yield return new WaitForSeconds() can function normally
        BGMManager.Instance.MuteLevelMusic();
        LoadManager.Instance.BackToMainmenu();
    }
}
