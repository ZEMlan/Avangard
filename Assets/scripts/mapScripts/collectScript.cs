using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectScript : MonoBehaviour
{
    public bool[] collections = new bool[8];
    public int ID;
    int trig;
    public GameObject obj;
    public Sprite highlieted;
    Sprite original;
    bool soCloser = false;
    Database data;

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {            
            obj.GetComponent<SpriteRenderer>().sprite = highlieted;
            soCloser = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            obj.GetComponent<SpriteRenderer>().sprite = original;
            soCloser = false;
        }
    }
    private void Start() {
        original = obj.GetComponent<SpriteRenderer>().sprite;
    }
    void Update()
    {
        trig = GameObject.Find("helper").GetComponent<mouse_follow>().flag;
        if (trig == ID && Input.GetMouseButtonDown(1) && soCloser) {
            Destroy(obj);
            GameObject.Find("педьестал").GetComponent<PCbuildingScript>().collects[ID - 5] = true;
            data = GameObject.Find("Main Camera").GetComponent<Inventory>().data;
            GameObject.Find("Main Camera").GetComponent<Inventory>().SearchForSameItem(data.items[ID], 1);
        }
    }
}
