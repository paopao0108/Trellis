using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    public CircleSize size;
    public int count = 3; // 可使用的数量,，默认为3个
    //public bool isDrag = true;
    //public CircleColor circleColor = CircleColor.Blue; // 默认为蓝色棋子


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Disable()
    {
        this.GetComponent<Image>().color = Constant.disableColor;
    }
}
