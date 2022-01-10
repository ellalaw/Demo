using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzleSelectionBGScrollController : MonoBehaviour,
    IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    public GameObject easy1;
    public GameObject easy2;
    public GameObject easy3;
    public GameObject hard1;
    GameObject swap;

    int speed = 7;
    void Start()
    {
        // TODO: select level according to global game level
        transform.position = new Vector3(
            easy1.transform.position.x,
            easy1.transform.position.y, -10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        //Debug.Log(hit.collider.gameObject.name);
        if (transform.position.x < -easy1.GetComponent<RectTransform>().sizeDelta.x)
        {
            //swap = easy3;
            //easy3 = easy1;
            //easy1.transform.position = easy3.transform.position;
            //easy1 = easy2;
            //easy2.transform.position = easy1.transform.position;
            //easy2 = swap;
            easy3.transform.position = new Vector3(
                easy2.transform.position.x * 2, 0, 0);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
