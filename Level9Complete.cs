using UnityEngine;

public class Level9Complete : MonoBehaviour
{
    private void OnEnable()
    {
        UIManager.Instance.levelClear.SetActive(true);
    }
}
