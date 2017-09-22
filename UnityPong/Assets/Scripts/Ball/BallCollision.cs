using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour {

    private BallMovement ballMovement;
    private void Start()
    {
        ballMovement = GetComponent<BallMovement>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
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
