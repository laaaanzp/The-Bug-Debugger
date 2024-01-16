using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isDead;

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float forceDamping;

    private Vector2 forceToApply;
    private Vector2 playerInput;

    void Update()
    {
        if (isDead) return;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        playerInput = new Vector2(horizontal, vertical).normalized;

        float speed = Mathf.Abs(playerInput.x) + Mathf.Abs(playerInput.y);
        animator.SetFloat("Speed", speed);

        int halfWidthReso = Screen.width / 2;
        transform.localScale = new Vector3(halfWidthReso < Input.mousePosition.x ? 1 : -1, transform.localScale.y, transform.localScale.z);
    }

    void FixedUpdate()
    {
        Vector2 moveForce = playerInput * moveSpeed;
        moveForce += forceToApply;
        forceToApply /= forceDamping;

        if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
            forceToApply = Vector2.zero;

        rb.velocity = moveForce;
    }

    public void OnDeath()
    {
        isDead = true;
    }
}
