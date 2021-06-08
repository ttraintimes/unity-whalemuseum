using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Text;
using System.IO;

public class chatSystem : MonoBehaviour
{
    public List<string> allstrs = new List<string>();
    public string path = "";

    [ContextMenu("MakeOneScript")]
    public void MakeOneScript()
    {
        ScriptInfo st = new ScriptInfo(allstrs);

        string jsonStr = JsonConvert.SerializeObject(st);
        Save(jsonStr,path);

    }



    // Start is called before the first frame update
    void Start()
    {
    }


    //read
    public static string Load(string path)
    {
        //FileMode.Open open the save.text file
        FileStream fs = new FileStream(Application.streamingAssetsPath + "/"+path+".txt", FileMode.Open);
        byte[] bytes = new byte[1024];
        fs.Read(bytes, 0, bytes.Length);
        //turn to strings
        string s = new UTF8Encoding().GetString(bytes);
        return s;
    }





    public static void Save(string jsonstr,string path)
    {
        StringBuilder sb = new StringBuilder(jsonstr);//state a string
       
        //write file save.text
        FileStream fs = new FileStream(Application.streamingAssetsPath + "/"+ path+".txt", FileMode.Create);
        byte[] bytes = new UTF8Encoding().GetBytes(sb.ToString());
        fs.Write(bytes, 0, bytes.Length);
        //close the file after read
        fs.Close();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}


public class ScriptInfo {
    public List<string> allTexts;
    public ScriptInfo(List<string> xx)
    {
        allTexts = xx;
    }

    



}


