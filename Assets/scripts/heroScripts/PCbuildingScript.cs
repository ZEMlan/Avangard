using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCbuildingScript : MonoBehaviour
{
    public GameObject progressBarObj;
    public GameObject cloud;
    public List<Sprite> clouds = new List<Sprite>();//список спрайтов облаков
    public List<Sprite> progressBarSprites = new List<Sprite>();//список спрайтов прогресс бара
    public Sprite computer;
    public bool[] collects = new bool[8] {
        false, false,
        false, false,
        false, false,
        false, false
    };
    bool ready = false, oneDate = true;
    public float delay;//скорость сборки компьютера в сек
    IEnumerator WorkOnComputer(float delay) {//корутин, анимация сборки компьютера
        cloud.GetComponent<SpriteRenderer>().sprite = clouds[0];
        for (int i = 1; i < clouds.Count; i++) {
            yield return new WaitForSeconds(delay / (clouds.Count + 1));
            cloud.GetComponent<SpriteRenderer>().sprite = clouds[i];
        }
        yield return new WaitForSeconds(delay / (clouds.Count + 1));
        cloud.transform.localScale =  new Vector3(0.5f, 0.5f);
        cloud.transform.position = new Vector3(cloud.transform.position.x,
            cloud.transform.position.y, 
            cloud.GetComponentInParent<Transform>().position.z - 1);
        cloud.GetComponent<SpriteRenderer>().sprite = computer;
    }
    public IEnumerator ProgressBar(float delay) {//корутин прогресс бара
        heromove.is_moving = false;
        progressBarObj.GetComponent<SpriteRenderer>().sprite = progressBarSprites[0];
        int x = progressBarSprites.Count;
        for (int i = 1; i < x; i++) {
            yield return new WaitForSeconds(delay / (x + 1));
            progressBarObj.GetComponent<SpriteRenderer>().sprite = progressBarSprites[i];
        }
        yield return new WaitForSeconds(delay / (x + 1));
        progressBarObj.GetComponent<SpriteRenderer>().sprite = null;
        heromove.is_moving = true;
    }
    private void Update() {
        for (int i = 0; i < 8; i++) {
            if (!collects[i]) {
                break;
            }
            ready = true;
        }
        if (ready && Input.GetKeyDown(KeyCode.E) && oneDate) {
            GameObject.Find("Main Camera").GetComponent<Inventory>().ClearInventory();
            StartCoroutine(ProgressBar(delay));
            StartCoroutine(WorkOnComputer(delay));
            oneDate = false;
        }
    }
}
