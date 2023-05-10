using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
   private void Update()
   {
      Control();
   }

   public void Control()//Açıp kapatacağımız UI nesnelerinin statelere göre controlü ve cursor ayarları
   {
      if (GameManager.Instance._gameState == GameState.InGame)
      {
         Cursor.visible = false;
         Cursor.lockState = CursorLockMode.Locked;
         GameManager.Instance.inGameUI.SetActive(true);
         GameManager.Instance.endGameUI.SetActive(false);
      }
      else if (GameManager.Instance._gameState == GameState.EndGame)
      {
         GameManager.Instance.totalScoreTxt.text ="Total Score : " + GameManager.Instance.totalScore;
         GameManager.Instance.inGameUI.SetActive(false);
         GameManager.Instance.endGameUI.SetActive(true);
         Cursor.visible = true;
         Cursor.lockState = CursorLockMode.None;
      }
   }
   
   public void Restart()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}
