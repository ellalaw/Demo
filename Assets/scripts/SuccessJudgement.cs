using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessJudgement : MonoBehaviour
{
    [HideInInspector]
    public int totalFinished = 0;
    public GameObject filledObj = null;
    public GameObject particleObj = null;

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
            // Invoke("methodName", delayTime);
        }
    }

    private IEnumerator pause()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
        filledObj.GetComponent<objectDisplay>().readyToDisplay();
        particleObj.GetComponent<particleController>().readyToShow();
    }
}
