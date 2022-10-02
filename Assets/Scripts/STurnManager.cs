using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class STurnManager : MonoBehaviour
{
    private static STurnManager manager;

    [SerializeField] private SActivePlayer player1;
    [SerializeField] private SActivePlayer player2;
    [SerializeField] private float maxTimePerTurn;
    [SerializeField] private float timeBetweenTurns;
    [SerializeField] private Image clock;
    [SerializeField] private TextMeshProUGUI seconds;
   
    private Vector3 initialPosPlayer1 = new Vector3(10, 0, 10);
    private Vector3 initialPosPlayer2 = new Vector3(-10, 0, -10);
    private Vector3 initialRotPlayer1;
    private Vector3 initialRotPlayer2;


    private SActivePlayer currentPlayer;
   
    private float currentTurnTime;
    private float currentDelay;

    
    void Start()
    {
        player1.AssignManager(this);
        player2.AssignManager(this);

        currentPlayer = player1;

        player1.transform.position = initialPosPlayer1;
        player2.transform.position = initialPosPlayer2;
        player1.transform.eulerAngles = initialRotPlayer1;
        player2.transform.eulerAngles = initialRotPlayer2;

    }

    private void Update()
    {
        if (currentDelay <= 0)
        {
            currentTurnTime += Time.deltaTime;
            clock.fillAmount = 1 - (currentTurnTime / maxTimePerTurn);
            seconds.text = Mathf.RoundToInt(maxTimePerTurn - currentTurnTime).ToString();

            if (currentTurnTime >= maxTimePerTurn)
            {
                ChangeTurn();
                               
            }
        }
        else
        {
            currentDelay -= Time.deltaTime;
        }
    }

    public bool CanPlay()
    {
        return currentDelay <= 0;
    }


    public SActivePlayer GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public void ChangeTurn()
    {
        if(player1 == currentPlayer)
        {
            currentPlayer = player2;
        }
        else if(player2 == currentPlayer)
        {
            currentPlayer = player1;
        }
        currentTurnTime = 0;
        currentDelay = timeBetweenTurns;
    }
}
