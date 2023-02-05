using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProductMover : MonoBehaviour
{
    [SerializeField] private float _maxVerticalDistance;
    [SerializeField] private float _minVerticalDistance;
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private float _horizontalSpeed;

    private float _verticalDirection =1;
    private bool _isDirectionDown;
    private float _moveVerticalPosition;
    private float _moveHorizontalPosition;
    private Vector3 _startVectorPosition;

    private TapController _tapController;

    private void Awake()
    {
        _startVectorPosition = transform.position;
    }

    private void Start()
    {
        _tapController = FindObjectOfType<TapController>();
    }

    private void Update()
    {
        if (_tapController.IsTouch())
        {
            MoveFoward();
        }
        else
        {
            MoveToStartPostion();
        }
    }

    public void ResetPosition()
    {
        transform.position = _startVectorPosition;
    }

    private void MoveFoward()
    {
        if (_isDirectionDown == false)
        {
            if (_moveVerticalPosition == _maxVerticalDistance)
            {
                _verticalDirection = -1;
                _isDirectionDown = true;
            }
        }
        else
        {
            if (_moveVerticalPosition == _minVerticalDistance)
            {
                _verticalDirection = 1;
                _isDirectionDown = false;
            }
        }

        _moveHorizontalPosition = transform.localPosition.x + _horizontalSpeed * Time.deltaTime;
        _moveVerticalPosition = Mathf.Clamp(transform.localPosition.y + _verticalDirection * Time.deltaTime * _verticalSpeed, _minVerticalDistance, _maxVerticalDistance);

        transform.localPosition = new Vector3(_moveHorizontalPosition, _moveVerticalPosition, 0);
    }

    private void MoveToStartPostion()
    {
        _moveHorizontalPosition = transform.localPosition.x - _horizontalSpeed * Time.deltaTime;
        _moveVerticalPosition *= Time.deltaTime;
        if (transform.position.x > _startVectorPosition.x)
        {
            transform.localPosition = new Vector3(_moveHorizontalPosition, _moveVerticalPosition, 0);
        }
    }
}
