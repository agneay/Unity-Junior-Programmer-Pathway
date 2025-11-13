using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public float startTime = 60.0f;
    private float currentTime;
    private TextMeshProUGUI myText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = startTime;
        myText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            currentTime = 0;
            myText.text = "Time's Up!";
        }
    }
    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        myText.text = minutes + ":" + seconds;
    }
}
