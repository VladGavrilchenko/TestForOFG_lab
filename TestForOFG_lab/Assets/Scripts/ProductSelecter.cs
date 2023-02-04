using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductSelecter : MonoBehaviour
{
    [SerializeField] private Button[] _fructsButtonsActivators;
    [SerializeField] private ProductMover[] _productMovers;
    private int _indxActiveProduct;
    private IStartGame _startGame;

    private void Start()
    {
        _startGame = FindObjectOfType<GameState>().GetComponent<IStartGame>();
    }

    public void SetActiveButton(bool isActive) 
    {
        foreach(Button fructButtonActivator in _fructsButtonsActivators)
        {
            fructButtonActivator.gameObject.SetActive(isActive);
        }
    }

    public void ActiveProduct(int indxProduct)
    {
        _indxActiveProduct = indxProduct;
        _productMovers[_indxActiveProduct].SetActive(true);
        SetActiveButton(false);
        _startGame.ResetStateText();
    }

    public void DeactivateActiveProduct()
    {
        _productMovers[_indxActiveProduct].SetActive(false);
    }
}
