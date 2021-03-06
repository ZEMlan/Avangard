﻿using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using UnityEngine;

public class XMLReader : MonoBehaviour
{
    public questObjScr queScr;
    public dialogObjScr dialScr;
    public ConsoleScript conScr;

    public void StartQuestFromXml(string path)
    {
        string savedPath = "";

        savedPath += "XML/Quests/Quest" + path;
        
        XmlDocument savedDoc = new XmlDocument();
        savedDoc.LoadXml(Resources.Load<TextAsset>(savedPath).text);
        string questName = savedDoc.GetElementsByTagName("questName")[0].InnerText;
        XmlNodeList questTasks = savedDoc.GetElementsByTagName("questTasks")[0].ChildNodes;

        Quest quest = new Quest(questName);

        for (int i = 0; i < questTasks.Count; i++)
        {
            string task = questTasks[i].InnerText;
            quest.AddTask(task);
        }

        queScr.StartQuest(quest);
    }

    public void StartDialogFromXml(string path, string QuestPath = "")
    {
        string savedPath = "";

        savedPath += "XML/Dialogs/Dialog" + path;

        XmlDocument savedDoc = new XmlDocument();
        savedDoc.LoadXml(Resources.Load<TextAsset>(savedPath).text);
        XmlNodeList phrase = savedDoc.GetElementsByTagName("phrase");

        Dialog dialog = new Dialog();

        for (int i = 0; i < phrase.Count; i++)
        {
            string name = phrase[i].ChildNodes[0].InnerText;
            string face = phrase[i].ChildNodes[1].InnerText;
            string message = phrase[i].ChildNodes[2].InnerText;

            DialogPerson per = new DialogPerson(name, face);
            DialogPhrase phr = new DialogPhrase(per, message);

            dialog.AddPhrase(phr);
        }

        dialScr.StartDialog(dialog, QuestPath);
    }

    public void SetConsoleDataFromXml(string path)
    {
        string savedPath = "";

        savedPath += "XML/Robots/";

        switch (heroCounters.lang)
        {
            case heroCounters.Language.Csharp:
                savedPath += "C#/";
                break;
            case heroCounters.Language.Python:
                savedPath += "Python/";
                break;
            case heroCounters.Language.Java:
                savedPath += "Java/";
                break;
        }

        savedPath += "Robot" + path;

        XmlDocument savedDoc = new XmlDocument();
        savedDoc.LoadXml(Resources.Load<TextAsset>(savedPath).text);
        XmlNode mission = savedDoc.GetElementsByTagName("mission")[0];

        int points = int.Parse(mission.ChildNodes[0].InnerText);
        string task = mission.ChildNodes[1].InnerText;
        string check = mission.ChildNodes[2].InnerText;

        conScr.SetCode(task, check, points);
    }
}
