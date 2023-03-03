using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameObject gridPanel;
    private GridCell gridCell; // Ŀ��λ�õĸ���
    private Vector3 mousePos;
    private Vector3 circlePos;
    private Vector3 zeroPos;
    private float cellSize;
    private float gridPanelSize;
    private int row; // ���������
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
        Debug.Log("��ʼ��ק");
        circlePos = Circle.position;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(Circle, eventData.position, eventData.pressEventCamera, out mousePos); // ��¼����ʼλ��
        Debug.Log("ԭ��λ�ã�" + zeroPos);
        Debug.Log("����ʼλ�ã�" + mousePos);
        Debug.Log("ԲȦ��ʼλ�ã�" + circlePos);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // �϶�����
        Vector3 newMousePos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(Circle, eventData.position, eventData.pressEventCamera, out newMousePos);
        Vector3 mouseOffset = new Vector3(newMousePos.x - mousePos.x, newMousePos.y - mousePos.y, 0); // �϶����������λ�õ�ƫ����
        Circle.position = circlePos + mouseOffset;

        Vector3 offsetMouseAndGrid = new Vector3(newMousePos.x - zeroPos.x, newMousePos.y - zeroPos.y, 0);
        offsetCircleAndGrid = new Vector3(Circle.position.x - zeroPos.x, Circle.position.y - zeroPos.y, 0);
        //Debug.Log("�������ڸ��ӵ�λ�ã� " + offsetMouseAndGrid);
        //Debug.Log("ԲȦ����ڸ��ӵ�λ�ã� " + offsetCircleAndGrid);

        curRow = Mathf.RoundToInt(offsetCircleAndGrid.x / cellSize);
        curCol = Mathf.RoundToInt(offsetCircleAndGrid.y / cellSize);

        if (!(curRow > row - 1 || curRow < 0 || curCol > row - 1 || curCol < 0))
        {
            int gridIndex = curCol * row + curRow;
            gridCell = gridPanel.GetComponentsInChildren<Transform>()[gridIndex + 1].GetComponent<GridCell>(); // ��ȡpanel�е��Ӷ����GridCell���
            //Debug.Log("��ǰ��������� " + gridIndex + " ����� " + gridPanel.GetComponentsInChildren<Transform>()[gridIndex + 1]);
            gridCell.Highlight();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("������ק");
        if (curRow > row - 1 || curRow < 0 || curCol > row - 1 || curCol < 0)
        {
            Debug.Log("��������Χ�ڣ���");
            Circle.position = circlePos; // ������Χ������ԭλ
        }
        else {
            Circle.position = Constant.posValue[curCol, curRow] + zeroPos; // ���õ�������ָ��λ��
            Debug.Log("Ŀ�����У�" + curRow + " " + curCol);
        }
        // ��Ҫ�ж����λ����Ŀ��λ�õ�ƫ�ƣ�Ȼ�����ӷ��������λ����
        // 1. ��ƫ���Ѿ�ԶԶ�������ƫ�ƣ���ô���ӷ���ԭλ
        // 2. ��ƫ�������ƫ�Ʒ�Χ�ڣ����жϾ�������Ŀ�ѡ��Ŀ��λ��
        // 3. ���ƫ�ƣ��������п�ѡĿ��λ�õ�����ƫ��
    }
}
