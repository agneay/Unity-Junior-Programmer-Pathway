using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject playerRef;
    private Rigidbody enemyRb;
    public float speed = 3.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRef = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
        Vector3 dir = playerRef.transform.position - transform.position;
        enemyRb.AddForce(dir.normalized * Time.deltaTime * speed);

    }
}
