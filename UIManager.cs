using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject levelClear, levelFail, quit, camera;
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    
    public void ONQuitYes()
    {
        Application.Quit(0);
    }

    public void OnQuitNo()
    {
        var panelName = PlayerPrefs.GetString("PanelName");
        if (panelName.Equals(levelClear.name))
        {
            levelClear.SetActive(true);
        }
        else
        {
            levelFail.SetActive(true);
        }
    }

    public void LevelFail()
    {
        levelFail.SetActive(false);
    }
    
}
