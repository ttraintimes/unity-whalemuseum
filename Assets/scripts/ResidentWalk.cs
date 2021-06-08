using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ResidentWalk : MonoBehaviour
{
    bool isArrived = false;
    NavMeshAgent residentNav;
    public Transform whale;

    public UnityEvent onAction;
    public UnityEvent onActionStop;
    public static bool couldAction = false;


    // Start is called before the first frame update
    void Start()
    {
        couldAction = false;
        residentNav = transform.GetComponent<NavMeshAgent>();

    }





    // Update is called once per frame
    void Update()
    {


        if (couldAction)
        {

            residentNav.enabled = true;
            onAction.Invoke();

        }
        else
        {
            onActionStop.Invoke();
        }






        if (residentNav.enabled && isArrived != true)
        {
            residentNav.destination = whale.position;

            if (Vector3.Distance(residentNav.destination , transform.position)<0.05f)
               
            {
                Debug.Log("  onPos ");
                isArrived = true;
                couldAction = false;
                //transform.GetComponent<Animator>().;
            }

        }




    }




}

