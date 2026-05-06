using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEventSO gameEvent;

    public UnityEvent response;

    public void OnEnable()
    {
        gameEvent.registerListener(this);
    }

    public void OnDisable()
    {
        gameEvent.unRegisterListener(this);
    }

    public void OnEventRaised()
    {
        response?.Invoke();
    }
}
