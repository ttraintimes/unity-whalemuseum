using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturePiece : MonoBehaviour
{
    private ObjectInteraction interact;
    public int photoNumber;


    private void Start()
    {
        interact = GetComponent<ObjectInteraction>();
    }

    private void Update()
    {
        if(interact.triggered == true)
        {
            transform.position = new Vector3(transform.parent.gameObject.GetComponent<PictureManager>().xValues[photoNumber]-31.5f, transform.parent.gameObject.GetComponent<PictureManager>().yValues[photoNumber]+1.5f, transform.parent.gameObject.GetComponent<PictureManager>().zValues[photoNumber]);
            gameObject.tag = "Untagged";
            transform.eulerAngles = new Vector3(0, 180, 0);
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
