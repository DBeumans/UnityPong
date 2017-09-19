using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BallMovement : NetworkBehaviour {

    [SerializeField]
    private int movementSpeed;

    private Rigidbody rigidbody;

    private Vector2 direction;

    private int playerWidth, playerPosX, playerPosY;
    
    private void Start()
    {
        direction = Vector2.left;

        rigidbody = GetComponent<Rigidbody>();

        rigidbody.AddForce((Vector2)direction * movementSpeed);
    }

    private void Update()
    {
        //movement();
    }

    private void movement()
    {
        transform.Translate((Vector2)direction * movementSpeed * Time.deltaTime);
        //rigidbody.AddForce((Vector2)direction *movementSpeed );
    }
}
