using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;

public class SamplePlayer : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector2 move;
    private bool dash;
    private InputAction moveAction;
    private InputAction dashAction;
    private SpriteRenderer spriteRenderer;

    private float speed;



    void Start()
    {
        if (transform.parent != null)
        {
            spriteRenderer = transform.parent.gameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/SamplePlayer");
        }
    }

    void Update()
    {
        move = moveAction.ReadValue<Vector2>();
        dash = dashAction.IsPressed();

    }

    void FixedUpdate()
    {
        Move();
    }

    public void Initialize(PlayerInput playerInput)
    {
        this.playerInput = playerInput;
        moveAction = playerInput.actions["Move"];
        dashAction = playerInput.actions["Dash"];
        //Enable the actions
        moveAction.Enable();
        dashAction.Enable();
    }

    void Move()
    {
        if (dash)
        {
            speed = 13.0f;
        }
        else
        {
            speed = 6.5f;
        }
        Vector2 position = (Vector2)transform.position + move * speed * Time.fixedDeltaTime;
        transform.position = position;
    }

}