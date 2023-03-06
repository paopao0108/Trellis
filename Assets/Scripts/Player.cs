using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    private PhotonView photonView;

    public ChessPanel chessPanel;
    public CircleColor circleColor;

    private Circle lCircle;
    private Circle mCircle;
    private Circle sCircle;
    public Circle lBlueCircle;
    public Circle mBlueCircle;
    public Circle sBlueCircle;
    public Circle lRedCircle;
    public Circle mRedCircle;
    public Circle sRedCircle;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        Init();
    }

    void Update()
    {
        if (!photonView.IsMine) return; // 如果不是当前的主客户端，则返回
    }

    public void Init()
    {
        // 初始化玩家的棋子
        if (circleColor == CircleColor.Blue)
        {
            //lCircle = Instantiate(lBlueCircle, chessPanel.transform.position, lBlueCircle.transform.rotation);
            //Vector3 mCirclePos = chessPanel.transform.position + new Vector3(115, 115, 0);
            //mCircle = Instantiate(mBlueCircle, mCirclePos, mBlueCircle.transform.rotation);
            lCircle = Instantiate(lBlueCircle, chessPanel.transform);
            mCircle = Instantiate(mBlueCircle, chessPanel.transform);
            sCircle = Instantiate(sBlueCircle, chessPanel.transform);
        }
        else
        {
            lCircle = Instantiate(lRedCircle, chessPanel.transform);
            mCircle = Instantiate(mRedCircle, chessPanel.transform);
            sCircle = Instantiate(sRedCircle, chessPanel.transform);
        }
    }
    // 检测拖拽事件
    // 1. 根据棋子颜色生成联网的棋子
}
