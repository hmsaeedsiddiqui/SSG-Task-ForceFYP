using UnityEngine;

public class Level5Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.levelClear.SetActive(true);
        }
    }
}
