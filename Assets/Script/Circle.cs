using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    public enum Color {
        Blue,
        Red
    }
    private float size;

    public int count; // ��ʹ�õ�����,��Ĭ��Ϊ3��
    public bool isDrag = true;

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
