using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Timer", fileName = "timerSO")]
public class TimerScriptableObject : ScriptableObject
{
    public float seconds;
    public int minute;
}
