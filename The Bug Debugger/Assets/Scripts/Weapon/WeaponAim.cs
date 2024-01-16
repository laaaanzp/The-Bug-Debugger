using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    [SerializeField] private Transform weaponTransform;

    public bool isDead;

    void Update()
    {
        if (isDead) return;
        Vector3 mousePos = Utils.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        int halfWidthReso = Screen.width / 2;

        angle = halfWidthReso < Input.mousePosition.x ? angle : angle - 180;
        weaponTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    public void OnDeath()
    {
        isDead = true;
    }
}   
