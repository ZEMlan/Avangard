using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectScript : MonoBehaviour
{
    public bool[] collections = new bool[8];
    public int ID;
    int trig;
    public GameObject obj;
    Database data;

    void Update()
    {
        trig = GameObject.Find("helper").GetComponent<mouse_follow>().flag;
        if (trig == ID && Input.GetMouseButtonDown(1)) {
            Destroy(obj);
            GameObject.Find("педьестал").GetComponent<PCbuildingScript>().collects[ID - 5] = true;
            data = GameObject.Find("Main Camera").GetComponent<Inventory>().data;
            GameObject.Find("Main Camera").GetComponent<Inventory>().SearchForSameItem(data.items[ID], 1);
        }
    }
}
