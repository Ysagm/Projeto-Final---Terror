using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using Photon.Pun;
using Photon.Realtime;

public class GameConnection : MonoBehaviourPunCallbacks
{
    public UnityEvent onEnterLobbyCallback;
    public Text chatLog;

     void Awake()
    {
        //chatLog.text = "Conectando no servidor...";
        PhotonNetwork.LocalPlayer.NickName = "Player" + Random.Range(0, 1000);
        PhotonNetwork.ConnectUsingSettings();
    }

    //--------------------------------------------------------
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        
        //chatLog.text += "\nConectado no servidor!";
        if (PhotonNetwork.InLobby == false)
        {
            //chatLog.text += "\nEntrando no Lobby...";
            PhotonNetwork.JoinLobby();
        }
    }

    //--------------------------------------------------------
    public override void OnJoinedLobby()
    {
        //chatLog.text += "\nEntrou no Lobby!";
        PhotonNetwork.JoinRoom("ProjetoTerror");
        //chatLog.text += "\nEntrando na sala ProjetoTerror...";

        //onEnterLobbyCallback.Invoke();
    }

    //--------------------------------------------------------
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        //chatLog.text += "\nErro ao entrar na sala: " + message + " return code = " + returnCode;

        if (returnCode == ErrorCode.GameDoesNotExist)
        {
            RoomOptions room = new RoomOptions { MaxPlayers = 20 };
            PhotonNetwork.CreateRoom("ProjetoTerror", room, null);
            //chatLog.text += "\nCriando sala ProjetoTerror!";
        }
    }

    //--------------------------------------------------------
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //chatLog.text += "\nPlayer entrou na sala: " + newPlayer.NickName;
    }

    //--------------------------------------------------------
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        //chatLog.text += "\nPlayer saiu na sala: " + otherPlayer.NickName;
    }

    //--------------------------------------------------------
    public override void OnLeftRoom()
    {
        //chatLog.text += "\nVocê saiu da sala...";
    }

    //--------------------------------------------------------
    public override void OnJoinedRoom()
    {
        //chatLog.text += "\nVocê entrou na sala: ProjetoTerror, como: " + PhotonNetwork.LocalPlayer.NickName;
        Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 1, Random.Range(-10.0f, 10.0f));
        Quaternion rotation = Quaternion.Euler(Vector3.up * Random.Range(0, 360.0f));
        //Instantiate do Photon carrega um prefab do Resources
        //PhotonNetwork.Instantiate("Player", position, rotation);

        onEnterLobbyCallback.Invoke();
    }
}
