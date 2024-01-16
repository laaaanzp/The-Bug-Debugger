using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private BulletEntry[] bullets;
    public static GameObject currentBullet;

    void Awake()
    {
        currentBullet = bullets[0].bulletPrefab;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (BulletEntry bullet in bullets) bullet.SetUnselected();
            bullets[0].SetSelected();
            currentBullet = bullets[0].bulletPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (BulletEntry bullet in bullets) bullet.SetUnselected();
            bullets[1].SetSelected();
            currentBullet = bullets[1].bulletPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach (BulletEntry bullet in bullets) bullet.SetUnselected();
            bullets[2].SetSelected();
            currentBullet = bullets[2].bulletPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach (BulletEntry bullet in bullets) bullet.SetUnselected();
            bullets[3].SetSelected();
            currentBullet = bullets[3].bulletPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            foreach (BulletEntry bullet in bullets) bullet.SetUnselected();
            bullets[4].SetSelected();
            currentBullet = bullets[4].bulletPrefab;
        }
    }
}
