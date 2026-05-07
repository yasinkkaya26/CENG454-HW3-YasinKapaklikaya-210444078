using UnityEngine;

public interface IMoveStrategy
{
    void Execute(Transform enemy, Transform target, float speed);
}
