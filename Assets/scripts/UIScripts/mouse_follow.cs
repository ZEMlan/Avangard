using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_follow : MonoBehaviour{
    public GameObject theFollowing;//объект, следующий за мышью, пустышка, временно с спрайтом, для отладки(красный кружочек)
    public Vector3 mouse_position;//координаты мыши
    private Camera cam;//камера
    public int flag = -1;//переменная, отвечающая за наличие пустышки в объекте
    private void OnTriggerEnter2D(Collider2D col) {
        switch (col.gameObject.name) {
            case "MotherBoard":
                flag = 5;
                break;
            case "Graphics":
                flag = 6;
                break;
            case "HDD":
                flag = 7;
                break;
            case "Cooler":
                flag = 8;
                break;
            case "monitor":
                flag = 9;
                break;
            case "RAM":
                flag = 10;
                break;
            case "systemunit":
                flag = 11;
                break;
            case "CPU":
                flag = 12;
                break;
            default:
                flag = 2;
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        flag = -1;
    }
    void Start() {
        cam = Camera.main;//камера - та что следует за персом
    }
    void Update(){
        /*перевод глобальных координат мыши в локальные координаты камеры*/
        mouse_position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        theFollowing.transform.position = mouse_position;//передвижение пустышки
    }
}
