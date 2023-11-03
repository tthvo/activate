using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{   
    DateTime previousTime = DateTime.Now;
    DateTime currentTime = DateTime.Now;

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }

    public int GetHourDelta() {
        return currentTime.Hour - previousTime.Hour;
    }

    public int GetMinuteDelta() {
        return currentTime.Minute - previousTime.Minute;
    }

    public int GetSecondDelta() {
        return currentTime.Second - previousTime.Second;
    }

    public int GetHour() {
        return currentTime.Hour;
    }

    public int GetMinute() {
        return currentTime.Minute;
    }

    public int GetSecond() {
        return currentTime.Second;
    }

    void UpdateTime() {
        previousTime = currentTime;
        currentTime = DateTime.Now;
    }
}
