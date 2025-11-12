using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public GameObject powerUpIndicator;
    public bool hasPowerUp;
    public float knockOutStrength = 10.0f;
    private GameObject focalPoint;
    private Rigidbody playerRb;
    float speed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
        playerRb = GetComponent<Rigidbody>();

        powerUpIndicator.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            powerUpIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerUpCountDownCoRoutine());
        }
    }

    IEnumerator PowerUpCountDownCoRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (hasPowerUp && collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 throwDir = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(throwDir.normalized * knockOutStrength, ForceMode.Impulse);
            Debug.Log("Collided with" + collision.gameObject.name + "with power up as" + hasPowerUp);
        }
    }
}
