using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HostGame : MonoBehaviour {

    private uint Max_room_size = 6;

    private string roomName;

    private NetworkManager networkManager;

    [SerializeField]
    private InputField roomName_input;


    private void Start()
    {
        networkManager = NetworkManager.singleton;
        if(networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
    }

    public void CreateRoom()
    {

        roomName = roomName_input.text;

        if (roomName == "" && roomName == null)
            return;

        networkManager.matchMaker.CreateMatch(roomName, Max_room_size, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
    }

}
