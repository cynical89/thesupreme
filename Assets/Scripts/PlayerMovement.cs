using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    #region Fields 

    [SerializeField]
    private Rigidbody2D _rb2D;

    private readonly float _speed = 5.0f;
    private readonly float _rotationSpeed = 6.0f;
    private float yMove = 0f;

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
        ConstrainVelocity();
	}

    #endregion

    #region Methods

    private void HandleLocalMovement()
    {
        if (GameStateManager.GameState != GameStateManager.States.LocalGame)
        {
            return;
        }

        yMove = Input.GetAxis("Vertical");
        var prevInput = yMove;
        var moveDirection = transform.up * yMove * _speed;
        _rb2D.AddForce(moveDirection);
    }

    private void HandleRotation() {
        var xMove = Input.GetAxis("Horizontal");
        var rotation = new Vector3(0,0,-xMove);
        rotation *= _rotationSpeed;
        transform.Rotate(rotation);
    }

    private void ConstrainVelocity() {
        if (_rb2D.velocity.y > 0) {
            _rb2D.velocity = _rb2D.velocity.y >= 1f ? new Vector2(_rb2D.velocity.x, 1f) : _rb2D.velocity;
        } else {
            _rb2D.velocity = _rb2D.velocity.y <= -1f ? new Vector2(_rb2D.velocity.x, -1f) : _rb2D.velocity;
        }

        if (_rb2D.velocity.x > 0) {
            _rb2D.velocity = _rb2D.velocity.x >= 1f ? new Vector2(1f, _rb2D.velocity.y) : _rb2D.velocity;
        } else {
            _rb2D.velocity = _rb2D.velocity.x <= -1f ? new Vector2(-1f, _rb2D.velocity.y) : _rb2D.velocity;
        }

    }

    private void Init()
    {
        if (gameObject.GetComponent<Rigidbody2D>() == null)
        {
            gameObject.AddComponent<Rigidbody2D>();
        }
        _rb2D = gameObject.GetComponent<Rigidbody2D>();

        // temp init for local game. This state needs to be set elsewhere.
        GameStateManager.GameState = GameStateManager.States.LocalGame;
    }

    #endregion
}
