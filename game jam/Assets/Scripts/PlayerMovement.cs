using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    Rigidbody2D rb;
    CapsuleCollider2D capsule;
    Vector2 moveInput;
    Animator ar;
    [SerializeField] float climbSpeed;

    Vector2 minBounds;
    Vector2 maxBounds;

    // Start is called before the first frame update
    void Start()
    {
        ar = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capsule = GetComponent<CapsuleCollider2D>();
        InitBound();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlippingSprite();

        if (!capsule.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            ar.SetBool("jump", true);
        }
        else
        {
            ar.SetBool("jump", false);

        }

            Climb();

    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log("run");
    }

    void Run()
    {
        Vector2 playerMove = new Vector2(moveInput.x * speed * Time.deltaTime, rb.velocity.y);

        rb.velocity = playerMove ;
        bool playerHasNoHorizonta = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasNoHorizonta)
        {
            ar.SetBool("run", true);

        }
        else
        {
            ar.SetBool("run", false);

        }

        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + playerMove.x, minBounds.x, maxBounds.x);
        newPos.y = Mathf.Clamp(transform.position.y + playerMove.y, minBounds.y, maxBounds.y);
    }
    void Climb()
    {
        if (!capsule.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            ar.SetBool("climb", false);

            return;
        }
        Vector2 playerMoveUp = new Vector2(rb.velocity.x, moveInput.y * climbSpeed );

        rb.velocity = playerMoveUp;

        bool playerVertical = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;



        ar.SetBool("climb", playerVertical);

    }

    void InitBound()
    {
        Camera camera = Camera.main;

        minBounds = camera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = camera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    void FlippingSprite()
    {
        bool playerHasNoHorizonta = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (playerHasNoHorizonta)
        {
            transform.localScale = new Vector3(Mathf.Sign(rb.velocity.x), 1f);

        }
    }


    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            if (capsule.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                rb.velocity += new Vector2(0, jumpForce);
            }
        }
    }
}
