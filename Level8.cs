using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level8 : MonoBehaviour
{
    public static Level8 Instance;
    public List<GameObject> bombs = new List<GameObject>();
    public GameObject bombCamera;
    public GameObject heli;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if ((Level8Trigger.Instance.enterTrigger) && (Input.GetAxis("Fire1") == 1 || Input.GetAxis("Fire2") == 1))
        {
            StartCoroutine(WaitToActivateBombs());
        }
    }

    private IEnumerator WaitToActivateBombs()
    {
        yield return new WaitForSecondsRealtime(2);
        heli.SetActive(false);
        bombCamera.SetActive(true);
        bombs[0].SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        bombs[0].SetActive(false);
        bombCamera.SetActive(true);
        bombs[1].SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        bombs[1].SetActive(false);
        bombCamera.SetActive(true);
        bombs[2].SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        bombs[2].SetActive(false);
        bombCamera.SetActive(false);
        UIManager.Instance.levelClear.SetActive(true);
    }
}
