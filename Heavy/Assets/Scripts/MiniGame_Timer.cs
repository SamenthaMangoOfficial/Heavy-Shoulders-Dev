using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGame_Timer : MonoBehaviour
{
    private const float MaxTime = 600f;
    //private const float RushTime = 60;
    public float currentTime = MaxTime;
    private TextMeshProUGUI timerText;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    IEnumerator Countdown()
    {
        while (currentTime > 0)
        {
            DisplayTime();
            yield return new WaitForSeconds(1);
            currentTime -= 1;
        }
        timerText.text = "GAME END";


    }

    void DisplayTime()
    {
        int minute = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = $"{minute:00}:{seconds:00}";
    }



    //------- DEBUG KEYS
    void GameTimerDebugKeys()
    {
       //if (KeyCode.Space)
    }

}
