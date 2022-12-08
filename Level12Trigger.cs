using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level12Trigger : MonoBehaviour
{
    public List<Animator> hostageAnimators = new List<Animator>();
    private static readonly int ThankFull = Animator.StringToHash("ThankFull");

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        foreach (var t in hostageAnimators)
        {
            t.SetBool(ThankFull, true);
        }

        StartCoroutine(WaitToActivateUI());
    }

    private IEnumerator WaitToActivateUI()
    {
        yield return new WaitForSecondsRealtime(3);
        UIManager.Instance.levelClear.SetActive(true);
    }
}
