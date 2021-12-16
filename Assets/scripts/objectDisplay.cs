using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDisplay : MonoBehaviour
{
    public GameObject VFXPrefab;

    //private void Start()
    //{
    //    Debug.Log("start~~~");
    //    readyToDisplay();
    //}

    public void readyToDisplay()
    {
        this.gameObject.SetActive(true);
        Instantiate(VFXPrefab, transform.position, transform.rotation);
    }
}
