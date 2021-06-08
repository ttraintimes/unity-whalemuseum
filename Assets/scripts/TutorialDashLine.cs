using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDashLine : MonoBehaviour
{

    public Vector3 startingPosition;
    public GameObject targetObject;
    public Vector3 targetPosition;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = this.transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime * 2;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        transform.LookAt(targetPosition);
        if((transform.position.x < targetPosition.x + 0.1f) && (transform.position.x > targetPosition.x - 0.1f) && (transform.position.z < targetPosition.z + 0.1f) && (transform.position.z > targetPosition.z - 0.1f))
        {
            Destroy(gameObject);
        }
    }
}
