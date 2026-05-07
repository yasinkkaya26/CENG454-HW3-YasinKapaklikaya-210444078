using UnityEngine;

public class DirectMoveStrategy : MonoBehaviour, IMoveStrategy
{
    public void Execute(Transform enemy, Transform target, float speed)
    {
        if (target == null) return;
        
        Vector2 direction = (target.position - enemy.position).normalized;
        enemy.position = Vector2.MoveTowards(enemy.position, target.position, speed * Time.deltaTime);
    }
}