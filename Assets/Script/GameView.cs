using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameObject gridPanel;
    private GridCell gridCell; // 目标位置的格子
    private Vector3 mousePos;
    private Vector3 circlePos;
    private Vector3 zeroPos;
    private float cellSize;
    private float gridPanelSize;
    private int row; // 网格的行数
    private int curRow;
    private int curCol;
    private Vector3 offsetCircleAndGrid;
    //private GridLayoutGroup gridLayoutGroup;

    public RectTransform Circle;
    public Transform zeroPoint;
    

    private void Awake()
    {
        
    }
    void Start()
    {
        gridPanel = GameObject.Find("Panel");
        gridPanelSize = gridPanel.GetComponent<RectTransform>().rect.width;
        cellSize = gridPanel.GetComponent<GridLayoutGroup>().cellSize.x;
        row = Mathf.RoundToInt(gridPanelSize / cellSize);
        zeroPos = zeroPoint.position;
    }

    void Update()
    {
        
    }

    


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("开始拖拽");
        circlePos = Circle.position;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(Circle, eventData.position, eventData.pressEventCamera, out mousePos); // 记录鼠标初始位置
        Debug.Log("原点位置：" + zeroPos);
        Debug.Log("鼠标初始位置：" + mousePos);
        Debug.Log("圆圈初始位置：" + circlePos);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 拖动棋子
        Vector3 newMousePos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(Circle, eventData.position, eventData.pressEventCamera, out newMousePos);
        Vector3 mouseOffset = new Vector3(newMousePos.x - mousePos.x, newMousePos.y - mousePos.y, 0); // 拖动过程中鼠标位置的偏移量
        Circle.position = circlePos + mouseOffset;

        Vector3 offsetMouseAndGrid = new Vector3(newMousePos.x - zeroPos.x, newMousePos.y - zeroPos.y, 0);
        offsetCircleAndGrid = new Vector3(Circle.position.x - zeroPos.x, Circle.position.y - zeroPos.y, 0);
        //Debug.Log("鼠标相对于格子的位置： " + offsetMouseAndGrid);
        //Debug.Log("圆圈相对于格子的位置： " + offsetCircleAndGrid);

        curRow = Mathf.RoundToInt(offsetCircleAndGrid.x / cellSize);
        curCol = Mathf.RoundToInt(offsetCircleAndGrid.y / cellSize);

        if (!(curRow > row - 1 || curRow < 0 || curCol > row - 1 || curCol < 0))
        {
            int gridIndex = curCol * row + curRow;
            gridCell = gridPanel.GetComponentsInChildren<Transform>()[gridIndex + 1].GetComponent<GridCell>(); // 获取panel中的子对象的GridCell组件
            //Debug.Log("当前块的索引： " + gridIndex + " 组件： " + gridPanel.GetComponentsInChildren<Transform>()[gridIndex + 1]);
            gridCell.Highlight();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("结束拖拽");
        if (curRow > row - 1 || curRow < 0 || curCol > row - 1 || curCol < 0)
        {
            Debug.Log("不在网格范围内！！");
            Circle.position = circlePos; // 超出范围，返回原位
        }
        else {
            Circle.position = Constant.posValue[curCol, curRow] + zeroPos; // 放置到格子中指定位置
            Debug.Log("目标行列：" + curRow + " " + curCol);
        }
        // 需要判断鼠标位置与目标位置的偏移，然后将棋子放在最近的位置上
        // 1. 若偏移已经远远超过最大偏移，那么棋子返回原位
        // 2. 若偏移在最大偏移范围内，则判断距离最近的可选的目标位置
        // 3. 最大偏移：距离所有可选目标位置的最大的偏移
    }
}
