using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class JoinGame : MonoBehaviour {

    private List<GameObject> totalRooms = new List<GameObject>();

    private NetworkManager networkManager;

    [SerializeField]
    private Text statusText;

    [SerializeField]
    private GameObject roomItemPrefab;

    [SerializeField]
    private GameObject roomItemsParent;

    private void Start()
    {
        networkManager = NetworkManager.singleton;

        if(networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }

        RefreshRooms();
    }

    public void RefreshRooms()
    {
        ClearRooms();

        networkManager.matchMaker.ListMatches(0, 20, "", true, 0, 0, OnMatchList);
        statusText.text = "Loading Rooms...";
    }

    private void ClearRooms()
    {
        for (int i = 0; i < totalRooms.Count; i++)
        {
            Destroy(totalRooms[i]);
        }

        totalRooms.Clear();
    }

    public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {
        statusText.text = "";

        if(success == false || matches == null)
        {
            statusText.text = "No rooms found!";
            return;
        }

        foreach(MatchInfoSnapshot match in matches)
        {
            GameObject roomItem = Instantiate(roomItemPrefab);
            roomItem.transform.SetParent(roomItemsParent.transform, false);

            RoomItem roomListItem = roomItem.GetComponent<RoomItem>();
            if (roomListItem != null)
            {
                roomListItem.Setup(match, JoinRoom);
            }

            totalRooms.Add(roomItem);
        }

        if (totalRooms.Count == 0)
        {
            statusText.text = "No rooms at the moment.";
        }
    }

    public void JoinRoom(MatchInfoSnapshot match)
    {
        networkManager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, networkManager.OnMatchJoined);
        StartCoroutine(waitToJoin(match));
    }

    private IEnumerator waitToJoin(MatchInfoSnapshot match)
    {
        ClearRooms();

        int countDown = 10;
        string dot = ".";

        while(countDown > 0 )
        {
            statusText.text = "Joining" + dot  + "\n"+ match.name;

            yield return new WaitForSeconds(1f);

            countDown--;
            dot += ".";

            if (dot == "....")
                dot = "";
        }

        statusText.text = "Failed to connect.";
        yield return new WaitForSeconds(1);

        MatchInfo matchInfo = networkManager.matchInfo;
        if (matchInfo != null)
        {
            networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, networkManager.OnDropConnection);
            networkManager.StopHost();
        }

        RefreshRooms();
    }

}
