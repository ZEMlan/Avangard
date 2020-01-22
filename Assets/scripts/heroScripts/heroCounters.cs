using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroCounters : MonoBehaviour
{
    enum Language { Csharp, Java, Python };

    public static int dialogCounter = 1;
    static Language lang = Language.Python;
    public static int score = 0;
    public static int attempts = 0;
    public System.DateTime StartTime;

    private void Start()
    {
        StartTime = System.DateTime.Today;
    }
}
