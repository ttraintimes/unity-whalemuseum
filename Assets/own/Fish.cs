using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public int Score = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UiManager.nowScore += Score;
            Destroy(this.gameObject);
        }
    }


}
