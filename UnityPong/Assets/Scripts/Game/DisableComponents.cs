﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DisableComponents : NetworkBehaviour {

    [SerializeField]
    private Behaviour[] components;
    
    private void Start()
    {
        if (isLocalPlayer)
            return;
        for (int i = 0; i < components.Length; i++)
        {
            components[i].enabled = false;
        }
    }
}
