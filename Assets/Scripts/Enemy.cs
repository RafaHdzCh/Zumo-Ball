using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool hasFallen;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rigidbody;
    [NonSerialized] public SpawnManager spawnManager;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    
    private void VerifyPosition()
    {
        if (transform.position.y <= -5 && !hasFallen)
        {
            hasFallen = true;
            spawnManager.EnemyFallen();
        }
    }

    void FixedUpdate()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        rigidbody.AddForce(directionToPlayer * speed);
    }

    private void Update()
    {
        VerifyPosition();
    }
}
