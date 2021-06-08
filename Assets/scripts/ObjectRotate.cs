using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public float speed = 1.0f;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, -speed, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(0, 0, -speed);
        }

    }
}

