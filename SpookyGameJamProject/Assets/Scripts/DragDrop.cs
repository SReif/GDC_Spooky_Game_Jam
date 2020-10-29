using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 origPosition;
    private Vector2 dropLocation;
    public GameObject plant;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        origPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BeginDrag");
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        dropLocation = Camera.main.ScreenToWorldPoint(
            rectTransform.position);
        rectTransform.anchoredPosition = origPosition;
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
        Instantiate(plant, new Vector2(dropLocation.x, 
            dropLocation.y), Quaternion.identity);
    }

    public void OnPointerDown(PointerEventData eventDate)
    {
        Debug.Log("PointerDown");
    }
}
