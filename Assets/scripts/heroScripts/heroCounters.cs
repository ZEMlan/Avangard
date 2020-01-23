using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroCounters : MonoBehaviour
{
    public enum Language { Csharp, Java, Python };

    public static int dialogCounter = 1;
    public static Language lang = Language.Csharp;
    public static int score = 0;
    public static int attempts = 0;
    public System.DateTime StartTime;

    private void Start()
    {
        StartTime = System.DateTime.Today;
    }
}
