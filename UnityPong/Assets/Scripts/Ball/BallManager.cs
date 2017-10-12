using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

    public enum BallStatus
    {
        me,     // local player.
        other   // connected player.
    }

    [SerializeField]
    private BallStatus currentStatus;

    public BallStatus Get_CurrentBallStatus { get { return currentStatus; } }

    private BallCollision ballCollision;

    private void Start()
    {
        ballCollision = GetComponent<BallCollision>();
    }

    public void SetStatus(BallStatus status)
    {
        currentStatus = status;
    }
}
