using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Alpaca : MonoBehaviour
{
    public float attentionSpan = 1.0f;
    public float stopChance = 0.5f;
    public List<Sprite> sprites;
    public CharacterController characterController;
    public SpriteRenderer spriteRenderer;
    private Vector3 _direction;
    private float _time;

    public void Charm(Transform charmer, float duration)
    {
        _direction = Vector3.ProjectOnPlane(charmer.position - transform.position, Vector3.up).normalized;
        _time = -duration;
    }

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time > attentionSpan)
        {
            _direction = RandomDirection(Vector3.up);
            _time = 0.0f;
        }
        foreach (var behaviour in GetComponentsInChildren<ICharacterBehaviour<Vector3>>())
        {
            behaviour.OnBehaviour(_direction);
        }
    }

    private void LateUpdate()
    {
        if (sprites.Count != 0)
        {
            var spriteName = spriteRenderer.sprite.name;
            var pattern = spriteName.Substring(spriteName.IndexOf('_'));

            spriteRenderer.sprite = sprites.Find(sprite => sprite.name.EndsWith(pattern)) ?? spriteRenderer.sprite;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && _time > 0.0f)
        {
            _direction = Vector3.ProjectOnPlane(transform.position - other.transform.position, Vector3.up).normalized;
        }
    }

    private Vector3 RandomDirection(Vector3 axis)
    {
        float theta = Random.Range(0.0f, 2.0f * Mathf.PI), z = Random.Range(-1.0f, 1.0f);
        Vector3 direction = new Vector3
        {
            x = Mathf.Sqrt(1.0f - (z * z)) * Mathf.Cos(theta),
            y = Mathf.Sqrt(1.0f - (z * z)) * Mathf.Sin(theta),
            z = z
        };
        return Vector3.ProjectOnPlane(direction, axis).normalized * Random.Range(0, (int)(1.0f / stopChance));
    }
}
