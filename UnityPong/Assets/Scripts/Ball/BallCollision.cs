using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BallCollision : NetworkBehaviour {

    private BallMovement ballMovement;
    private BallManager ballManager;
    private void Start()
    {
        ballManager = GetComponent<BallManager>();
        ballMovement = GetComponent<BallMovement>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("LocalPlayer"))
            {
                ballManager.SetStatus(BallManager.BallStatus.me);
            }

            if(other.gameObject.layer == LayerMask.NameToLayer("ConnectedPlayer"))
            {
                ballManager.SetStatus(BallManager.BallStatus.other);
            }

            float y = hitFactor(transform.position, other.transform.position, other.collider.bounds.size.y);
            
            if (other.gameObject.transform.position.x < 0) // left
            {
                Vector3 newDirection = new Vector3(1, y).normalized;
                ballMovement.MoveBall(newDirection);
                return;
            }
            if (other.gameObject.transform.position.x > 0) // right
            {
                Vector3 newDirection = new Vector3(-1, y).normalized;
                ballMovement.MoveBall(newDirection);
                return;
            }
        }


    }

    private float hitFactor(Vector3 ballPosition, Vector3 playerPosition, float playerHeight)
    {
        return (ballPosition.y - playerPosition.y) / playerHeight;
    }
}
