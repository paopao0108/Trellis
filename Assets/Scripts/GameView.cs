using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 curCirclePos;
    private Vector3 mousePos;
    private Vector3 circlePosInPanel; // ԲȦ����������е�λ��
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
        Debug.Log("��ǰ�������ǣ�" + curCircle);
        isOnUI = RectTransformUtility.RectangleContainsScreenPoint(curCircle.GetComponent<RectTransform>(), Input.mousePosition);
        if (isOnUI && curCircle.count > 0)
        {
            Debug.Log("��ʼ��ק");
            curCirclePos = curCircle.GetComponent<RectTransform>().position;
            curCircleClone = Instantiate(curCircle.GetComponent<RectTransform>(), curCircle.GetComponent<RectTransform>().parent);
            RectTransformUtility.ScreenPointToWorldPointInRectangle(curCircleClone, eventData.position, eventData.pressEventCamera, out mousePos); // ��¼����ʼλ��
            Debug.Log("circleCount��" + curCircle.count);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isOnUI && curCircle.count > 0)
        {
            // �϶�����
            Vector3 newMousePos;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(curCircleClone, eventData.position, eventData.pressEventCamera, out newMousePos);
            Vector3 mouseOffset = new Vector3(newMousePos.x - mousePos.x, newMousePos.y - mousePos.y, 0); // �϶����������λ�õ�ƫ����
            curCircleClone.position = curCirclePos + mouseOffset;

            circlePosInPanel = new Vector3(curCircleClone.position.x - zeroPoint.Pos.x, curCircleClone.position.y - zeroPoint.Pos.y, 0);
            //Debug.Log("�������ڸ��ӵ�λ�ã� " + offsetMouseAndGrid);
            //Debug.Log("ԲȦ��λ�ã� " + curCircleClone.position);
            //Debug.Log("ԭ���λ�ã� " + zeroPoint.Pos);
            //Debug.Log("ԲȦ����ڸ�������λ�ã� " + circlePosInPanel);

            curRow = Mathf.RoundToInt(circlePosInPanel.x / GridCell.CellSize);
            curCol = Mathf.RoundToInt(circlePosInPanel.y / GridCell.CellSize);
            Debug.Log("Ŀ�����У�" + curRow + " " + curCol);

            // Ŀ����Ӹ�����ʾ 
            if (!(curRow > gamePanel.row - 1 || curRow < 0 || curCol > gamePanel.row - 1 || curCol < 0))
            {
                //GamePanel.grids[curCol][curRow].HighLight();
                //int gridIndex = curCol * row + curRow;
                //grid = gridPanel.GetComponentsInChildren<Transform>()[gridIndex + 1].GetComponent<GridCell>(); // ��ȡpanel�е��Ӷ����GridCell���
                ////Debug.Log("��ǰ��������� " + gridIndex + " ����� " + gridPanel.GetComponentsInChildren<Transform>()[gridIndex + 1]);
                //grid.Highlight();
            }
            else
            {
                Debug.Log("��������Χ�ڣ���");
            }
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isOnUI && curCircle.count > 0)
        {
            Debug.Log("������ק");
            if (curRow > gamePanel.row - 1 || curRow < 0 || curCol > gamePanel.row - 1 || curCol < 0) { putCircleInChess(); }
            else
            {
                // ������Χ�ڣ�����λ���ѱ�ʹ��
                Debug.Log("���ӳߴ磺" + curCircle.tag);
                switch (curCircle.tag)
                {
                    case "L":
                        if (GamePanel.grids[curCol][curRow].outPos) // ��λ��
                        {
                            putCircleInGrid();
                            GamePanel.grids[curCol][curRow].outPos = false;
                        }
                        else putCircleInChess(); // ûλ��
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

    // ���ӷ����ڸ�����
    public void putCircleInGrid()
    {
        curCircleClone.transform.parent = GamePanel.grids[curCol][curRow].transform;
        curCircleClone.transform.localPosition = new Vector3(0, 0, 0);
        curCircleClone.GetComponent<Circle>().Disable();
        //curCircle.GetComponent<Circle>().isDrag = false;
        Debug.Log("Ŀ�����У�" + curRow + " " + curCol);

        if (--curCircle.count == 0) curCircle.Disable();
    }

    // �����˻�ԭλ
    public void putCircleInChess()
    {
        Debug.Log("��������Χ�ڣ���");
        curCircleClone.position = curCirclePos; // ������Χ������ԭλ
        GameObject.Destroy(curCircleClone.gameObject);// ����û��ʹ�õ�ԲȦ����
    }
}
