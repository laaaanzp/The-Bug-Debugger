using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject stringBulletPrefab;
    [SerializeField] private GameObject intBulletPrefab;
    [SerializeField] private GameObject floatBulletPrefab;
    [SerializeField] private GameObject boolBulletPrefab;
    [SerializeField] private GameObject charBulletPrefab;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float bulletForce = 20f;

    private float fireRateTimer = 0f;

    void Update()
    {
        if (fireRateTimer > 0f)
        {
            fireRateTimer -= Time.deltaTime;
            return;
        }

        if (Input.GetButton("Fire1"))
        {
            Shoot();
            fireRateTimer = fireRate;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(WeaponManager.currentBullet, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

        if (transform.parent.transform.localScale.x == 1)
        {
            bulletRB.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        }
        else
        {
            bulletRB.AddForce(-firePoint.right * bulletForce, ForceMode2D.Impulse);
        }
    }
}
