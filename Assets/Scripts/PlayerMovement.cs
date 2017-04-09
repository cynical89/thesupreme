using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    #region Fields 
    // This field is visible and editable from the editor, but set in the script.
    [SerializeField]
    private Rigidbody2D _rb2D;

    private readonly float _speed = 5.0f;
    private readonly float _rotationSpeed = 7.0f;

    #endregion

    #region Monobehaviors

    // Use this for initialization
    void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        HandleLocalMovement();
        HandleRotation();
	}

    #endregion

    #region Methods

    private void HandleLocalMovement()
    {
         // If this game is not a local game, we will not handle local movement
        if (GameStateManager.GameState != GameStateManager.States.LocalGame)
        {
            return;
        }

        var yMove = Input.GetAxis("Vertical");
        yMove = yMove < 0 ? 0 : yMove;
        var moveDirection = transform.up * yMove * _speed;
        if ((_rb2D.velocity.x < 3 && _rb2D.velocity.x > -3) 
            && (_rb2D.velocity.y < 3 && _rb2D.velocity.y > -3)) {
            _rb2D.AddForce(moveDirection);
        }
    }

    private void HandleRotation() {
        var xMove = Input.GetAxis("Horizontal");
        var rotation = new Vector3(0,0,-xMove);
        rotation *= _rotationSpeed;
        transform.Rotate(rotation);
    }

    private void Init()
    {
        // If the game object this script is attached to doesn't have a Rigidbody2D, add it.
        if (gameObject.GetComponent<Rigidbody2D>() == null)
        {
            gameObject.AddComponent<Rigidbody2D>();
        }
        // Grab the instance of the Rigidbody2D
        _rb2D = gameObject.GetComponent<Rigidbody2D>();

        // temp init for local game. This state needs to be set elsewhere. Like in the menu when the player selects local games.
        GameStateManager.GameState = GameStateManager.States.LocalGame;
    }

    #endregion
}
