using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessJudgement : MonoBehaviour
{
    [HideInInspector]
    public int totalFinished = 0;
    public GameObject filledObj = null;

    private void Start()
    {
        // Debug.Log(GetComponentsInChildren<PolygonCollider2D>().Length); //12
        // Debug.Log(totalFinished); //0
    }

    public void Check()
    {
        if (gameObject.GetComponentsInChildren<PolygonCollider2D>().Length == totalFinished)
        {
            StartCoroutine(pause());
        }
    }

    private IEnumerator pause()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
        filledObj.GetComponent<objectDisplay>().readyToDisplay();
    }
}
