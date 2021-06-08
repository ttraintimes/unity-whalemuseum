using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectColour : MonoBehaviour
{
    private ObjectInteraction interact;
    Renderer rend;
    private bool canInteract = true;


    void Start()
    {
        interact = GetComponent<ObjectInteraction>();
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if ((interact.triggered == true) && (canInteract == true))
        {
            canInteract = false;
            rend.material.SetColor("_Color", Color.red);
            Invoke("resetColour", 1);
            canInteract = false;
            interact.triggered = false;
            
        }
    }

    void resetColour()
    {
        rend.material.SetColor("_Color", Color.white);
        canInteract = true;
    }
}
