using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{

    public Slider mySlider;
    public static float aimVolume=-1;


    public AudioSource myAS;

   


    private void Start()
    {


        Time.timeScale = 1;
        if (aimVolume != -1)
        {

            myAS.volume = aimVolume;

            mySlider.value = aimVolume;
        }

        UnityAction<float> myUa ;
        myUa = SetVolume;


        mySlider.onValueChanged.AddListener(myUa); 
    }



    void SetVolume(float nowValue)
    {

        myAS.volume = nowValue;

        aimVolume = nowValue;


    }



   
}
