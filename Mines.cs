using UnityEngine;

public class Mines : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        UIManager.Instance.LevelFail();
        LevelManager.Instance.levels[PlayerPrefs.GetInt("LevelNumber")].SetActive(false);
    }
}
