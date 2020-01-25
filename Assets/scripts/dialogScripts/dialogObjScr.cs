using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class dialogObjScr : MonoBehaviour
{
    //блоки с информацией о нашем диалоге
    public TMP_Text SpeakerName, SpeakerPhrase;//имя и фраза говорящего
    public Image SpeakerFace;//иконка и сам блок

    int CurrentMessageNum;

    Dialog CurrentDialog;

    string QuestPath = "";
    bool NextMessageReady = false;

    public void StartDialog(Dialog dialog, string questPath)
    {
        heromove.is_moving = false;
        QuestPath = questPath;

        CurrentMessageNum = 0; //ищем все диалоги нужно нам типа
        CurrentDialog = dialog;

        transform.DOLocalMoveY(-432, 1);                                  //меняем положение блока по оси Y с анимацией
                                                                  
        ShowMessage();
    }

    void ShowMessage()
    {
        StopCoroutine("PrintMessage");  //останавливаем коррутину печатания сообщения, чтобы они не накладывались друг на друга

        DialogPhrase currentPhrase; 

        if (CurrentMessageNum < CurrentDialog.Phrases.Count)            //проверка на то, существует ли фраза
            currentPhrase = CurrentDialog.Phrases[CurrentMessageNum];
        else
        {
            EndDialog();
            return;
        }

        SpeakerFace.sprite = currentPhrase.Speaker.Face;    //назначаем элементы говорящего
        SpeakerName.text = currentPhrase.Speaker.Name;

        SpeakerPhrase.text = "";

        StartCoroutine(PrintMessage(currentPhrase.Message)); //печатаем сообщение нашего персонажа

        CurrentMessageNum++;

    }

    //побуквенная печать нашего сообщения 
    IEnumerator PrintMessage(string message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            SpeakerPhrase.text += message[i];

            if (i == message.Length - 1)
                NextMessageReady = true;

            yield return new WaitForSeconds(.0001f);  //задержкамежду буквами
        }
    }

    //задержка между сообщениями
    IEnumerator NextMessage()
    {
        yield return new WaitForSeconds(.5f);

        ShowMessage();
    }

    //окончание диалога
    void EndDialog()
    {
        heromove.is_moving = true;
        if (QuestPath != "")
            FindObjectOfType<XMLReader>().StartQuestFromXml(QuestPath);
        QuestPath = "";
        heroCounters.dialogCounter++;

        transform.DOLocalMoveY(-648, 1);         //смещаем блок диалога обратно
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && NextMessageReady)
        {
            StartCoroutine(NextMessage());
            NextMessageReady = false;
        }
    }
}
