using UnityEngine;

public class Door : MonoBehaviour
{
    //public Camera _camera;
    
    private void Update()
    {
        if (Input.GetKeyDown(GameManager.Instance.DATA.keyCodeDoorInteraction))//Sol mouse ile tıkladıysam
        {
            if (GameManager.Instance._gameState == GameState.InGame)
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit,
                        GameManager.Instance.DATA.interactionDistance))
                {
                    if (hit.transform.gameObject.CompareTag("Door"))//Ray eğer kapıya çarptıysa
                    {
                        GameManager.Instance._gameState = GameState.EndGame;//state değiştir
                        GameManager.Instance.desk.CalculateScore();//scoru hesapla
                    }
                }
            }
            
        }
    }
}
