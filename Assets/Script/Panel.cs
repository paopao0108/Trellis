using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    private List<List<Cell>> grids = new List<List<Cell>>();

    public int row;
    public int col;
    public Cell grid;
    public GridCell gridcell;

    private void Awake()
    {
        Init();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void Init()
    {
        for (int i = 0; i < row; i++)
        {
            grids.Add(new List<Cell>());
            for (int j = 0; j < col; j++)
                grids[i].Add(Instantiate(grid, this.transform));
        }
    }
}
