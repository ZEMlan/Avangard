using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class ClickedOnPuzzle : MonoBehaviour
{
    public GameObject NpcMark;
    public int MaxQuestCount;
    public int MinQuestCount;
    public GameObject PuzzleCanvas;
    public List<GameObject> Pieces_of_puzzle = new List<GameObject>(15);
    public string[] tags = new string[] {"Image1", "Image2", "Image3", "Image4", "Image5", "Image6", "Image7", "Image8", "Image9", "Image10", "Image11", "Image12", "Image13", "Image14", "Image15"};
    public List<float> Point_x = new List<float>();
    public List<float> Point_y = new List<float>();
    public int num;
    private bool check = false;
    private Transform curObj;

    GameObject npcMark;
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && check)
        {
            PuzzleCanvas.SetActive(true);
            Time.timeScale = 0;

            for (int i = 0; i < num; i++)
            {
                int x = UnityEngine.Random.Range(-800, 800);
                while (x > 800 || x < -800)
                {
                    x = UnityEngine.Random.Range(-800, 800);
                }
                int y = UnityEngine.Random.Range(-380, 380);
                while (y > 380 || y < -380)
                {
                    y = UnityEngine.Random.Range(-380, 380);
                }
                Point_x.Add(x);
                Point_y.Add(y);
            }

            for (int i = 0; i < num; i++)
            {
                Pieces_of_puzzle[i].transform.position = new Vector3(Point_x[i] + 960, Point_y[i] + 540, 0);
                Pieces_of_puzzle[i].SetActive(true);
            }
        }

        if (Input.GetMouseButton(0))
        {
            for (int i = 0; i < num; i++)
            {
                if (Input.mousePosition.x - 960 <= Point_x[i] + 125 && Input.mousePosition.x - 960 >= Point_x[i] - 125 && Input.mousePosition.y - 540 <= Point_y[i] + 125 && Input.mousePosition.y - 540 >= Point_y[i] - 125)
                {
                    //Pieces_of_puzzle[i].SetActive(false);
                    Pieces_of_puzzle[i].transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
                    //Pieces_of_puzzle[i].SetActive(true);
                    Point_x[i] = Input.mousePosition.x - 960;
                    Point_y[i] = Input.mousePosition.y - 540;
                    
                    /*for (int j = 0; j < 0; j++)
                    {
                        if (i != j && Point_x[i] == Point_x[j] && Point_y[i] == Point_y[j])
                        {
                            if (Point_x[j] <= 0)
                            {
                                Point_x[j] += 90;
                            }
                            else
                            {
                                Point_x[j] -= 90;
                            }

                            if (Point_y[j] <= 0)
                            {
                                Point_y[j] += 90;
                            }
                            else
                            {
                                Point_y[j] -= 90;
                            }
                            Pieces_of_puzzle[j].transform.position = new Vector3(Point_x[j], Point_y[j], 0);
                        }
                    }*/
                }
            }
        }
        
        /*void Moving()
        {
            Pieces_of_puzzle[1].transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            if (Input.GetMouseButton(0))
            {
                Pieces_of_puzzle[0].transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
                Ray ray;
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (GetTag(hit.transform.tag) && hit.rigidbody && !curObj)
                    {
                        curObj = hit.transform;
                        curObj.position += new Vector3(0, 0.5f, 0);
                    }
                }
            }

            if (curObj)
				{
					curObj.GetComponent<Rigidbody2D>().MovePosition(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
				}
        }*/
    }

    /*void AddTriggerEvent()
    {
        for (int i = 0; i < num; i++)
        {
            EventTrigger et = null;
            GameObject obj = Pieces_of_puzzle[i];

            if (obj.GetComponent<EventTrigger>())
            {
                et = obj.GetComponent<EventTrigger>();
                var t = new EventTrigger.TriggerEvent();
                t.AddListener(data => {
                    data.Use();
                    curObj = obj;
                });
                et.delegates.Add(new EventTrigger.Entry{callback = t, eventID = EventTriggerType.PointerDown});
                t = new EventTrigger.TriggerEvent();
                t.AddListener(data => {
                    var ev = (PointerEventData)data;
                    ev.Use();
                    curObj.transform.position = ev.position;
                });
                et.delegates.Add(new EventTrigger.Entry{callback = t, eventID = EventTriggerType.Drag});
            }
        }
    }

    void ClearTriggerEvent()
    {
        for(int i = 0; i < num; i++)
        {
            EventTrigger et = null;
            GameObject obj = Pieces_of_puzzle[i];
            if (obj.GetComponent<EventTrigger>())
            {
                et = obj.GetComponent<EventTrigger>();
                et.delegates.Clear();
            }
        }
    }*/

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !questObjScr.is_quest && heroCounters.questCounter >= MinQuestCount && heroCounters.questCounter <= MaxQuestCount)
        {
            npcMark = Instantiate(NpcMark);
            npcMark.transform.position = transform.position;
            npcMark.transform.position += new Vector3(0, 1.5f, 0);
            check = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(npcMark);
        check = false;
    }

    public void ExitPuzzle()
    {
        PuzzleCanvas.SetActive(false);
        Time.timeScale = 1;
        for (int i = 0; i < num; i++)
        {
            Point_x.Remove(Point_x[i]);
            Point_y.Remove(Point_y[i]);
        }
    }
    
    /*bool GetTag (string curTag) 
	{
		bool result = false;
		foreach (string t in tags)
		{
			if (t == curTag) result = true;
		}
		return result;
	}*/
}
