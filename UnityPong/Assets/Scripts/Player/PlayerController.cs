using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    [SerializeField]
    private int movementSpeed;

    private InputBehaviour input;

    private void Start()
    {
        input = FindObjectOfType<InputBehaviour>();
    }

    private void Update()
    {
        movement();
    }

    private void movement()
    {
        if (input.Get_Key_Up)
        {
            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        }

        if (input.Get_Key_Down)
        {
            transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
        }
    }

}
