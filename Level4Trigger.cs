using UnityEngine;

public class Level4Trigger : MonoBehaviour
{
    public Animator playerAnimator;
    private int _cameraCount;

    private void Start()
    {
        _cameraCount = PlayerPrefs.GetInt("playercamera");
    }

    private void OnTriggerEnter(Collider other)
    {
        playerAnimator.SetBool("type", true);
        _cameraCount++;
        PlayerPrefs.SetInt("playercamera", _cameraCount);
        if (_cameraCount >= 3)
        {
            UIManager.Instance.levelClear.SetActive(true);
        }

    }
}
