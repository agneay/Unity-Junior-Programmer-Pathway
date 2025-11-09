using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float HorizontalInput;
    public float speed = 10.0f;
    public float xRange = 20.0f;
    public GameObject projectilePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");

        //Launching Banana Missiles
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch Banana Missile
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        // Keep the player Inbounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        transform.Translate(Vector3.right * Time.deltaTime * HorizontalInput * speed);

    }
}
