using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sing : MonoBehaviour, ICharacterBehaviour
{
    public float duration = 5.0f;
    public float range = 5.0f;
    public int charmMax = 10;
    private Collider[] _colliders;
    private float _time;

    public void OnBehaviour()
    {
        if (_time < duration)
            return;

        int count = Physics.OverlapSphereNonAlloc(transform.position, range, _colliders);
        if (count != 0)
        {
            foreach (var collider in _colliders)
            {
                Alpaca alpaca = collider?.GetComponent<Alpaca>();
                if (alpaca != null)
                {
                    alpaca.Charm(transform, duration);
                }
            }
        }
        _time = 0.0f;
    }

    private void Awake()
    {
        _colliders = new Collider[charmMax];
        _time = duration;
    }

    private void Update()
    {
        _time += Time.deltaTime;
    }
}
