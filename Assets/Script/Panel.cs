using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    private List<List<GridCell>> grids = new List<List<GridCell>>();

    public int row;
    public int col;
    public GridCell grid;

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
            grids.Add(new List<GridCell>());
            for (int j = 0; j < col; j++)
                grids[i].Add(Instantiate(grid, this.transform));
        }
    }
}
