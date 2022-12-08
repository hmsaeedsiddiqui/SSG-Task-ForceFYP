using System.Collections.Generic;
using SickscoreGames.HUDNavigationSystem;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public List<GameObject> players = new List<GameObject>();
    public List<GameObject> levels = new List<GameObject>();
    public List<Camera> cameras = new List<Camera>();
    public HUDNavigationSystem hudNavigationSystem;
    public int currentLevelNumber;
    public int nextLevelNumber = 1;
    public GameObject gameController;
    private static int _enemyDied = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        hudNavigationSystem.PlayerCamera = cameras[PlayerPrefs.GetInt("LevelNumber")];
        hudNavigationSystem.PlayerController = players[PlayerPrefs.GetInt("LevelNumber")].transform;
        currentLevelNumber = PlayerPrefs.GetInt("LevelNumber");
        nextLevelNumber = currentLevelNumber + 1;
        levels[currentLevelNumber].SetActive(true);
        
    }

    public void OnLoadNextLevel()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (currentLevelNumber >= levels.Count - 1)
        {
            currentLevelNumber = 0;
            nextLevelNumber = 1;
            PlayerPrefs.SetInt("LevelNumber", currentLevelNumber);
            UIManager.Instance.levelClear.SetActive(false);
            bl_SceneLoaderManager.LoadScene("MainGameplay");
        }
        else
        {
            currentLevelNumber++;
            nextLevelNumber++;
            PlayerPrefs.SetInt("LevelNumber", currentLevelNumber);
            UIManager.Instance.levelClear.SetActive(false);
            bl_SceneLoaderManager.LoadScene("MainGameplay");
        }
    }

    public void OnRestartLevel()
    {
        bl_SceneLoaderManager.LoadScene("MainGameplay");
    }

    public void OnSkipLevel()
    {
        OnLoadNextLevel();
    }

    public void KillEnemy()
    {
        _enemyDied++;
        if (_enemyDied == Levels.Instance.numberOfEnemies)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (PlayerPrefs.GetInt("LevelNumber") == 0)
            {
                GameManager.Instance.trigger.SetActive(true);
            }
            else if (LevelManager.Instance.currentLevelNumber == 2)
            {
                UIManager.Instance.levelClear.SetActive(true);
                UIManager.Instance.camera.SetActive(true);
            }
            else
            {
                UIManager.Instance.levelClear.SetActive(true);  
            }
        }
    }
}
