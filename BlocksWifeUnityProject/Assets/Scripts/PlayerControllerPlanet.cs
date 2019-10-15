using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPlanet : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    [SerializeField]
    public Transform planet;

    private SpriteRenderer spriteRenderer;
    private float magnitude;

    protected override void Start()
    {
        base.Start();
        magnitude = gravity.magnitude;
    }

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void FixedUpdate()
    {
        gravity = Vector3.Normalize(planet.position - transform.position) * magnitude;
        transform.right = Vector3.Cross(Vector3.forward, gravity);
        base.FixedUpdate();
    }

    protected override void ComputeVelocity()
    {
        float move;
        move = Input.GetAxis("Horizontal");

        Vector2 up;
        up.x = transform.up.x;
        up.y = transform.up.y;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            gravityVelocity = up * jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            float magnitudeUp = Vector2.Dot(velocity, up);

            if (magnitudeUp > 0)
            {
                gravityVelocity = gravityVelocity * 0.5f;
            }
        }

        bool flipSprite = (!spriteRenderer.flipX ? (move > 0f) : (move < 0f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        targetVelocity = transform.right * move * maxSpeed;
    }
}