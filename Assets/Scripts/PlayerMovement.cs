using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    #region Fields 

    [SerializeField]
    private CharacterController _cc;

    private readonly float _speed = 5.0f;

    #endregion

    #region Monobehaviors

    // Use this for initialization
    void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        HandleLocalMovement();
	}

    #endregion

    #region Methods

    private void HandleLocalMovement()
    {
        if (GameStateManager.GameState != GameStateManager.States.LocalGame)
        {
            return;
        }

        var xMove = Input.GetAxis("Horizontal");
        var yMove = Input.GetAxis("Vertical");

        var moveDirection = new Vector2(xMove, yMove);
        moveDirection *= _speed;
        _cc.Move(moveDirection * Time.deltaTime);
    }

    private void Init()
    {
        if (gameObject.GetComponent<CharacterController>() == null)
        {
            gameObject.AddComponent<CharacterController>();
        }
        _cc = gameObject.GetComponent<CharacterController>();

        // temp init for local game. This state needs to be set elsewhere.
        GameStateManager.GameState = GameStateManager.States.LocalGame;
    }

    #endregion
}
