using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot2Task : MonoBehaviour
{
    private bool taskComplete = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !taskComplete && heroCounters.dialogCounter == 5 && tag == "Robot2")
        {
            FindObjectOfType<questObjScr>().CompleteTask();
            taskComplete = true;
        }
    }
}
