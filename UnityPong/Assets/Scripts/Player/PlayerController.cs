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

        Vector3 pos = new Vector3(12f, 0, 10.5f);
        transform.position = pos;
    }

    private void Update()
    {
        movement();
    }

    private void movement()
    {
        if (!isLocalPlayer)
            return;
        if(input.Get_Key_Up)
        {
            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        }

        if(input.Get_Key_Down)
        {
            transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
        }
    }

}
