using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveCompleted : MonoBehaviour
{
    public GameObject WaveText;

    public void WaveCompletedText()
    {
        WaveText.SetActive(true);
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2f);
        WaveText.SetActive(false);
    }
}
