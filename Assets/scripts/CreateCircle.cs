using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCircle : MonoBehaviour
{
    public Image redCircle;
    public GameObject ArcadeMachine;

    // Start is called before the first frame update
    void Start()
    {
        redCircle.enabled = false;
    }

    // Update is called once per frame
    public void buttonClick()
    {
        redCircle.enabled = true;
        gameObject.GetComponent<Image>().enabled = false;
        gameObject.GetComponent<Button>().enabled = false;
        ArcadeMachine.GetComponent<SpotTheDifference>().Invoke("nextRound", 3);
        gameObject.GetComponent<AudioSource>().Play();
    }
}
