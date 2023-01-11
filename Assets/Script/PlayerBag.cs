using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBag : MonoBehaviour
{
    private EventInt _coinAdded = new EventInt();
    private int _coinCountInBag;

    public void AddCoin()
    {
        _coinCountInBag++;
        _coinAdded.Invoke(_coinCountInBag);
    }

    public void AddListener(UnityAction<int> action)
    {
        _coinAdded.AddListener(action);
    }

    public void RemoveListener(UnityAction<int> action)
    {
        _coinAdded.RemoveListener(action);
    }
}

[System.Serializable]

public class EventInt: UnityEvent<int> { }

