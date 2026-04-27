using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;
    private IsGroundedChecker groundedChecker;
    private Health playerHealth;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        groundedChecker = GetComponent<IsGroundedChecker>();
        playerHealth = GetComponent<Health>();
    }

    private void Start()
    {
        GameManager.Instance.InputManager.OnAttack += PlayAttackAnim;
        playerHealth.OnHurt += PlayerHurtAnim;
        playerHealth.OnDead += PlayDeadAnim;
    }

    private void Update()
    {
        bool isMoving = GameManager.Instance.InputManager.Movement != 0;
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isJumping", !groundedChecker.IsGrounded());
    }

    private void PlayAttackAnim()
    {
        animator.SetTrigger("attack");
    }

    private void PlayerHurtAnim()
    {
        animator.SetTrigger("hurt");
    }

    private void PlayDeadAnim()
    {
        animator.SetTrigger("dead");
    }
}
