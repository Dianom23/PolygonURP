using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealth : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _heal;
    [SerializeField] private Heath _health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _health.TakeDamage(_damage);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            _health.RestoreHealth(_heal);
        }
    }
}
