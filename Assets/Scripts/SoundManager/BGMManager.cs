using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager: MonoBehaviour
{
    public static BGMManager Instance;

    [SerializeField] private GameObject[] _musicSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        _musicSource[levelIndex].SetActive(true);
    }

    public void LevelMusicChange(int levelIndex)
    {
        _musicSource[levelIndex].SetActive(true);
    }

    public void MuteLevelMusic()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        _musicSource[levelIndex].SetActive(false);
    }
}
