using System.Collections;
using UnityEngine;

public class Level2Trigger : MonoBehaviour
{
   public Animator playerAnimator;
   public GameObject levelCompleteMsg;
   public Animation chestAnimation;
   public GameObject enemies;
   private void OnTriggerEnter(Collider other)
   {
      Debug.Log($"Usama {other.gameObject.tag} Name {other.gameObject.name}");
      if (other.CompareTag("Player"))
      {
         if (playerAnimator == null && chestAnimation == null)
         {
            levelCompleteMsg.SetActive(true); 
            StartCoroutine(WaitToDisplayScreen());   
         }
         else
         {
            chestAnimation.Play();
            levelCompleteMsg.SetActive(true); 
            StartCoroutine(WaitToDisplayScreen());  
         } 
      }
      else if (other.CompareTag("Vehicle"))
      {
         enemies.SetActive(false);
         levelCompleteMsg.SetActive(true); 
         StartCoroutine(WaitToDisplayScreen()); 
      }
      
   }

   private IEnumerator WaitToDisplayScreen()
   {
      yield return new WaitForSecondsRealtime(5);
      if (LevelManager.Instance.currentLevelNumber == 0)
      {
         Cursor.visible = true;
         Cursor.lockState = CursorLockMode.None;
         UIManager.Instance.camera.SetActive(true);
         UIManager.Instance.levelClear.SetActive(true);
      }
      else
      {
         Cursor.visible = true;
         Cursor.lockState = CursorLockMode.None;
         GameManager.Instance.camera.SetActive(true);
         yield return new WaitForSecondsRealtime(2);
         UIManager.Instance.camera.SetActive(true);
         UIManager.Instance.levelClear.SetActive(true);
      }
   }
   
}
