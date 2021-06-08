using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class SpotTheDifference : MonoBehaviour
{
    private ObjectInteraction interact;
    public GameObject spotTheDifferenceGame;
    public Camera gameCamera;
    public GameObject playerMovement;
    public GameObject playerBody;
    public Canvas playerUI;
    public GameObject round1;
    public GameObject round2;
    public GameObject round3;
    public GameObject mainMenu;
    public GameObject gameBasics;
    public GameObject howToPlayScreen;
    public GameObject victoryScreen;
    public Text roundNumber;
    public Text differencesCounter;
    private bool ingame = false;

    public int differencesLeft;
    public int roundNumberNumber;

    // Start is called before the first frame update
    void Start()
    {
        interact = GetComponent<ObjectInteraction>();
        spotTheDifferenceGame.SetActive(false);
        gameCamera.enabled = false;
        gameCamera.GetComponent<AudioListener>().enabled = false;
        round1.SetActive(false);
        round2.SetActive(false);
        round3.SetActive(false);
        gameBasics.SetActive(false);
        victoryScreen.SetActive(false);
        howToPlayScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (interact.triggered == true)
        {
            playerMovement.GetComponent<FirstPersonController>().enabled = false;
            spotTheDifferenceGame.SetActive(true);
            gameCamera.enabled = true;
            playerBody.GetComponent<Camera>().enabled = false;
            playerBody.GetComponent<AudioListener>().enabled = false;
            gameCamera.GetComponent<AudioListener>().enabled = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            playerUI.enabled = false;
        }
        roundNumber.text = "Round" + " " + roundNumberNumber;
        differencesCounter.text = differencesLeft + " " + "differences left";
    }

    public void leaveGame()
    {
        playerMovement.GetComponent<FirstPersonController>().enabled = true;
        playerBody.GetComponent<Camera>().enabled = true;
        playerBody.GetComponent<AudioListener>().enabled = true;
        gameCamera.enabled = false;
        gameCamera.GetComponent<AudioListener>().enabled = false;
        playerUI.enabled = true;
        spotTheDifferenceGame.SetActive(false);
    }

    public void startGame()
    {
        ingame = true;
        round1.SetActive(true);
        round2.SetActive(false);
        round3.SetActive(false);
        gameBasics.SetActive(true);
        mainMenu.SetActive(false);
        roundNumberNumber = 1;
        
        var Buttons = GameObject.FindGameObjectsWithTag("Buttons");
        for (int i = 0; i < Buttons.Length; i++)
        {
            differencesLeft = Buttons.Length;
        }

    }

    public void HowToPlay()
    {
        howToPlayScreen.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void decreaseDifferencesTotal()
    {
        differencesLeft--;
    }

    public void nextRound()
    {
        if (ingame == true)
        {
            if (differencesLeft == 0)
            {

                if (roundNumberNumber < 4)
                {
                    gameObject.GetComponent<AudioSource>().Play();
                }

                roundNumberNumber++;
                if (roundNumberNumber == 2)
                {
                    round1.SetActive(false);
                    round2.SetActive(true);
                    var Buttons = GameObject.FindGameObjectsWithTag("Buttons");
                    for (int i = 0; i < Buttons.Length; i++)
                    {
                        differencesLeft = Buttons.Length;
                    }
                }
                if (roundNumberNumber == 3)
                {
                    round2.SetActive(false);
                    round3.SetActive(true);
                    var Buttons = GameObject.FindGameObjectsWithTag("Buttons");
                    for (int i = 0; i < Buttons.Length; i++)
                    {
                        differencesLeft = Buttons.Length;
                    }
                }
                if (roundNumberNumber == 4)
                {
                    round1.SetActive(true);
                    round2.SetActive(true);
                    round3.SetActive(true);
                    var Buttons = GameObject.FindGameObjectsWithTag("Buttons");
                    for (int i = 0; i < Buttons.Length; i++)
                    {
                        Buttons[i].GetComponent<CreateCircle>().redCircle.enabled = false;
                        Buttons[i].GetComponent<Image>().enabled = true;
                        Buttons[i].GetComponent<Button>().enabled = true;
                    }
                    round1.SetActive(false);
                    round2.SetActive(false);
                    round3.SetActive(false);
                    gameBasics.SetActive(false);
                    victoryScreen.SetActive(true);
                }


            }
        }
    }

    public void returnToMenu()
    {
        mainMenu.SetActive(true);
        victoryScreen.SetActive(false);
        howToPlayScreen.SetActive(false);
        round1.SetActive(true);
        round2.SetActive(true);
        round3.SetActive(true);
        var Buttons = GameObject.FindGameObjectsWithTag("Buttons");
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].GetComponent<CreateCircle>().redCircle.enabled = false;
            Buttons[i].GetComponent<Image>().enabled = true;
            Buttons[i].GetComponent<Button>().enabled = true;
        }
        round1.SetActive(false);
        round2.SetActive(false);
        round3.SetActive(false);
        gameBasics.SetActive(false);
        ingame = false;
    }
    public void playAgain()
    {
        startGame();
        victoryScreen.SetActive(false);
    }

}
