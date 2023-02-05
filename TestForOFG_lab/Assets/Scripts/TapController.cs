using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IIsTouch
{
    bool IsTouch();
}

public class TapController: MonoBehaviour, IIsTouch
{
    private bool _isTouch;
    public static TapController instance = null;

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
        if (Input.touchCount > 0)
        {
            _isTouch = true;
        }
        else
        {
            _isTouch = false;
        }
    }

    public bool IsTouch()
    {
        return _isTouch;
    }

}
