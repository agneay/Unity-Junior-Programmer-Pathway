using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public bool isGameActive = true;
    public Button restartBtn;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    private int score;
    private float spawnRate = 1.0f;
    public List<GameObject> targets;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        score = 0;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        updateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartBtn.gameObject.SetActive(true);
        isGameActive = false;
    }
}
