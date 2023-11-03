using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogClock : MonoBehaviour
{   
    public const float degreePerMinute = 6f, degreePerHour = 30f, degreePerSecond = 6f;

    public Transform hourHand, minuteHand, secondHand;

    TimeManager timeManager;

    void Start() {
        this.timeManager = gameObject.AddComponent<TimeManager>();

        // Fail early
        if (this.hourHand == null || this.minuteHand == null || this.secondHand == null) {
            throw new Exception("Clock's component elements are missing.");
        }

        this.RotateHandles(
            timeManager.GetHour() * degreePerHour + GetHourDegOffset(timeManager.GetMinute()),
            timeManager.GetMinute() * degreePerMinute,
            timeManager.GetSecond() * degreePerSecond
        );
    }

    void Update() {
        this.RotateHandles(
            timeManager.GetHourDelta() * degreePerHour + GetHourDegOffset(timeManager.GetMinuteDelta()),
            timeManager.GetMinuteDelta() * degreePerMinute,
            timeManager.GetSecondDelta() * degreePerSecond
        );
    }

    void RotateHandles(float hourDeg, float minuteDeg, float secondDeg) {
        this.hourHand.Rotate(0, hourDeg, 0);
        this.minuteHand.Rotate(0, minuteDeg, 0);
        this.secondHand.Rotate(0, secondDeg, 0);
    }

    float GetHourDegOffset(float minuteDelta) {
        return degreePerHour * (minuteDelta / 60);
    }
}
