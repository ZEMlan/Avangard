using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleHandleScript : MonoBehaviour
{
    public static GameObject consoleCanvas;
    public static bool isConsoleActive = false;
    void Start()
    {
        consoleCanvas = GameObject.FindGameObjectWithTag("Console");
        print(consoleCanvas.name);
        consoleCanvas.SetActive(false);
    }
}
