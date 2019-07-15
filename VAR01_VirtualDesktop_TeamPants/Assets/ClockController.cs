using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ClockController : MonoBehaviour
{
    public TextMeshPro timeText;
    DateTime currentDateTime;
    // Start is called before the first frame update
    void Start()
    {
        currentDateTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeText();
    }

    private string GetCurrentTimeString()
    {
        return DateTime.Now.ToString("hh:mm");
    }

    private void UpdateTimeText()
    {
        timeText.text = GetCurrentTimeString();
    }
}
