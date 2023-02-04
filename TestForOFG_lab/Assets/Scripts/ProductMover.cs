using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProductMover : MonoBehaviour
{
    [SerializeField] private float _maxVerticalDistance;
    [SerializeField] private float _minVerticalDistance;
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private float _horizontalSpeed;

    private float _moveVerticalPosition;
    private float _moveHorizontalPosition;
    private Vector3 _startVectorPosition;

    private SwipeController _swipeController;

    private void Start()
    {
        _swipeController = FindObjectOfType<SwipeController>();
        _startVectorPosition = transform.position;
        SetActive(false);
    }

    private void Update()
    {
        Move();
    }

    public void SetActive(bool isActive)
    {
        transform.position = _startVectorPosition;
        gameObject.SetActive(isActive);
    }

    private void Move()
    {
        _moveHorizontalPosition = transform.localPosition.x + _horizontalSpeed * Time.deltaTime;

        _moveVerticalPosition = Mathf.Clamp(transform.localPosition.y + _swipeController.GetVerticalDirection() * Time.deltaTime * _verticalSpeed, _minVerticalDistance, _maxVerticalDistance);
 
        if (_moveVerticalPosition != _maxVerticalDistance && _moveVerticalPosition != _minVerticalDistance && _swipeController.GetVerticalDirection() != 0)
        {
            transform.localPosition = new Vector3(_moveHorizontalPosition, _moveVerticalPosition, 0);
        }
    }
}
