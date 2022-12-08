using System.Collections;
using UnityEngine;

public class DiffuseBombs : MonoBehaviour
{
    public Animator playerAnimator;
    public GameObject mine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerAnimator.SetBool("type", true);
            Levels.EnemyDied++;
            StartCoroutine(WaitTillAnimationEnd());
        }
    }

    private IEnumerator WaitTillAnimationEnd()
    {
        yield return new WaitForSecondsRealtime(3);
        playerAnimator.SetBool("type", false);
        mine.SetActive(false);
        gameObject.SetActive(false);
        
    }
}
