using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : MonoBehaviour
{
    public Animator openDoor;
    private ObjectInteraction interact;
    private bool isDoorOpen = false;
    private bool canTrigger = true;

    // Start is called before the first frame update
    void Start()
    {
       openDoor = openDoor.GetComponent<Animator>();
       interact = GetComponent<ObjectInteraction>();
        openDoor.SetBool("Open", false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((interact.triggered == true) && (canTrigger == true))
        {
            if (isDoorOpen == true)
            {
                openDoor.SetBool("Open", true);
                openDoor.SetTrigger("Interacted");
                isDoorOpen = false;
                canTrigger = false;
                Invoke("timer", 1);
            } else
            {
                openDoor.SetBool("Open", false);
                openDoor.SetTrigger("Interacted");
                isDoorOpen = true;
                canTrigger = false;
                Invoke("timer", 1.5f);
            }
          
        }
    }

    void timer()
    {
        canTrigger = true;
    }
}
