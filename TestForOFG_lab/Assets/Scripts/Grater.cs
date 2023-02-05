using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grater : MonoBehaviour
{
    private GameState _gameState;
    private IIsTouch _iIsTouch;

    private void Start()
    {
        _gameState = FindObjectOfType<GameState>();
        _iIsTouch = FindObjectOfType<TapController>().GetComponent<IIsTouch>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Hand>())
        {
            _gameState.Cut();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<ProductMover>() && _iIsTouch.IsTouch() == false)
        {
            _gameState.Win();
        }
        else if (other.GetComponent<ProductPart>() != null)
        {
            ProductPart productPart = other.GetComponent<ProductPart>();
            productPart.InstantiateProductPartical();
            productPart.SetActive(false);
        }
    }
}
