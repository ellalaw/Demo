using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropHandler : MonoBehaviour, IDragHandler,
    IBeginDragHandler, IEndDragHandler,
    IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject rootCanvas = null, collidedObj = null;
    public Transform originalParent;
    bool findBG;

    // Start is called before the first frame update
    void Start()
    {
        //Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //transform.position += new Vector3(1, 1, 1);
    //}

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().pivot.Set(0, 0);
        originalParent = transform.parent; // camera image
        transform.SetParent(rootCanvas.transform); // 最外层canvas
        GetComponent<PolygonCollider2D>().enabled = true;
        this.collidedObj.GetComponent<PolygonCollider2D>().enabled = true;

        //transform.position = Input.mousePosition;
        //transform.position = eventData.position;
   }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        transform.position = eventData.position;

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        //eventData.pointerCurrentRaycast.gameObject.name
        //Vector2 offset = new Vector2(0f, -transform.position.y);
        //Vector2 pos = transform.position;
        //Debug.DrawRay(pos + offset, Vector2.down, Color.red, 0.2f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        if (findBG)
        {
            transform.SetParent(collidedObj.transform);
            transform.localPosition = new Vector2(0, 0);
            GetComponent<DragDropHandler>().enabled = false;
            GetComponentInParent<SuccessJudgement>().totalFinished += 2;
            GetComponentInParent<SuccessJudgement>().Check();

            //transform.Translate(0, 0, 0);
            //transform.position = new Vector3(0, 0, 0); 世界坐标，设置到了整个图的原点处，（0，0）左下角 
        }
        else
        {
            transform.SetParent(originalParent);
            //transform.localPosition = new Vector2(0, 0);
        }
        // 这两行目的是去掉碰撞的属性，使其归位后不再互相影响
        // 但会导致OnTriggerExit2D被调用，继而导致此处findBG被设置为false
        GetComponent<PolygonCollider2D>().enabled = false;
        this.collidedObj.GetComponent<PolygonCollider2D>().enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // begin
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // end
     }

    void OnTriggerEnter2D(Collider2D collidedObject)
    {
        //int uiLayer = LayerMask.NameToLayer("UI"); 等于5

        //Debug.Log(gameObject.name);
        //TODO: 可以不用collidedObj来判断，用当前的gameObject.name+'BG'即可
        //TODO2: 判断碰撞时用collider object is touching layers，这个适用于碰撞地面，有统一属性的层

        if (collidedObj.gameObject.name == collidedObject.gameObject.name)
        {
            findBG = true;
        }
        else
        {
            findBG = false;
        }
    }

    void OnTriggerExit2D(Collider2D collidedObject)
    {
        findBG = false;
    }
}
