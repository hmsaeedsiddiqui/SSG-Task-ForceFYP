using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject trigger, camera;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
