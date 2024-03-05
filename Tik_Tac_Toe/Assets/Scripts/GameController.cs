using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public int whoseTurn; //0 = x and 1 = o
    public int turnCount; //counr the number of turns played
    public GameObject[] turnicons; //displays whos turn it is
    public Sprite[] playerIcons; //0 = x icon and 1 = o icon
    public Button[] tictactoespaces; //playable space for our game


    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    void GameSetup()
    {
        whoseTurn = 0;
        turnCount = 0;
        turnicons[0].SetActive(true);
        turnicons[1].SetActive(false);
        for(int i = 0; i <tictactoespaces.Length; i++)
        {
            tictactoespaces[i].interactable = true;
            tictactoespaces[i].GetComponent<Image>().sprite = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TicTacToeButton(int WhichNumber)
    {
        tictactoespaces[WhichNumber].image.sprite = playerIcons[whoseTurn];
        tictactoespaces[WhichNumber].interactable = false;




        if(whoseTurn == 0)
        {
            whoseTurn = 1;
        }
        else
        {
            whoseTurn = 0;
        }
    }
}
