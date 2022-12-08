using UnityEngine;

public class Level8Trigger : MonoBehaviour
{
    public static Level8Trigger Instance;
    public bool enterTrigger;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enterTrigger = true;
        }
    }
}
