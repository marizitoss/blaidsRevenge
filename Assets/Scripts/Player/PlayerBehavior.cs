using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    private Rigidbody2D rigidbody;
    private IsGroundedChecker isGroundedChecker;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        isGroundedChecker = GetComponent<IsGroundedChecker>();
    }

    private void Start()
    {
        GameManager.Instance.InputManager.OnJump += HandleJump;
    }

    private void Update()
    {
        float moveDirection = GameManager.Instance.InputManager.Movement;
        transform.Translate(moveDirection * Time.deltaTime * speed, 0, 0);
    }

    private void HandleJump()
    {
        if (isGroundedChecker.IsGrounded() == false) return;
        rigidbody.linearVelocity += Vector2.up * jumpForce;
    }
}
