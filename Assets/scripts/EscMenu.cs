using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EscMenu : MonoBehaviour
{


    public GameObject escMenu;


    public UnityEvent onMenuAppear;
    public UnityEvent onMenuDisppear;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscClick();
        
        }
    }

   public void OnEscClick()
    {
        if (escMenu.activeSelf == true)
        {

            escMenu.SetActive(false);
            Time.timeScale = 1;

            onMenuDisppear.Invoke();

        }
        else
        {
            escMenu.SetActive(true);
            Time.timeScale = 0;
            onMenuAppear.Invoke();
        }
    }





}
