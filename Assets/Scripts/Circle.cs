using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    public CircleSize size;
    public int count = 3; // ��ʹ�õ�����,��Ĭ��Ϊ3��
    //public bool isDrag = true;
    //public CircleColor circleColor = CircleColor.Blue; // Ĭ��Ϊ��ɫ����


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
