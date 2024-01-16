using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private string codeDamage;


    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            if (collider.gameObject.TryGetComponent(out EnemyHealth health))
            {
                health.TakeDamage(codeDamage);
            }
        }

        Destroy(gameObject);
    }
}
