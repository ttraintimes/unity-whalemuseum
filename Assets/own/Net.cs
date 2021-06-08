using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour
{
    public int liveMinus = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UiManager.liveCount -= liveMinus;
            Destroy(this.gameObject);
        }
    }
}
