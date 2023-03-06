using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 curCirclePos;
    private Vector3 mousePos;
    private Vector3 circlePosInPanel; // 圆圈棋子在面板中的位置
    private int curRow;
    private int curCol;
    private RectTransform curCircleClone;
    private bool isOnUI;
    private Circle curCircle;


    //public RectTransform largeCircle;
    public ZeroPoint zeroPoint;
    public GamePanel gamePanel;
    public ChessPanel chessPanel;
    
    //public int circleCount = 3;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        curCircle = chessPanel.GetDragCircle();
        Debug.Log("当前的棋子是：" + curCircle);
        isOnUI = RectTransformUtility.RectangleContainsScreenPoint(curCircle.GetComponent<RectTransform>(), Input.mousePosition);
        if (isOnUI && curCircle.count > 0)
        {
            Debug.Log("开始拖拽");
            curCirclePos = curCircle.GetComponent<RectTransform>().position;
            curCircleClone = Instantiate(curCircle.GetComponent<RectTransform>(), curCircle.GetComponent<RectTransform>().parent);
            RectTransformUtility.ScreenPointToWorldPointInRectangle(curCircleClone, eventData.position, eventData.pressEventCamera, out mousePos); // 记录鼠标初始位置
            Debug.Log("circleCount：" + curCircle.count);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isOnUI && curCircle.count > 0)
        {
            // 拖动棋子
            Vector3 newMousePos;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(curCircleClone, eventData.position, eventData.pressEventCamera, out newMousePos);
            Vector3 mouseOffset = new Vector3(newMousePos.x - mousePos.x, newMousePos.y - mousePos.y, 0); // 拖动过程中鼠标位置的偏移量
            curCircleClone.position = curCirclePos + mouseOffset;

            circlePosInPanel = new Vector3(curCircleClone.position.x - zeroPoint.Pos.x, curCircleClone.position.y - zeroPoint.Pos.y, 0);
            //Debug.Log("鼠标相对于格子的位置： " + offsetMouseAndGrid);
            //Debug.Log("圆圈的位置： " + curCircleClone.position);
            //Debug.Log("原点的位置： " + zeroPoint.Pos);
            //Debug.Log("圆圈相对于格子面板的位置： " + circlePosInPanel);

            curRow = Mathf.RoundToInt(circlePosInPanel.x / GridCell.CellSize);
            curCol = Mathf.RoundToInt(circlePosInPanel.y / GridCell.CellSize);
            Debug.Log("目标行列：" + curRow + " " + curCol);

            // 目标格子高亮显示 
            if (!(curRow > gamePanel.row - 1 || curRow < 0 || curCol > gamePanel.row - 1 || curCol < 0))
            {
                //GamePanel.grids[curCol][curRow].HighLight();
                //int gridIndex = curCol * row + curRow;
                //grid = gridPanel.GetComponentsInChildren<Transform>()[gridIndex + 1].GetComponent<GridCell>(); // 获取panel中的子对象的GridCell组件
                ////Debug.Log("当前块的索引： " + gridIndex + " 组件： " + gridPanel.GetComponentsInChildren<Transform>()[gridIndex + 1]);
                //grid.Highlight();
            }
            else
            {
                Debug.Log("不在网格范围内！！");
            }
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isOnUI && curCircle.count > 0)
        {
            Debug.Log("结束拖拽");
            if (curRow > gamePanel.row - 1 || curRow < 0 || curCol > gamePanel.row - 1 || curCol < 0) { putCircleInChess(); }
            else
            {
                // 在网格范围内，但该位置已被使用
                Debug.Log("棋子尺寸：" + curCircle.tag);
                switch (curCircle.tag)
                {
                    case "L":
                        if (GamePanel.grids[curCol][curRow].outPos) // 有位置
                        {
                            putCircleInGrid();
                            GamePanel.grids[curCol][curRow].outPos = false;
                        }
                        else putCircleInChess(); // 没位置
                        break;
                    case "M":
                        if (GamePanel.grids[curCol][curRow].middlePos)
                        {
                            putCircleInGrid();
                            GamePanel.grids[curCol][curRow].middlePos = false;
                        }
                        else putCircleInChess();
                        break;
                    case "S":
                        if (GamePanel.grids[curCol][curRow].innerPos)
                        {
                            putCircleInGrid();
                            GamePanel.grids[curCol][curRow].innerPos = false;
                        }
                        else putCircleInChess();
                        break;
                }
            }
        }
    }

    // 棋子放置在格子中
    public void putCircleInGrid()
    {
        curCircleClone.transform.parent = GamePanel.grids[curCol][curRow].transform;
        curCircleClone.transform.localPosition = new Vector3(0, 0, 0);
        curCircleClone.GetComponent<Circle>().Disable();
        //curCircle.GetComponent<Circle>().isDrag = false;
        Debug.Log("目标行列：" + curRow + " " + curCol);

        if (--curCircle.count == 0) curCircle.Disable();
    }

    // 棋子退回原位
    public void putCircleInChess()
    {
        Debug.Log("不在网格范围内！！");
        curCircleClone.position = curCirclePos; // 超出范围，返回原位
        GameObject.Destroy(curCircleClone.gameObject);// 销毁没有使用的圆圈棋子
    }
}
