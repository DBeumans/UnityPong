using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SyncMovement : NetworkBehaviour {

    [SyncVar]
    private Vector3 syncPosition;

    private Transform myTransform;

    [SerializeField]
    private float lerpRate = 20;

    private void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        transmitPosition();
        lerpPostition();
    }

    private void lerpPostition()
    {
        if (isLocalPlayer)
            return;

        myTransform.position = Vector3.Lerp(myTransform.position, syncPosition, Time.deltaTime * lerpRate);
    }

    [Command]
    private void CmdPositionToServer(Vector3 position)
    {
        syncPosition = position;
    }

    [ClientCallback]
    private void transmitPosition()
    {
        CmdPositionToServer(myTransform.position);
    }

}
