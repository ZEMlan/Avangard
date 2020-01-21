using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consoleOpen : MonoBehaviour
{
    public GameObject NpcMark;

    private bool can_open;
    private GameObject npcMark;
    private Canvas canvas;

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
        canvas.gameObject.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !questObjScr.is_quest)
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
