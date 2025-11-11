using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 13.0f;
    public float zRange = 4.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        checkOutOfBounds();
    }

    // Moves the player based on WASD and Arrow keys
    void movePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
    }

    // Contraints the player  to the boundaries
    void checkOutOfBounds()
    {
        Vector3 pos = transform.position;

        if (pos.x < -xRange) pos.x = -xRange;
        else if (pos.x > xRange) pos.x = xRange;

        if (pos.z < -zRange) pos.z = -zRange;
        else if (pos.z > zRange) pos.z = zRange;

        transform.position = pos;

    }
}