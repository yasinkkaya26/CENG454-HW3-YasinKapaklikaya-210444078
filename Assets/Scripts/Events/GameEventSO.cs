using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/GameEvent")]
public class GameEventSO : MonoBehaviour
{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise()
    {
        for (int i = listeners.Count -1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void registerListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void unRegisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}