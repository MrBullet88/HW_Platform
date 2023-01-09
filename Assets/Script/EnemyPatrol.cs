using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform _groundDetector; 
    [SerializeField] private float _speed;

    private bool _moovingRight = true;
    private float _distance = 2;

    private void Update()
    {
       transform.Translate(Vector2.right* _speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(_groundDetector.position, Vector2.down, _distance);

        if(groundInfo.collider == false)
        {
            if (_moovingRight == true)
            {
                transform.eulerAngles = new Vector3(0,-180,0);
                _moovingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0,0,0);
                _moovingRight = true;
            }
        }
    }
}
