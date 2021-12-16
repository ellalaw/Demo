using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ColliderListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
    }

    void OnTriggerExit2D(Collider2D collidedObject)
    {
        //Debug.Log("~~~~~~~~~~~trigger exit");
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        //Debug.Log("~~~~~~~~~~~collision enter");
    }
}
