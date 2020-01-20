using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consoleOpen : MonoBehaviour
{
    public GameObject NpcMark;

    private bool can_open;
    private GameObject npcMark;
    private GameObject canvas;

    void Start()
    {
        canvas = ConsoleHandleScript.consoleCanvas;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && can_open)
        {
            OpenConsole();
        }
    }

    void OpenConsole()
    {
        canvas.SetActive(true);
        ConsoleHandleScript.isConsoleActive = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !questObjScr.is_quest)
        {
            npcMark = Instantiate(NpcMark);
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
