using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CircleSize
{
    L,
    M,
    S
}

public class ChessPanel : MonoBehaviour
{
    private bool isOnLCircle;
    private bool isOnMCircle;
    private bool isOnSCircle;
    private Circle curCircle;

    public Circle lCircle;
    public Circle mCircle;
    public Circle sCircle;

    

    //public RectTransform circle;


    public void Init()
    {
        //lCircle.size = CircleSize.L;
        //mCircle.size = CircleSize.M;
        //sCircle.size = CircleSize.S;
        //RectTransform tempCircle =  Instantiate(circle, this.transform);
        //tempCircle.rect.width = Size.L
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Circle GetDragCircle()
    {

        isOnLCircle = RectTransformUtility.RectangleContainsScreenPoint(lCircle.GetComponent<RectTransform>(), Input.mousePosition);
        isOnMCircle = RectTransformUtility.RectangleContainsScreenPoint(mCircle.GetComponent<RectTransform>(), Input.mousePosition);
        isOnSCircle = RectTransformUtility.RectangleContainsScreenPoint(sCircle.GetComponent<RectTransform>(), Input.mousePosition);
        curCircle = isOnLCircle ? lCircle : (isOnMCircle ? mCircle : (isOnSCircle ? sCircle : null));
        Debug.Log("LÆå×Ó£º" + lCircle + " ³ß´ç: " + lCircle.tag);
        Debug.Log("mÆå×Ó£º" + mCircle + " ³ß´ç: " + mCircle.tag);
        Debug.Log("sÆå×Ó£º" + sCircle + " ³ß´ç: " + sCircle.tag);
        Debug.Log("µ±Ç°Æå×Ó£º" + curCircle + " ³ß´ç: " + curCircle.tag);
        return curCircle;
    }
}
