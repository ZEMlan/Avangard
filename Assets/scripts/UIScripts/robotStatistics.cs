using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class robotStatistics : MonoBehaviour
{
    public TMP_Text PointStatistics;

    public void OpenWindow(int score, int maxScore)
    {
        PointStatistics.text = "Кол-во очков: " + score + " / " + maxScore;
        StartCoroutine(BlockFade());
    }

    IEnumerator BlockFade()
    {
        GetComponent<CanvasGroup>().DOFade(1, 1);

        yield return new WaitForSeconds(3);

        GetComponent<CanvasGroup>().DOFade(0, 1);
    }
}
