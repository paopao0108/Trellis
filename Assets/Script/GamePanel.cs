using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    private float gridPanelSize; // �������ߴ�
    private float gridSpacing; // ���Ӽ��
    //private float cellSize; // ���ӳߴ�
    private GameObject gridPanel;

    public int row;
    public int col;
    public Transform zeroPoint;
    public static List<List<GridCell>> grids = new List<List<GridCell>>(); // ���и���
    public GridCell grid;

    //public float CellSize { get => cellSize; set => cellSize = value; }


    private void Awake()
    {
        gridPanel = GameObject.Find("Panel");
        gridPanelSize = gridPanel.GetComponent<RectTransform>().rect.width; // ��ȡ���ߴ�
        gridSpacing = gridPanel.GetComponent<GridLayoutGroup>().spacing.x;
        GridCell.CellSize = (gridPanelSize - (row - 1) * gridSpacing) / row;
        
        gridPanel.GetComponent<GridLayoutGroup>().cellSize = new Vector2(GridCell.CellSize, GridCell.CellSize);
        Init();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        // ʵ�������и���
        for (int i = 0; i < row; i++)
        {
            grids.Add(new List<GridCell>());
            for (int j = 0; j < col; j++)
                grids[i].Add(Instantiate(grid, gridPanel.transform));
        }

        //Debug.Log("cellSize:" + grids[0][0].CellSize);
    }
}
