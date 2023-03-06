using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroPoint : MonoBehaviour
{
    private Vector3 pos;

    public Vector3 Pos { get => pos; set => pos = value; }
    private void Awake()
    {
        Pos = this.transform.position;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
