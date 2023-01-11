using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScore : MonoBehaviour
{
    [SerializeField] private Text _healthText;

    private Player _player;

    private void Start()
    {
        int health = _player.GetStartHealth();
        SetHealthScore(health);
    }
    public void SetHealthScore(int value)
    {
        _healthText.text = value.ToString();
    }

    private void OnEnable()
    {
        if(_player == null )
        {
            _player = FindObjectOfType<Player>();
        }

        _player.AddListener(SetHealthScore);        
    }

    private void OnDisable()
    {
        _player.RemoveListener(SetHealthScore);
    }
}
