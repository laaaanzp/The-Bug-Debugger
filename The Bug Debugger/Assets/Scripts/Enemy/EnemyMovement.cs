using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float distanceGap;

    private float distance;

    void Update()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        Vector2 direction = Vector2.zero;
        direction.Normalize();

        if (distance < distanceGap)
        {
            direction = target.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(direction.x < 0 ? -1 : 1, transform.localScale.y, transform.localScale.y);
        }

        float speed = Mathf.Abs(direction.x) + Mathf.Abs(direction.y);
        animator.SetFloat("Speed", speed);
    }

    public void OnHit()
    {
        distanceGap = 9999;
    }
}
