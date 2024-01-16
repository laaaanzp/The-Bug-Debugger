using UnityEngine;

public class Module : MonoBehaviour
{
    [SerializeField] private GameObject moduleObject;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) moduleObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) moduleObject.SetActive(false);
    }
}
