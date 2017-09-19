using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestSpawner : NetworkBehaviour {

    [SerializeField]
    private GameObject obj;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            CmdSpawnObject();
    }

    [Command]
    private void CmdSpawnObject()
    {
        GameObject go = Instantiate(obj, new Vector3(0, 0, 10.5f), Quaternion.identity);
        NetworkServer.Spawn(go);
    }
}
