using UnityEngine;

public class Levels : MonoBehaviour
{
    public static Levels Instance;
    public int numberOfEnemies;
    public static int EnemyDied = 0;
    public GameObject level12Trigger;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    private void Update()
    {
        if (LevelManager.Instance.currentLevelNumber == 5)
        {
            AllBombDiffused();
        }
    }

    public void KillEnemy()
    {
        EnemyDied++;
        if (EnemyDied == numberOfEnemies)
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

    public void Level12EnemiesKilled()
    {
        EnemyDied++;
        if (EnemyDied == numberOfEnemies)
        {
            level12Trigger.SetActive(true);
        }
    }

    public void AllBombDiffused()
    {
        if (EnemyDied != numberOfEnemies) return;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        UIManager.Instance.levelClear.SetActive(true);
    }
}
