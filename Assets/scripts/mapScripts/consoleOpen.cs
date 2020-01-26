using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consoleOpen : MonoBehaviour
{
    public GameObject NpcMark;
    public int numberDialog;
    public ConsoleScript consoleScript;

    public static bool firstTime = true;

    public static bool can_open = false;
    public static bool need_to_update = false;
    public static bool is_open = false;
    private GameObject npcMark;
    private Canvas canvas;


    void Start()
    {
        canvas = ConsoleHandleScript.consoleCanvas;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && can_open && !is_open)
        {
            Destroy(npcMark);
            if (!is_open)
                if (heroCounters.dialogCounter == 9)
                    consoleScript.OpenFinalConsole();
                else
                    OpenConsole();
            is_open = true;
        }
    }

    void OpenConsole()
    {
        canvas.gameObject.SetActive(true);
        if (need_to_update)
        {
            ConsoleScript.UpdateTask();
            need_to_update = false;
        }
        heromove.is_moving = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && numberDialog == heroCounters.dialogCounter && questObjScr.is_quest)
        {
            npcMark = Instantiate(NpcMark) as GameObject;
            npcMark.transform.position = transform.position;
            npcMark.transform.position += new Vector3(0, 1.25f, 0);
            can_open = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(npcMark);
        can_open = false;
    }
}
