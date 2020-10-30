using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 origPosition;
    private Vector2 dropLocation;
    public GameObject plant;

    public MouseHandling check;
    bool checkLawn;

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
        checkLawn = check.isOnLawn;
        Vector3 spawnpos = check.posInt;
        if (checkLawn)
        {
            dropLocation = Camera.main.ScreenToWorldPoint(
            rectTransform.position);
            Instantiate(plant, spawnpos, Quaternion.identity);
            Debug.Log(spawnpos);
        }
       
        rectTransform.anchoredPosition = origPosition;
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;

    }

    public void OnPointerDown(PointerEventData eventDate)
    {
        Debug.Log("PointerDown");
    }
}
