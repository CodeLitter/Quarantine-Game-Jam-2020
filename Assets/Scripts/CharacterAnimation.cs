using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator animator;
    public CharacterController characterController;
    public SpriteRenderer spriteRenderer;
    private readonly int _hSpeedID = Animator.StringToHash("Horizontal");
    private readonly int _vSpeedID = Animator.StringToHash("Vertical");
    private readonly int _idleID = Animator.StringToHash("Idle");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponentInParent<CharacterController>();
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector3 velocity = Quaternion.Inverse(characterController.transform.rotation) * characterController.velocity;

        animator.SetBool(_idleID, velocity.magnitude == 0);
        animator.SetFloat(_hSpeedID, velocity.x);
        animator.SetFloat(_vSpeedID, velocity.z);
    }
}
