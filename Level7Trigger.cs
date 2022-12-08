using System.Collections;
using UnityEngine;

public class Level7Trigger : MonoBehaviour
{
    public Animator playerAnimator;
    private int _diffusedMineCount;
    private void Start()
    {
        _diffusedMineCount = PlayerPrefs.GetInt("Mine Diffused");
    }

    private void OnTriggerEnter(Collider other)
    {
        playerAnimator.SetBool("type", true);
        _diffusedMineCount++;
        PlayerPrefs.SetInt("Mine Diffused", _diffusedMineCount);
        StartCoroutine(WaitToDeactivateGameObject(other.gameObject));
        if (_diffusedMineCount >= 4)
        {
            UIManager.Instance.levelClear.SetActive(true);
        }

    }

    private IEnumerator WaitToDeactivateGameObject(GameObject gameObject)
    {
        yield return new WaitForSecondsRealtime(2);
        Destroy(gameObject);
    }
}
