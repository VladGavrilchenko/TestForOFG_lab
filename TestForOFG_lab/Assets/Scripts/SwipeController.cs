using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IIsTouch
{
    bool IsTouch();
}

public class SwipeController : MonoBehaviour, IIsTouch
{
    [SerializeField] private float _swipeRange;

    private Vector2 _startTouchPosition;
    private Vector2 _currentPosition;
    private Vector2 _distanceTouchPosition;

    private float _verticalDirection;
    private bool _isTouch;

    public static SwipeController instance = null;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        Swipe();
    }

    public float GetVerticalDirection()
    {
        return _verticalDirection;
    }

    public bool IsTouch()
    {
        return _isTouch;
    }

    private void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            _currentPosition = Input.GetTouch(0).position;
            _distanceTouchPosition = _currentPosition - _startTouchPosition;

            if (_distanceTouchPosition.y > _swipeRange)
            {
                _verticalDirection = 1;
            }
            if (_distanceTouchPosition.y < -_swipeRange)
            {
                _verticalDirection = -1;
            }
        }

        if (Input.touchCount == 0 || Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _verticalDirection = 0;
            _isTouch = false;
        }
        else
        {
            _isTouch = true;
        }

    }
}
