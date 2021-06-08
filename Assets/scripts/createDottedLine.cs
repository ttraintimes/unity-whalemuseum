using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createDottedLine : MonoBehaviour
{
    private Vector3 startingPosition;
    private Vector3 endPosition;
    public GameObject tutorialManager;
    public GameObject dashLineObject;
    public GameObject targetArrow;
    public GameObject player;
    public float lineSpeed = 4;
    public float lineCreationRate = 0.9f;
    public Vector3[] tutorialPostions;
    private bool canTrigger = true;
    private int triggerNumber = 0;
    public Text tutorialTextChange;
    public string[] tutorialHelp;
    public Image textBackground;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingPosition.y = transform.position.y - 1.2f;
        endPosition = targetArrow.transform.position;
        endPosition.y = transform.position.y - 1.2f;
        Invoke("createDashLine", lineCreationRate);
        tutorialPostions[triggerNumber] = endPosition;
       

      

    }

    // Update is called once per frame
    void Update()
    {
        targetArrow.transform.LookAt(player.transform.position);
        if ((player.transform.position.x > targetArrow.transform.position.x - 1) && (player.transform.position.x < targetArrow.transform.position.x + 1) && (player.transform.position.z > targetArrow.transform.position.z - 1) && (player.transform.position.z < targetArrow.transform.position.z + 1) && (canTrigger == true))
        {
            canTrigger = false;
            startingPosition = tutorialPostions[triggerNumber];
            startingPosition.y = transform.position.y - 8f;
            if (triggerNumber > 5)
            {
                startingPosition.y = transform.position.y - 4.8f;
            }
            triggerNumber++;
            targetArrow.transform.position = tutorialPostions[triggerNumber];
            endPosition = tutorialPostions[triggerNumber];
            endPosition.y = tutorialPostions[triggerNumber].y - 1.2f;
            Invoke("TriggerReset", 0.2f);
            tutorialTextChange.text = tutorialHelp[triggerNumber];
            if (triggerNumber == tutorialPostions.Length - 1)
            {
                Destroy(textBackground);
                Destroy(tutorialTextChange);
                Destroy(tutorialManager);
            }
        }
    
     
    }

    

    void createDashLine()
    {
        if (triggerNumber > 0)
        {
            var myNewSmoke = Instantiate(dashLineObject, startingPosition, Quaternion.identity);
            myNewSmoke.transform.parent = gameObject.transform;
            myNewSmoke.GetComponent<TutorialDashLine>().targetPosition = endPosition;
            myNewSmoke.GetComponent<TutorialDashLine>().speed = lineSpeed;
           
        }
        Invoke("createDashLine", lineCreationRate);
    }

    void TriggerReset()
    {
        canTrigger = true;
    }
}
