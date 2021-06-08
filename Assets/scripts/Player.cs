using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public List<GameObject> allEvent = new List<GameObject>();
    public GameObject gameOver;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(allEvent.Count == 0 && Talking.instance.nowIndex == -1)
        {
            gameOver.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "event")
        {

            if (allEvent.Count != 0 && allEvent[0].name == other.gameObject.name)
            {
                allEvent.RemoveAt(0);
                Talking.instance.StartNewScripts(other.gameObject.name);

                Destroy(other.gameObject);
            }
           
        }
    }
}
