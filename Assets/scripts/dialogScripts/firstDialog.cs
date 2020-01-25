using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstDialog : MonoBehaviour
{
    public startDialog DialogPlay;
    public static bool oneTime = true;

    void Start()
    {
            StartCoroutine(StartQuest());
    }

    IEnumerator StartQuest()
    {
        yield return new WaitForSeconds(0.5f);
        DialogPlay.StartDialog();
    }
}
