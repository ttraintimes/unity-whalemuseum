using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MouseSpeed : MonoBehaviour
{
    public Slider mySlider;

    public FirstPersonController fpc;

    private void Start()
    {
        UnityAction<float> myUa;
        myUa = SetMouseSpeed;
       


        mySlider.onValueChanged.AddListener(myUa);
    
    }


    void SetMouseSpeed(float value)
    {
       fpc.m_MouseLook.XSensitivity = 2 * value;
       fpc.m_MouseLook.YSensitivity = 2 * value;           
    }
}
