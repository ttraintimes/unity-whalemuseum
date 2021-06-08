using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{

    public float speed = 1;
    public int coinsCollected;
    public TextMesh coinCounter;
    public TextMesh fLeave;
    private int coinCountMax;
    public bool isPlaying = false;
    public GameObject mainMenu;
    private SpriteRenderer whaleRenderer;
    public bool gameWon = false;
    private Vector3 startPosition;
    private bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        whaleRenderer = GetComponent<SpriteRenderer>();
        var coinNum = GameObject.FindGameObjectsWithTag("CoinCollectable");
        coinCountMax = coinNum.Length;
        coinCounter.text = "Coins collected =" + " " + coinsCollected.ToString() + "/" + coinCountMax;
        startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((isPlaying == true) && (alive == true))
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            transform.position += move * speed * Time.deltaTime;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if(Input.GetAxis("Horizontal") > 0)
            {
                whaleRenderer.flipX = true;
            } 
            if(Input.GetAxis("Horizontal") < 0)
            {
                whaleRenderer.flipX = false;
            }
        }
            if (Input.GetKeyDown("space") && ((gameWon == true) || (alive == false)))
            {
                resetGame();
            }
        }

    public void coinCountCheck()
    {   
        coinCounter.text = "Coins collected =" + " " + coinsCollected.ToString() + "/" + coinCountMax;
        if (coinsCollected == coinCountMax)
        {
            coinCounter.text = "You win! Press the space bar to play again";
            var enemies = GameObject.FindGameObjectsWithTag("enemy");
            for(int i= 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<SimpleAIMovement>().dead();
            }
            gameWon = true;
        }
    }

    public void startGame()
    {
        isPlaying = true;
        mainMenu.SetActive(false);
    }

    public void dead()
    {
        whaleRenderer.enabled = false;
        alive = false;
        coinCounter.text = "You got caught! Press the spacebar to try again";
    }

    public void resetGame()
    {
        gameObject.transform.position = startPosition;
        var collectables = GameObject.FindGameObjectsWithTag("CoinCollectable");
        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i].GetComponent<CollectableScript>().pickedUp = false;
            collectables[i].GetComponent<CollectableScript>().coinRenderer.enabled = true;
        }
        var enemies = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<SimpleAIMovement>().resetEnemy();
        }
        coinsCollected = 0;
        whaleRenderer.enabled = true;
        alive = true;
        whaleRenderer.flipX = false;
        coinCounter.text = "Coins collected =" + " " + coinsCollected.ToString() + "/" + coinCountMax;
    }

}
