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

    private void Update()
    {
        TransmitPosition();
        lerpPostition();
    }

    private void lerpPostition()
    {
        if (!isLocalPlayer)
        {
            myTransform.position = Vector3.Lerp(myTransform.position, syncPosition, Time.fixedDeltaTime * lerpRate);
        }

    }

    [Command]
    private void CmdPositionToServer(Vector3 position)
    {
        syncPosition = position;
    }

    [ClientCallback]
    private void TransmitPosition()
    {

        if (!hasAuthority)
            return;
        CmdPositionToServer(myTransform.position);
    }

}
