using UnityEngine;

public class IsGroundedChecker : MonoBehaviour
{
    [SerializeField] private Transform checkerPosition; //guarda a posição do verificador
    [SerializeField] private Vector2 checkerSize; // responsavel por customizar o tamanho do verificador
    [SerializeField] private LayerMask groundLayer; //onde o jogador pode pisar

    public bool IsGrounded()
    {
        return Physics2D.OverlapBox
        (checkerPosition.position, checkerSize, 0f, groundLayer);
    }

    private void OnDrawGizmos()
    {
        if (checkerPosition == null) return;
        if (IsGrounded())
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawWireCube(checkerPosition.position, checkerSize);
    }
}
