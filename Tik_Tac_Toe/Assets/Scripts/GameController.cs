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
    public int[] markedSpaces; //ID's which space was marked by which player
    public TMP_Text WinnerText; //hold the text component of the winner text
    public GameObject[] winningLine; //holds all the different lines for showing that there is a winner


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
        for(int i = 0;i < markedSpaces.Length; i++)
        {
            markedSpaces[i] = -100;
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

        markedSpaces[WhichNumber] = whoseTurn+1;
        turnCount++;
        if(turnCount > 4)
        {
            WinnerCheck();
        }


        if(whoseTurn == 0)
        {
            whoseTurn = 1;
            turnicons[0].SetActive(false);
            turnicons[1].SetActive(true);
        }
        else
        {
            whoseTurn = 0;
            turnicons[0].SetActive(true);
            turnicons[1].SetActive(false);
        }
    }

    void WinnerCheck()
    {
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2]; // top row of 3x3 grid and adding them all together
        int s2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        int s3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];
        int s4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6];
        int s5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7];
        int s6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8];
        int s7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8];
        int s8 = markedSpaces[2] + markedSpaces[4] + markedSpaces[6];
        var solutions = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };
        for(int i = 0; i < solutions.Length; i++)
        {
            if (solutions[i] == 3*(whoseTurn+1)) 
            {
                WinnerDisplay(i);
                return;
            }
        }
    }

    void WinnerDisplay(int indexIn)
    {
        WinnerText.gameObject.SetActive(true);
        if(whoseTurn == 0)
        {
            WinnerText.text = "Player X Wins!";
        }
        else if (whoseTurn == 1)
        {
            WinnerText.text = "Player O Wins!";
        }
        winningLine[indexIn].SetActive(true);
        for(int i = 0; i <tictactoespaces.Length; i ++)
        {
            tictactoespaces[i].interactable = false;
        }
    }

}
