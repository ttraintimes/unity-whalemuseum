using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.Events;

public class Talking : MonoBehaviour
{


    public UnityEvent onTalkStart;
    public UnityEvent onTalkEnd;
  


    public Text myTalkingText;

    private ScriptInfo aimScriptInfo;

    public int nowIndex = 0;

    public string scriptPath= "myScripts / first";


    public static Talking instance;



    private void Start()
    {
        instance = this;
    }

    public void StartNewScripts(string _scriptPath)
    {

        nowIndex = 0;
        string aimJsonStr = chatSystem.Load(_scriptPath);
        Debug.Log(aimJsonStr);
        aimScriptInfo = JsonConvert.DeserializeObject<ScriptInfo>(aimJsonStr);
        Debug.Log(aimScriptInfo.allTexts.Count);
        myTalkingText.text = aimScriptInfo.allTexts[nowIndex];
        gameObject.SetActive(true);
        onTalkStart.Invoke();
        switch (_scriptPath)
        {
            case "myScripts/fourth":
                ResidentWalk.couldAction = true;
                break;
            default:
                break;
        }
    }



    // Start is called before the first frame update
     public  void ShowNextTalkStr()
    {
        nowIndex = nowIndex + 1 < aimScriptInfo.allTexts.Count ? nowIndex + 1 : -1;
        if (nowIndex != -1)
        {
            myTalkingText.text = aimScriptInfo.allTexts[nowIndex];
        }
        else
        {
            onTalkEnd.Invoke();
           
            this.gameObject.SetActive(false);
        
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
