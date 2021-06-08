using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StuffManager : MonoBehaviour
{


    public GameObject[] allStuffModel;


    private Transform stuffLinesParent;
    private List<Transform> allStuffLines=new List<Transform>();



    private List<GameObject> allCreatedStuff = new List<GameObject>();

    private void Awake()
    {
        stuffLinesParent = transform.Find("AllStuffLines");
        //allStuffLines = stuffLinesParent.GetComponentsInChildren<Transform>().ToList();

        for (int i = 0; i < stuffLinesParent.childCount; i++)
        {
            allStuffLines.Add(stuffLinesParent.GetChild(i));
        }

        
        ResetStuff();

    }


    public void ResetStuff()
    {


        foreach (GameObject item in allCreatedStuff)
        {
            Destroy(item);
        
        }

        allCreatedStuff.Clear();



        foreach (Transform item in allStuffLines)
        {

            int randomNum = Random.Range(0,3);
            switch (randomNum)
            {
                case 0:
                    continue;
                case 1:
                    
                   
                    Transform aimTrans = item.GetChild(Random.Range(0, item.childCount));

                    GameObject nowStuff = Instantiate(allStuffModel[Random.Range(0, allStuffModel.Length)], aimTrans);
                    allCreatedStuff.Add(nowStuff);
                    nowStuff.transform.localPosition = Vector3.zero;
                    break;

                case 2:
                    List<int> existNum = new List<int>();
                    for (int i = 0; i < item.childCount; i++)
                    {
                        existNum.Add(i);
                    }

                    int tempIndex = Random.Range(0, existNum.Count);
                    int nowIndex = existNum[tempIndex];
                    existNum.RemoveAt(tempIndex);
                    Transform aimTrans2 = item.GetChild(nowIndex);
                    GameObject nowStuff2 = Instantiate(allStuffModel[Random.Range(0, allStuffModel.Length)], aimTrans2);
                    allCreatedStuff.Add(nowStuff2);
                    nowStuff2.transform.localPosition = Vector3.zero;

                     tempIndex = Random.Range(0, existNum.Count);
                     nowIndex = existNum[tempIndex];
                    existNum.RemoveAt(tempIndex);
                     aimTrans2 = item.GetChild(nowIndex);
                     nowStuff2 = Instantiate(allStuffModel[Random.Range(0, allStuffModel.Length)], aimTrans2);
                    allCreatedStuff.Add(nowStuff2);
                    nowStuff2.transform.localPosition = Vector3.zero;


                    break;
                default:
                    continue;

            }



            

        }
    }
}
