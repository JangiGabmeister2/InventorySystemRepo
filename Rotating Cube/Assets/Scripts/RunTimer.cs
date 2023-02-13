using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunTimer : MonoBehaviour
{
    public TimerScriptableObject newTimer;
    public Text timerDisplay;

    private void Update()
    {
        newTimer.seconds += Time.deltaTime;

        if (newTimer.seconds == 60)
        {
            newTimer.seconds = 0;
            newTimer.minute += 1;
        }

        timerDisplay.text = $"{newTimer.minute:00}:{newTimer.seconds:00}";
    }
}
