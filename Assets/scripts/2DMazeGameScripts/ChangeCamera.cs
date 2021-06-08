using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ChangeCamera : MonoBehaviour
{

    private ObjectInteraction interact;
    public Camera newCamera;
    public GameObject playerMovement;
    public GameObject playerBody;
    public GameObject gamePlayer;
    public Canvas playerUI;
    public bool currentlyInGame = false;
    public bool isGamePaused;





    // Start is called before the first frame update
    void Start()
    {
        newCamera.enabled = false;
        interact = GetComponent<ObjectInteraction>();
        gamePlayer.GetComponent<Movement2D>().enabled = false;
        newCamera.GetComponent<AudioListener>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (interact.triggered == true)
        {
            playerMovement.GetComponent<FirstPersonController>().enabled = false;
            playerBody.GetComponent<Camera>().enabled = false;
            playerBody.GetComponent<AudioListener>().enabled = false;
            newCamera.enabled = true;
            newCamera.GetComponent<AudioListener>().enabled = true;
            gamePlayer.GetComponent<Movement2D>().enabled = true;
            currentlyInGame = true;
            playerUI.enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            isGamePaused = false;
        }

        if ((Input.GetKeyDown("f")) && (currentlyInGame == true))
        {
            leaveGame();
        }

   
    }

    public void leaveGame()
    {
        playerMovement.GetComponent<FirstPersonController>().enabled = true;
        playerBody.GetComponent<Camera>().enabled = true;
        playerBody.GetComponent<AudioListener>().enabled = true;
        newCamera.enabled = false;
        newCamera.GetComponent<AudioListener>().enabled = false;
        gamePlayer.GetComponent<Movement2D>().enabled = false;
        currentlyInGame = false;
        playerUI.enabled = true;
        isGamePaused = true;
    }
}
