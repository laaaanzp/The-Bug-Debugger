using UnityEngine;
using UnityEngine.UI;

public class BulletEntry : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] private Outline outline;


    public void SetSelected()
    {
        outline.enabled = true;
    }

    public void SetUnselected()
    {
        outline.enabled = false;
    }
}
