using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class CharacterController2D : MonoBehaviour
{
    public enum CollisionType
    {
        Enter,
        Exit,
        Stay
    }
    public delegate void Collision2DProc(Collision2D collision, CollisionType type);
    public delegate void Trigger2DProc(Collider2D collider, CollisionType type);

    public LayerMask layer;
    public event Collision2DProc OnCollision2D;
    public event Trigger2DProc OnTrigger2D;
    [HideInInspector] public new Rigidbody2D rigidbody2D;
    [HideInInspector] public new Collider2D collider2D;

    public Vector2 Position
    {
        get => rigidbody2D.position;
        set => rigidbody2D.position = value;
    }

    public Vector2 Velocity
    {
        get => rigidbody2D.velocity;
        set => rigidbody2D.velocity = value;
    }

    public void Move(Vector2 motion)
    {
        rigidbody2D.velocity = motion;
    }

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision2D?.Invoke(collision, CollisionType.Enter);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnCollision2D?.Invoke(collision, CollisionType.Exit);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        OnCollision2D?.Invoke(collision, CollisionType.Stay);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        OnTrigger2D?.Invoke(collider, CollisionType.Enter);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        OnTrigger2D?.Invoke(collider, CollisionType.Exit);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        OnTrigger2D?.Invoke(collider, CollisionType.Stay);
    }
}