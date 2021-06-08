using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    GameObject raycastedObj;
    ObjectInteraction referencedScript;
    public Image crosshairNormal;
    public Image crosshairInteract;

    [SerializeField] private int InteractionRange = 10;
    [SerializeField] private LayerMask InteractableLayer;

    // Update is called once per frame


    void Start()
    {
        crosshairInteract.enabled = false;
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, InteractionRange, InteractableLayer.value))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                crosshairNormal.enabled = false;
                crosshairInteract.enabled = true;
                raycastedObj = hit.collider.gameObject;
                referencedScript = raycastedObj.GetComponent<ObjectInteraction>();

                if (Input.GetKeyDown("e") && (referencedScript != null))
                {
                    referencedScript.interact();
                    raycastedObj = null;
                    referencedScript = null;
                    raycastedObj = null;
                }
            }
        }
        else
        {
            crosshairNormal.enabled = true;
            crosshairInteract.enabled = false;
        }

    }
}
