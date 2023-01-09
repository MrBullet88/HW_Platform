using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{ 
    private EventInt _healthDeleted = new EventInt(); 
    private int _health = 5;

    public void DeleteHealth()
    {
        _health--;
        _healthDeleted.Invoke(_health);

        if (_health == 0)
        {
            Debug.Log("GameOver");
        }
    }

    public void AddListener(UnityAction<int> action)
    {
        _healthDeleted.AddListener(action);
    }

    public void RemoveListener(UnityAction<int> action)
    {
        _healthDeleted.RemoveListener(action);
    }

    public int GetStartHealth()
    {
        return _health;
    }
}

