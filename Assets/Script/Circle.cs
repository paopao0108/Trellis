using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    

    //private float size;

    public int count = 3; // ��ʹ�õ�����,��Ĭ��Ϊ3��
    //public bool isDrag = true;

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
