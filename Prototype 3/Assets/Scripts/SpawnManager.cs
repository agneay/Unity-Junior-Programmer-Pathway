using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] randomObstacles;
    public float startDelay = 2.0f;
    public float spawnInterval = 1.5f;
    public Vector3 spaewnPosition = new Vector3(20, 0, 0);
    private PlayerController playerControllerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("createObstacle", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void createObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int randomChoice = Random.Range(0, randomObstacles.Length);
            Instantiate(randomObstacles[randomChoice], spaewnPosition, randomObstacles[randomChoice].transform.rotation);
        }

    }
}
