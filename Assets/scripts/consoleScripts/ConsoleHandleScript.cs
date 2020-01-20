using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleHandleScript : MonoBehaviour
{
    public Canvas canvas;
    public static Canvas consoleCanvas;
    public static InputField input;
    public static SpriteRenderer screenRed, screenGreen;
    public static Button butNext, butOK, butExitR, butExitG;
    void Awake()
    {
        InitAll();
        consoleCanvas.gameObject.SetActive(false);
    }

    void InitAll()
    {
        consoleCanvas = canvas;
        input = consoleCanvas.gameObject.GetComponentInChildren<InputField>();
        SpriteRenderer[] screens = consoleCanvas.gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach (var scr in screens)
        {
            if (scr.gameObject.name == "ScreenRed")
                screenRed = scr;
            else
                screenGreen = scr;
        }
        screenGreen.enabled = false;
        Button[] buttons = consoleCanvas.gameObject.GetComponentsInChildren<Button>();
        foreach (var b in buttons)
        {
            if (b.gameObject.name == "ButNext")
                butNext = b;
            if (b.gameObject.name == "ButExitR")
                butExitR = b;
            if (b.gameObject.name == "ButOK")
            {
                butOK = b;
                butOK.gameObject.SetActive(false);
            }
            if (b.gameObject.name == "ButExitG")
            {
                butExitG = b;
                butExitG.gameObject.SetActive(false);
            }
        }
    }
}
