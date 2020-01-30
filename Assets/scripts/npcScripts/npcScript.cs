using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{
    public GameObject NpcMark;
    public startDialog DialogPlay;
    public List<int> dialogNumbers;

    GameObject npcMark;
    private bool is_dialog = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && is_dialog)
        {
            StartDialog();
        }
    }

    //начинаем диалог, останавливаем персонажа
    public void StartDialog()
    {
        Destroy(npcMark);
        DialogPlay.StartDialog();
        is_dialog = false;
    }

    //начинаем диалог, когда персонаж попадает в триггер
    // нужно будет сделать, чтобы диалог начинался ещё после нажатия определенной кнопки
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !questObjScr.is_quest && dialogNumbers.Contains(heroCounters.dialogCounter) && !questObjScr.is_quest)
        {
            npcMark = Instantiate(NpcMark);
            npcMark.transform.position = transform.position;
            npcMark.transform.position += new Vector3(0, 1.25f, 0);
            is_dialog = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        is_dialog = false;
    }
}
