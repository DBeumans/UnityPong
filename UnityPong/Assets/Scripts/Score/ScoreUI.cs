using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

    [SerializeField]
    private Text localPlayerScoreText;

    private PlayerManager playerManager;

    private void Start()
    {
        

        localPlayerScoreText.text = "0";
    }

    public void SetScore()
    {
        
    }
}
