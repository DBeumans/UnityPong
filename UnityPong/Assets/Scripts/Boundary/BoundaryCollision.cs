using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryCollision : MonoBehaviour {

    // Let the score manager know that the ball hit a boundary.

    private PlayerManager playerManager;

    private BallManager ballmanager;

    private void Start()
    {
        
    }

    public void AssignComponents()
    {
        if (playerManager == null)
        {
            GameObject pm = GameObject.FindGameObjectWithTag("Player");

            // Check if we get the LOCAL PlayerManager.
            if (pm.layer != LayerMask.NameToLayer("LocalPlayer"))
                return;

            playerManager = pm.GetComponent<PlayerManager>();
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        // If the ball collide with the boundary, apply point to the player.
        if(other.gameObject.tag == "Ball")
        {
            if(ballmanager == null)
                ballmanager = other.gameObject.GetComponent<BallManager>();
            
        }
    }
}
