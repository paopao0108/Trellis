using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private List<List<GridCell>> grids; // 存放所有的网格预制体
    private int row;

    public GameObject gridCell;
    

    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void init()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < row; j++)
            {
                Instantiate(gridCell, this.transform); // 实例化网格预制体
            }
        }
    }
}
