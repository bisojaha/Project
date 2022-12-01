using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class PhotonMG : MonoBehaviourPunCallbacks
{
    public static PhotonMG instance;
    void Awake() => instance = this;
// ====================================================

    [SerializeField]
    private string version;
    [HideInInspector]
    public string m_userID;
    [HideInInspector]
    public string m_roomName;

    void Start()
    {
        version = "0.0";
        m_userID = " - ";
        PhotonNetwork.GameVersion = version;
        PhotonNetwork.NickName = m_userID;
        PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log(PhotonNetwork.SendRate);
    }

    void Update()
    {
    }

    public void Click_Connect() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }
    public override void OnJoinedLobby()
    {
        Debug.Log($"InLobby = {PhotonNetwork.InLobby}");
        Debug.Log($"InRoom = {PhotonNetwork.InRoom}");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log($"RoomList = {roomList.Count}");
        Debug.Log($"RoomList = {roomList}");
    }

    public void Click_JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinedRoom()
    {
        Debug.Log($"InRoom = {PhotonNetwork.InRoom}");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        message = $"InRoom = {PhotonNetwork.InRoom}";
    }

    public void Click_CreateRoom()
    {
        PhotonNetwork.CreateRoom(m_roomName);
    }
}
