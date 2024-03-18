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
    public GameObject[] WinningLine; //holds all the different lines for showing that there is a winner
    public GameObject WinnerPanel;// screen that lets you not play after x/o wins
    public int xPLayersScore;
    public int oPLayersScore;
    public TMP_Text xplayersScoreText;
    public TMP_Text oplayersScoreText;
    public Button xPlayersButton;
    public Button oPlayerButton;
    public GameObject CatImage;


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
        xPlayersButton.interactable = false;
        oPlayerButton.interactable = false;
        tictactoespaces[WhichNumber].image.sprite = playerIcons[whoseTurn];
        tictactoespaces[WhichNumber].interactable = false;

        markedSpaces[WhichNumber] = whoseTurn+1;
        turnCount++;
        if(turnCount > 4)
        {
            bool isWinner = WinnerCheck();
            if (turnCount == 9 && isWinner == false)
            {
                 Cat();
            }
           

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

    bool WinnerCheck()
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
                return true;
            }
        }

        return false;
    }

    void WinnerDisplay(int indexIn)
    {
        WinnerPanel.gameObject.SetActive(true);
        if(whoseTurn == 0)
        {
            xPLayersScore++;
            xplayersScoreText.text = xPLayersScore.ToString();
            WinnerText.text = "Player X Wins!";
        }
        else if (whoseTurn == 1)
        {
            oPLayersScore++;
            oplayersScoreText.text = oPLayersScore.ToString();
            WinnerText.text = "Player O Wins!";
        }
        WinningLine[indexIn].SetActive(true);
        
    }
    public void Rematch()//forloop through the array and disable every element array within it
    {
        GameSetup();
        for(int i = 0;i <WinningLine.Length;i++)
        {
            WinningLine[i].SetActive(false);
        }
        WinnerPanel.SetActive(false);
        xPlayersButton.interactable = true;
        oPlayerButton.interactable = true;
        CatImage.SetActive(false);
    }
    public void Restart()
    {
        Rematch();
        xPLayersScore = 0;
        oPLayersScore = 0;
        xplayersScoreText.text = "0";
        oplayersScoreText.text = "0";
    }

    public void SwitchPlayer(int whichPlayer){

        if(whichPlayer == 0){
            
            whoseTurn = 0;
            turnicons[0].SetActive(true);
            turnicons[1].SetActive(false);
        }
        else if(whichPlayer == 1){
            
            whoseTurn = 1;
            turnicons[0].SetActive(false);
            turnicons[1].SetActive(true);
        }
    }

    void Cat()
    {
        WinnerPanel.SetActive(true);
        CatImage.SetActive(true);
        WinnerText.text = "CAT";
        
    }
}