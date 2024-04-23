using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rigidbody;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        rigidbody.AddForce(directionToPlayer * speed);
    }
}
