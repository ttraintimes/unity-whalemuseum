using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAIMovement : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject playerCharacter;
    public float AISpeed;
    public GameObject pausedGame;
    public SpriteRenderer enemySpriteRenderer;
    public bool isDead = false;
    public Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        AISpeed = agent.speed;
        startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if ((playerCharacter != null) && (pausedGame.GetComponent<ChangeCamera>().isGamePaused == false))
        {

            if (playerCharacter.GetComponent<Movement2D>().isPlaying == true)
            {
                agent.speed = AISpeed;
                agent.SetDestination(playerCharacter.transform.position);
            }
            else
            {
                agent.speed = 0;
                agent.SetDestination(gameObject.transform.position);
            }
        } else
        {
            agent.speed = 0;
            agent.SetDestination(gameObject.transform.position);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.name == "Player") && (isDead == false))
        {
            playerCharacter.GetComponent<Movement2D>().dead();
        }
    }
    public void dead()
    {
        agent.speed = 0;
        enemySpriteRenderer.enabled = false;
        agent.SetDestination(gameObject.transform.position);
        isDead = true;
    }
    public void resetEnemy()
    {
        gameObject.transform.position = startPosition;
        agent.speed = AISpeed;
        enemySpriteRenderer.enabled = true;
        isDead = false;
    }
}
