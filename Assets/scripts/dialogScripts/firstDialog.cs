using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstDialog : MonoBehaviour
{
    public startDialog DialogPlay;

    // Start is called before the first frame update
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
