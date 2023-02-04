using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public interface IStartGame
{
    void ResetStateText();
} 

public class GameState : MonoBehaviour, IStartGame
{
    [SerializeField] private TMP_Text _gameStateText;
    [SerializeField] private Button _restartButton;
    private ProductSelecter _productSelecter;
    
    private void Start()
    {
        _productSelecter = FindObjectOfType<ProductSelecter>();
        _restartButton.onClick.AddListener(RestartGame);
        ResetStateText();
        RestartGame();
    }

    private void RestartGame()
    {
        _productSelecter.SetActiveButton(true);
        _restartButton.gameObject.SetActive(false);
    }

    public void ResetStateText()
    {
        _gameStateText.text = "";
    }

    public void Win()
    {
        _gameStateText.text = "Great!";
        _productSelecter.DeactivateActiveProduct();
        _productSelecter.SetActiveButton(true);
    }

    public void Cut()
    {
        _gameStateText.text = "Cut!";
        _productSelecter.DeactivateActiveProduct();
        _restartButton.gameObject.SetActive(true);
    }

}
