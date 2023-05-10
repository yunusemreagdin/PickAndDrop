using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    //public GameObject player;
    //public Transform holdPos;

    private GameObject _heldObj; //Elimizde ki nesne
    private Rigidbody heldObjRb; //Elimizde ki nesnenin rigidbodysi
    public bool isCanCarry;
    void Update()
    {
        if (GameManager.Instance._gameState == GameState.InGame)
        {
            if (isCanCarry)
            {
                //Rayin isabet ettiği nesneyi PickUpObjecte veriyoruz ve zaten gerekli işlemler orada yapılıyor.
                PickUpObject(_heldObj);
            }
            PickUpControl();
            ThrowingControl();
        }
    }

    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) //Alınabilir nesnenin rigidbodysinin olduğundan emin olmamız gerekiyor
        {
            //heldObj = pickUpObj; //rayin çarptığı nesneyi tutulan nesneye atıyoruz (artık null değil)
            heldObjRb = pickUpObj.GetComponent<Rigidbody>();
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = GameManager.Instance.holdPosition.transform;
            _heldObj.layer = 0; //Nesnenin layer indexını/numarasını değiştiriyoruz.
            //Player ile collide olmaması lazım garip buglar çıkabiliyor sonra.
            Physics.IgnoreCollision(_heldObj.GetComponent<Collider>(), GameManager.Instance.player.GetComponent<Collider>(), true);
        }
    }

    void DropObject()
    {
        //Nesneyi bıraktığımız func.
        //collisionları eski haline çeviriyoruz çünkü artık bıraktık nesneyi
        Physics.IgnoreCollision(_heldObj.GetComponent<Collider>(), GameManager.Instance.player.GetComponent<Collider>(), false);
        _heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        _heldObj.transform.parent = null;
        _heldObj = null; //undefine yapıyoruz bıraktığımız için
        
    }

    void MoveObject()
    {
        //Nesne konumunu holdPosition konumuyla aynı tutuyoruz bu sayede hareketimiz sorunsuz oluyor
        _heldObj.transform.position = GameManager.Instance.holdPosition.transform.position;
    }

    void ThrowObject()
    {
        //Bunu extra yaptım case'i test ederken uzaktan atıyordum silmedim.
        //Aslında drop func. ile aynı sadece undefine etmeden önce AddForce uyguluyoruz
        Physics.IgnoreCollision(_heldObj.GetComponent<Collider>(), GameManager.Instance.player.GetComponent<Collider>(), false);
        _heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        _heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward * GameManager.Instance.throwForce);
        _heldObj = null;
    }

    void PickUpControl()
    {
        if (Input.GetKeyDown(GameManager.Instance.DATA.keyCodeInteraction))
        {
            if (GameManager.Instance._gameState == GameState.InGame)
            {
                if (_heldObj == null) //Eğer elimizde bir nesne yoksa
                {
                    //Cameradan ray atıyoruz
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,
                            GameManager.Instance.DATA.interactionDistance))
                    {
                        //Alınabilir nesne mi diye basit bir kontrol yapıyoruz
                        if (hit.transform.gameObject.tag == "canPickUp")
                        {
                            isCanCarry = true;
                            _heldObj = hit.transform.gameObject;
                        }
                    }
                }
                else //Elimizde nesne varsa
                {
                    isCanCarry = false;
                    DropObject();
                }
            }
        }
    }

    void ThrowingControl()
    {
        if (_heldObj != null) //Eğer nesne tutuyorsak
        {
            MoveObject(); //Nesnenin pozisyonunu holdPos'da tutuyoruz
            if (Input.GetKeyDown(GameManager.Instance.DATA.keyCodeThrowInteraction)) //Mouse1 nesneyi fırlatmak için kullanıyoruz
            {
                isCanCarry = false;
                ThrowObject();
            }
        }
    }
}