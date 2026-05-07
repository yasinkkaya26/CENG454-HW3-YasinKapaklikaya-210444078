using UnityEngine;

public class ZigzagMoveStrategy : MonoBehaviour, IMoveStrategy
{
    private float zigzagTimer;
    private float zigZagDirection = 1f;
    [SerializeField] private float zigZagInterval = 0.5f;
    [SerializeField] private float zigZagStrength = 2f;

    public void Execute(Transform enemy, Transform target, float speed)
    {
        if (target == null) return;

        zigzagTimer += Time.deltaTime;
        if (zigzagTimer >= zigZagInterval)
        {
            zigZagDirection *= -1f;
            zigzagTimer = 0f;
        }

        Vector2 forward = (target.position - enemy.position).normalized;

        Vector2 perpendicular = new Vector2(-forward.y, forward.x);

        Vector2 moveDir = (forward + perpendicular * zigZagDirection * zigZagStrength).normalized;

        enemy.position = Vector2.MoveTowards(

            enemy.position,
            (Vector2)enemy.position + moveDir,
            speed * Time.deltaTime

        );
    }
}