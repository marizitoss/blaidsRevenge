using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    private Rigidbody2D playerRigidbody;
    private IsGroundedChecker isGroundedChecker;
    private float moveDirection;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        isGroundedChecker = GetComponent<IsGroundedChecker>();
    }

    private void Start()
    {
        GameManager.Instance.InputManager.OnJump += HandleJump;
    }

    private void Update()
    {
        MovePlayer();
        FlipSpriteAccordingToMoveDirection();
    }

    private void MovePlayer()
    {
        moveDirection = GameManager.Instance.InputManager.Movement;
        transform.Translate(moveDirection * Time.deltaTime * speed, 0, 0);
    }

    private void FlipSpriteAccordingToMoveDirection()
    {
        if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveDirection > 0)
        {
            transform.localScale = Vector3.one;
        }
    }

    private void HandleJump()
    {
        if (isGroundedChecker.IsGrounded() == false) return;
        playerRigidbody.linearVelocity += Vector2.up * jumpForce;
    }
}
