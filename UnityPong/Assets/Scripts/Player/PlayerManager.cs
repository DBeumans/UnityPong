using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerManager : NetworkBehaviour {

    // Keeps track of score etc.

    private int score;

    public int Get_PlayerScore { get { return score; } }

    private BoundaryCollision boundaryCollision;
    
    private Transform canvas;

    [SerializeField]
    private GameObject playerUI;

    private GameObject playerUIText;

    private void Start()
    {
        boundaryCollision = FindObjectOfType<BoundaryCollision>();
        boundaryCollision.AssignComponents();

        canvas = GameObject.FindGameObjectWithTag("Canvas").gameObject.transform;

        InstantiatePlayerUI();

        

    }

    private void Update()
    {
        if (isServer)
        {
            Debug.Log(this.gameObject.name + " I'm the server");
        }

        if (!isServer)
        {
            Debug.Log(this.gameObject.name + " I'm the client");
        }
    }

    private void InstantiatePlayerUI()
    {
        GameObject _playerUI = Instantiate(playerUI);

        playerUIText = GameObject.FindGameObjectWithTag("PlayerUIText");
       

        _playerUI.transform.SetParent(canvas,false);

        AssignPlayerTextPosition();


    }

    private void AssignPlayerTextPosition()
    {
        RectTransform playerUIText_RectTransform = playerUIText.GetComponent<RectTransform>();
        
        if(this.gameObject.transform.position.x < 0) // left
        {
            playerUIText_RectTransform.anchoredPosition = new Vector2(-1, 0);
        }
        if(this.gameObject.transform.position.x > 0) // right
        {
            playerUIText_RectTransform.anchoredPosition = new Vector2(1, 0);
        }
    }

    public void UpdateScore(int score)
    {
        this.score = score;
    }
}
