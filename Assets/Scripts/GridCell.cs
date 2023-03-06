using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridCell : MonoBehaviour
{
    private Vector3 zeroPos; // �������ԭ��λ��
    public bool outPos = true; // ������λ��
    public bool middlePos = true; // �м���λ��
    public bool innerPos = true; // ���ڲ��λ��

    public Transform zeroPoint;

    public static float CellSize;

    private void Awake()
    {
        zeroPoint = GameObject.Find("zeroPoint").transform;
        zeroPos = zeroPoint.position; // ��ȡԭ��λ��
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ��ȡ�����������е�λ��
    public Vector3 GetPostion()
    {
        return this.transform.position - zeroPos;
    }

    // �ܷ��������
    public bool IsExistSpace()
    {
        return true;
    }

    public void HighLight()
    {

    }


    public void Highlight()
    {
        this.GetComponent<Image>().color = Constant.gridHighlight;
    }

    public void Ordinarylight()
    {
        this.GetComponent<Image>().color = Constant.gridColor;
    }
}
