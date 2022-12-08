using System.Collections.Generic;
using Michsky.UI.Shift;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement Instance;
    public List<ChapterButton> chapterButtons = new List<ChapterButton>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("LevelNumber"))
        {
            PlayerPrefs.SetInt("LevelNumber", 0);
        }
    }

    public void OnQuickMatch()
    {
        bl_SceneLoaderManager.LoadScene("MainGameplay");
    }

    private void Update()
    {
        for (var i = 0; i < PlayerPrefs.GetInt("LevelNumber"); i++)
        {
            chapterButtons[i].statusItem = ChapterButton.StatusItem.COMPLETED;
        } 
    }

    public void OnLoadSpecificLevel(int level)
    {
        if (chapterButtons[level].statusItem == ChapterButton.StatusItem.LOCKED)return;
        for (var i = 0; i < PlayerPrefs.GetInt("LevelNumber"); i++)
        {
            chapterButtons[i].statusItem = ChapterButton.StatusItem.COMPLETED;
        }
        PlayerPrefs.SetInt("LevelNumber", level);
    }
}
