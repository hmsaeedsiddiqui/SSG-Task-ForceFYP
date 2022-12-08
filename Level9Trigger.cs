using UnityEngine;

public class Level9Trigger : MonoBehaviour
{
    public GameObject missileCutScene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            missileCutScene.SetActive(true);
        }
    }
}
