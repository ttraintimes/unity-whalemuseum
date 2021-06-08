using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExhibitExit : MonoBehaviour
{

    public void ExitBtn()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.UnloadSceneAsync(y);
        foreach (GameObject g in SceneManager.GetSceneByName("SampleSceneBuiltOn").GetRootGameObjects())
        {
            g.SetActive(true);
        }
        
        GameObject.Find("Mainmenu").SetActive(false);
        Time.timeScale = 1;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("SampleSceneBuiltOn"));
    }

}
