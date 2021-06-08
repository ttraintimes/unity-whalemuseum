using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayMove : MonoBehaviour
{


   public float moveSpeed = 20;
    public Transform way1;
    public Transform way2;



   // private Vector3 aimPos;


    float twoWayDis;





    void ReSetWay()
    {

        way1.GetComponent<StuffManager>().ResetStuff();


    }


    // Start is called before the first frame update
    void Start()
    {
       // aimPos = way1.position;
        twoWayDis = way1.position.z - way2.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,0,Time.deltaTime*moveSpeed);



        if (way2.position.z>=Whale.instance.transform.position.z)
        {
            //aimPos = way2.position;
           
            way1.position -= new Vector3(0, 0, twoWayDis*2);
            ReSetWay();
            Transform tempWay = way2;


            way2 = way1;
            way1 = tempWay;
            
        }

    }
}
