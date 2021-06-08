using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static int liveCount = 3;
    public static int nowScore = 0;
    public Text scoreShow;
    public Text liveShow;
    public GameObject gameOver;
    public GameObject success;
    public Transform way1;

    // Start is called before the first frame update
    void Start()
    {
        nowScore = 0;
        liveCount = 3;


        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        scoreShow.text = "Score: " + nowScore;
        liveShow.text = "Live: " + liveCount;
        if (liveCount < 0)
        {
            liveCount = 0;
        }

        if(liveCount == 0)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }

        if(nowScore >= 500)
        {
            Time.timeScale = 0;
            success.SetActive(true);
        }
    }


    public void Restart()
    {
        liveCount = 3;
        nowScore = 0;
        gameOver.SetActive(false);
        success.SetActive(false);
        Time.timeScale = 1;

    }

    public void Exit()
    {
        foreach (GameObject g in SceneManager.GetSceneByName("SampleSceneBuiltOn").GetRootGameObjects())
        {
            g.SetActive(true);          
        }
        Time.timeScale = 1;
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("DodgeHunters"));
        GameObject.Find("Mainmenu").SetActive(false);
       
    }
}