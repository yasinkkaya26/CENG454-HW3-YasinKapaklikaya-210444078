using UnityEngine;

public class StayAndShootStrategy : MonoBehaviour, IMoveStrategy
{
    [SerializeField] private float stopDistance = 5f;

    public void Execute(Transform enemy, Transform target, float speed)
    {
        if (target == null) return;

        float distance = Vector2.Distance(enemy.position, target.position);

        if (distance > stopDistance)
        {
            enemy.position = Vector2.MoveTowards(
                enemy.position,
                target.position,
                speed * Time.deltaTime
            );
        }
    }
}