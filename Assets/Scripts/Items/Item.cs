using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Details")]
    public int point;
    public bool isTrue;
    public Vector3 defaultPosition;
    public Quaternion defaultRotation;

    private void Start()
    {
        defaultPosition = transform.position;//itemlerin başlangıç pozisyonlarını tutuyoruz geri getirmek için sonradan
        defaultRotation = transform.rotation;
    }
    
   public enum Categorys{ hat, shoes, glasses,headphones }//CarryDesk de aynı kategoriden 2 nesne var mı gibi kontolleri yapmamız için her item içinde kendi kategorisi seçili
   public Categorys categorys;
    
}
