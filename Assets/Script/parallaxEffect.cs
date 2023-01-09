using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxEffect : MonoBehaviour
{
    [SerializeField] private Transform _mainCamera;
    [SerializeField, Range(0f, 1f)] private float _parallaxStrenght = 0.1f;
    [SerializeField] private bool _disableVerticalParallax;

    private Vector3 _previousPosition;

    private void Start()
    {
        if (!_mainCamera)
        {
            _mainCamera = Camera.main.transform;
        }

        _previousPosition = _mainCamera.position;
    }

    private void Update()
    {
        var delta = _mainCamera.position - _previousPosition;

        if (_disableVerticalParallax)
        {
            delta.y = 0;
        }

        _previousPosition = _mainCamera.position;
        transform.position += delta * _parallaxStrenght;
    }
}
