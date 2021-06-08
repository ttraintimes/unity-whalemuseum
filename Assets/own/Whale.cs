using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : MonoBehaviour
{


   

    public float jumpForce=20;
    private float leftXValue = 3.333334f;
    private float rightXValue = -3.333334f;
    Rigidbody rigForJump;

    public static Whale instance;


    Vector3 aimPos;





    // Start is called before the first frame update
    void Awake()
    {

        rigForJump = transform.parent.GetComponent<Rigidbody>();

        instance = this;
        aimPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {


        if (aimPos.x==0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                aimPos = new Vector3(leftXValue, transform.localPosition.y, transform.localPosition.z);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                aimPos = new Vector3(rightXValue, transform.localPosition.y, transform.localPosition.z);
            }
        }
        else if (aimPos.x>0)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                aimPos = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                aimPos = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
            }

        }




        if (Input.GetKeyDown(KeyCode.UpArrow)&&transform.parent.localPosition.y<= 27)
           
        {
            rigForJump.velocity += new Vector3(0, jumpForce, 0);
        }




        transform.localPosition = Vector3.LerpUnclamped(transform.localPosition, aimPos, 0.2f);


       // transform.localPosition = aimPos;

    }


   


}
