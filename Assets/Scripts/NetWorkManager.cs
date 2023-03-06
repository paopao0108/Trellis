using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; // 1. using
using Photon.Realtime;

public enum CircleColor
{
    Blue,
    Red
}

public class NetWorkManager : MonoBehaviourPunCallbacks // 2 继承MonoBehaviourPunCallbacks
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // 3. 连接服务器
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print("OnConnectedToMaster");
        RoomOptions roomOptions = new RoomOptions();
        // 4. 创建获取加入房间
        PhotonNetwork.JoinOrCreateRoom("Trellis_0101", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("OnJoinedRoom");
        // 5. 创建联网的玩家
        if (player == null) return;
        GameObject newPlayer = PhotonNetwork.Instantiate(player.name, Vector3.zero, player.transform.rotation ); // 玩家预制件名称，位置， 旋转角度

        // 初始化玩家的一些属性
        if(PhotonNetwork.IsMasterClient)
        {
            // 设置玩家的棋子类型
            newPlayer.GetComponent<Player>().circleColor = CircleColor.Blue;
        } else
        {
            // 设置玩家的棋子类型（颜色等）
            newPlayer.GetComponent<Player>().circleColor = CircleColor.Red;
        }
    }
}
