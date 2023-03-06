using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPanel : MonoBehaviour
{
    private Transform[] circleTypes;
    private bool isOnLCircle;
    private bool isOnMCircle;
    private bool isOnSCircle;
    private Circle curCircle;

    public Circle lCircle;
    public Circle mCircle;
    public Circle sCircle;
    

    public enum Color
    {
        Blue,
        Red
    }

    public enum Size
    {
        L = 115,
        M = 75,
        S = 45
    }

    public RectTransform circle;


    public void Init()
    {
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
        return curCircle;
    }
}
