using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    private enum FollowType
    {
        Simple,
        Rb,
    }

    [SerializeField] private FollowType _followType;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        switch (_followType)
        {
            case FollowType.Simple:
                SimpleFollow();
                break;
            case FollowType.Rb:
                RbFollow();
                break;
        }
    }

    private void SimpleFollow()
    {
        transform.Translate(GetDirection() * _speed * Time.deltaTime);
    }

    private void RbFollow()
    {
        _rb.velocity = GetDirection() * _speed;
    }

    private Vector3 GetDirection()
    {
        return (_target.position - transform.position).normalized;
    }
}
