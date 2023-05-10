using UnityEngine;

public class FloorControl : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Item>())
        {
            collision.transform.position = collision.gameObject.GetComponent<Item>().defaultPosition;
            collision.transform.rotation = collision.gameObject.GetComponent<Item>().defaultRotation;
        }
    }
}
