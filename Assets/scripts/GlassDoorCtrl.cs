using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlassDoorCtrl : MonoBehaviour
{

    public UnityEvent onOpen;
    public UnityEvent onClose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Triggered");
            onOpen.Invoke();
        }
       
    }
    private void OnTriggerExit(Collider other)
    {


        if (other.tag == "Player")
        {
            onClose.Invoke();
        }
     
    }
}
