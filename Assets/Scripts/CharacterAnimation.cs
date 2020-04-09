using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator animator;
    public CharacterController2D characterController2D;
    private readonly int _speedID = Animator.StringToHash("Speed");
    private readonly int _idleID = Animator.StringToHash("Idle");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController2D = GetComponentInParent<CharacterController2D>();
    }

    private void Update()
    {
        float sign = Mathf.Sign(characterController2D.Velocity.x);
        float speed = sign * characterController2D.Velocity.magnitude;

        animator.SetBool(_idleID, speed == 0);
        animator.SetFloat(_speedID, speed);
    }
}
