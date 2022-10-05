using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STestButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private STurnManager manager;

    private void Start()
    {
        button.onClick.AddListener(ButtonPressed);
    }

    public void ButtonPressed()
    {
       SActivePlayer currentPlayer = manager.GetCurrentPlayer();
       currentPlayer.ButtonTurnChange();
    }
}
