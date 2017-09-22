using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestSpawner : NetworkBehaviour {

    [SerializeField]
    private GameObject obj;

    public override void OnStartServer()
    {
        GameObject ballObject = Instantiate(obj, obj.transform.position, Quaternion.identity) as GameObject;
        NetworkServer.Spawn(ballObject);
    }
}
