using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public bool triggered = false;
    public float InteractionCoolDownTime = 0.1f;

    public void interact()
    {
        triggered = true;
        Invoke("interactionCooldown", InteractionCoolDownTime);
    }

    public void interactionCooldown()
    {
        triggered = false;
    }
}