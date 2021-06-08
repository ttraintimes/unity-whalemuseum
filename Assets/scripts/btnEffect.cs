using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class btnEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        Vector3 effectScale = transform.localScale - new Vector3(0.2f, 0.2f, 0.2f);
        
        Tweener tweener = transform.DOScale(effectScale, 1f);
        
        tweener.SetLoops(-1, LoopType.Yoyo);
        tweener.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
