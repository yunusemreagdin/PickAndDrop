using System.Collections.Generic;
using UnityEngine;

public class CarryDesk : MonoBehaviour
{
    public List<Item> itemLİst = new List<Item>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Item>())//Masaya item türünde bir nesne çarptıysa
        {
            foreach (var i in itemLİst)
            {
                if (i.categorys.Equals(collision.gameObject.GetComponent<Item>().categorys))//gelen itemin categorisiyle aynı categoride başka nesne var mı?
                {
                    i.gameObject.transform.position = i.defaultPosition;//varsa zaten masada olanı eski pozisyonuna gönder
                    itemLİst.Remove(i);//listeden sil
                    itemLİst.Add(collision.gameObject.GetComponent<Item>());//yeni nesneyi listeye ekle
                    return;
                }
            }
            itemLİst.Add(collision.gameObject.GetComponent<Item>());//zaten aynı kategoriden yoksa nesneyi direk listeye ekle
        }
    }

    //Masadan aldıysam itemi listeden siliyorum 
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Item>()) 
        {
            foreach (var i in itemLİst)
            {
                if (i == collision.gameObject.GetComponent<Item>())
                {
                    itemLİst.Remove(i); //listeden sil
                    return;
                }
                
            }
        }
    }
    public void CalculateScore()//Her itemin içinde ki int türünde ki değeri (5 veya -5)alıp total scor ile toplayıp veya çıkarıyoruz
    {
        foreach (var i in itemLİst)
            {
                GameManager.Instance.totalScore += i.point;
            }
    }
}
