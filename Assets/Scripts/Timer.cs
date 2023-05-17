using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextModif;
    float TimePassed = 0;

    void Update()
    {
        TimePassed += Time.deltaTime;

    }

    public void WriteTime()
    {
        int TimeSeconds = Mathf.RoundToInt(TimePassed);
        TextModif.text = TimeSeconds.ToString() + "s";
    }
}

