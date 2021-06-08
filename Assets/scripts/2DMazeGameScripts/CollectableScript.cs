using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer coinRenderer;
    public bool pickedUp = false;


    private void Start()
    {
        coinRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.name == "Player") && (pickedUp == false))
        {
            player.GetComponent<Movement2D>().coinsCollected++;
            player.GetComponent<Movement2D>().coinCountCheck();
            coinRenderer.enabled = false;
            pickedUp = true;
        }
    }
}
