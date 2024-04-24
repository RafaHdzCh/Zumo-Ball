using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool hasPowerUp;
    private const float powerUpStrength = 15f;
    private const float timeToDeactivatePowerup = 8f;
    private readonly Vector3 powerUpIndicatorOffset = new(0f, -0.4f, 0f);
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Transform focalPoint;
    [SerializeField] private GameObject powerUpIndicator;
    
    void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rigidbody.AddForce(focalPoint.forward * (speed * forwardInput), ForceMode.Force);
        powerUpIndicator.transform.position = transform.position + powerUpIndicatorOffset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            Invoke(nameof(DeactivatePowerUp), timeToDeactivatePowerup);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = other.transform.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.transform.position - transform.position).normalized;
            enemyRigidbody.AddForce(awayFromPlayer*powerUpStrength, ForceMode.Impulse);
        }
    }

    private void DeactivatePowerUp()
    {
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }
}
