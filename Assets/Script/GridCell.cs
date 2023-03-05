using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridCell : MonoBehaviour
{
    private Vector3 zeroPos; // 网格面板原点位置
    private bool outPos; // 最外层的位置
    private bool middlePos; // 中间层的位置
    private bool innerPos; // 最内层的位置

    public Transform zeroPoint;

    public static float CellSize;

    private void Awake()
    {
        zeroPoint = GameObject.Find("zeroPoint").transform;
        zeroPos = zeroPoint.position; // 获取原点位置
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 获取格子在网格中的位置
    public Vector3 GetPostion()
    {
        return this.transform.position - zeroPos;
    }

    // 能否放置棋子
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
