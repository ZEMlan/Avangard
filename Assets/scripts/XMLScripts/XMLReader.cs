using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using UnityEngine;

public class XMLReader : MonoBehaviour
{
    public questObjScr queScr;
    public dialogObjScr dialScr;

    public void StartQuestFromXml(string path)
    {
        string savedPath = Application.dataPath;

        savedPath += "/XML/Quests/Quest" + path + ".xml";
        
        XmlDocument savedDoc = new XmlDocument();
        savedDoc.Load(savedPath);
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
        string savedPath = Application.dataPath;

        savedPath += "/XML/Dialogs/Dialog" + path + ".xml";

        XmlDocument savedDoc = new XmlDocument();
        savedDoc.Load(savedPath);
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
}
