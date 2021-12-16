using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
///using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager mainManager;
    private void Awake()
    {
        mainManager = this;
        // 切换场景，删除物体，不删除自身
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        this.find();
    }

    void find()
    {
        MeshFilter filter_;
        filter_ = GetComponent<MeshFilter>();
        //Debug.Log("~~~:" + filter_);
    }

    // Update is called once per frame
    void Update()
    {
    }

}
