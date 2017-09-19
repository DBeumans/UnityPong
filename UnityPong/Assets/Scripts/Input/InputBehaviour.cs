using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour {

    private bool key_up;
    public bool Get_Key_Up { get { return key_up; } }

    private bool key_down;
    public bool Get_Key_Down { get { return key_down; } }

    private KeyCode keycodeUp;
    private KeyCode keycodeDown;

    private void Update()
    {
        keycodeUp = KeyCode.UpArrow;
        keycodeDown = KeyCode.DownArrow;

        key_up = Input.GetKey(keycodeUp);
        key_down = Input.GetKey(keycodeDown);
    }
}
