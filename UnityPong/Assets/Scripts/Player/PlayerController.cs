using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    [SerializeField]
    private int movementSpeed;

    private InputBehaviour input;

    private Rigidbody rigidbody;

    private void Start()
    {
        input = FindObjectOfType<InputBehaviour>();
        rigidbody = GetComponent<Rigidbody>();

        if(isLocalPlayer)
        {
            this.gameObject.layer = LayerMask.NameToLayer("LocalPlayer");   // Changes the layer to local player.
        }
        else
        {
            this.gameObject.layer = LayerMask.NameToLayer("ConnectedPlayer");   // Changes the layer to connected player.
        }
    }

    private void FixedUpdate()
    {
        movement();
    }

    private void movement()
    {
        if (input.Get_Key_Up)
        {
            rigidbody.MovePosition(rigidbody.position + transform.up* movementSpeed * Time.fixedDeltaTime);
        }

        if (input.Get_Key_Down)
        {
            rigidbody.MovePosition(rigidbody.position + -transform.up * movementSpeed * Time.fixedDeltaTime);
        }
    }

}
