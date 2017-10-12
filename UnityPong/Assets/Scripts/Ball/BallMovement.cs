using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BallMovement : NetworkBehaviour {

    [SerializeField]
    private int movementSpeed;

    public int Get_MovementSpeed { get { return Get_MovementSpeed; } }

    private Rigidbody rigidbody;

    public Rigidbody Get_Rigidbody { get { return rigidbody; } }

    private Vector3 direction;

    public Vector3 Get_Direction
    {
        get { return direction; }
        set { direction = value; }
    }

    private void Start()
    {
        direction = Vector3.left;

        rigidbody = GetComponent<Rigidbody>();

        MoveBall(direction);
    }

    public void MoveBall(Vector3 dir)
    {
        rigidbody.velocity = dir * movementSpeed;
    }
}
