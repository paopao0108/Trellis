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

public class NetWorkManager : MonoBehaviourPunCallbacks // 2 �̳�MonoBehaviourPunCallbacks
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // 3. ���ӷ�����
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
        // 4. ������ȡ���뷿��
        PhotonNetwork.JoinOrCreateRoom("Trellis_0101", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("OnJoinedRoom");
        // 5. �������������
        if (player == null) return;
        GameObject newPlayer = PhotonNetwork.Instantiate(player.name, Vector3.zero, player.transform.rotation ); // ���Ԥ�Ƽ����ƣ�λ�ã� ��ת�Ƕ�

        // ��ʼ����ҵ�һЩ����
        if(PhotonNetwork.IsMasterClient)
        {
            // ������ҵ���������
            newPlayer.GetComponent<Player>().circleColor = CircleColor.Blue;
        } else
        {
            // ������ҵ��������ͣ���ɫ�ȣ�
            newPlayer.GetComponent<Player>().circleColor = CircleColor.Red;
        }
    }
}
