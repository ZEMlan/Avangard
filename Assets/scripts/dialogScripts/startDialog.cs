using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//скрипт ставим на нпс
public class startDialog : MonoBehaviour
{

    
    public void StartDialog()
    {
        switch (heroCounters.dialogCounter)
        {
            case 1:
                FindObjectOfType<XMLReader>().StartDialogFromXml("1", "1");
                break;
            case 2:
                FindObjectOfType<XMLReader>().StartDialogFromXml("2");
                break;
            case 3:
                FindObjectOfType<XMLReader>().StartDialogFromXml("3", "2");
                FindObjectOfType<XMLReader>().SetConsoleDataFromXml("1");
                break;
            case 4:
                FindObjectOfType<XMLReader>().StartDialogFromXml("4", "3");
                FindObjectOfType<XMLReader>().SetConsoleDataFromXml("2");
                break;
            case 5:
                FindObjectOfType<XMLReader>().StartDialogFromXml("5", "4");
                FindObjectOfType<XMLReader>().SetConsoleDataFromXml("3");
                break;
            case 6:
                FindObjectOfType<XMLReader>().StartDialogFromXml("6");
                break;
            case 7:
                FindObjectOfType<XMLReader>().StartDialogFromXml("7", "5");
                FindObjectOfType<XMLReader>().SetConsoleDataFromXml("4");
                break;
            case 8:
                FindObjectOfType<XMLReader>().StartDialogFromXml("8");
                break;
            case 9:
                FindObjectOfType<XMLReader>().StartDialogFromXml("9", "6");
                break;
            }
    }

}
