using System.Collections;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public void PrintEvent(string s)
    {
        Debug.Log("PrintEvent: " + s + " Called at: " + Time.time);
    }
}
