using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject startGame;
    public GameObject arcadeMachine;
    public GameObject coinCounter;
    public GameObject howToPlay;
    public int menuNumber;

    // Start is called before the first frame update
    void Start()
    {
        coinCounter.SetActive(false);
    }

    // Update is called once per frame

    private void OnMouseDown()
    {
        if (menuNumber == 1)
        {
            startGame.GetComponent<Movement2D>().isPlaying = true;
            mainMenu.SetActive(false);
            coinCounter.SetActive(true);
        }
        if (menuNumber == 2)
        {
            howToPlay.SetActive(true);
            mainMenu.SetActive(false);
        }
        if (menuNumber == 3)
        {
            arcadeMachine.GetComponent<ChangeCamera>().leaveGame();
        }
        if (menuNumber == 4)
        {
            howToPlay.SetActive(false);
            mainMenu.SetActive(true);
        }



    }
}
