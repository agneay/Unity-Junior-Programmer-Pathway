using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody ObjectRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ObjectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ObjectRb.AddForce(Vector3.forward * -speed);
    }
}
