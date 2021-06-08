using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public void startBtn()
    {
        SceneManager.LoadScene("SampleSceneBuiltOn");
    }

    public void quitBtn()
    {
        Application.Quit();
    }

}
