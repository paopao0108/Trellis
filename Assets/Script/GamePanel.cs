using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    private float gridPanelSize; // 网格面板尺寸
    private float gridSpacing; // 格子间距
    //private float cellSize; // 格子尺寸
    private GameObject gridPanel;

    public int row;
    public int col;
    public Transform zeroPoint;
    public static List<List<GridCell>> grids = new List<List<GridCell>>(); // 所有格子
    public GridCell grid;

    //public float CellSize { get => cellSize; set => cellSize = value; }


    private void Awake()
    {
        gridPanel = GameObject.Find("Panel");
        gridPanelSize = gridPanel.GetComponent<RectTransform>().rect.width; // 获取面板尺寸
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
        // 实例化所有格子
        for (int i = 0; i < row; i++)
        {
            grids.Add(new List<GridCell>());
            for (int j = 0; j < col; j++)
                grids[i].Add(Instantiate(grid, gridPanel.transform));
        }

        //Debug.Log("cellSize:" + grids[0][0].CellSize);
    }
}
