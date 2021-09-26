using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputPanel : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler
{
    public event Action BeforeSelectionStarted;
    public event Action<Dot> TryingSelectDot;
    public event Action SelectionEnded;

    public void OnPointerDown(PointerEventData eventData)
    {
        BeforeSelectionStarted?.Invoke();

        InvokeIfTryingSelectDot();
    }
    public void OnDrag(PointerEventData eventData)
    {
        InvokeIfTryingSelectDot();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        SelectionEnded?.Invoke();
    }

    private void InvokeIfTryingSelectDot()
    {
        var dot = GetDotUnderPointer();

        if (dot != null)
        {
            TryingSelectDot?.Invoke(dot);
        }
    }
    private Dot GetDotUnderPointer()
    {
        return Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero)
            .transform?.GetComponent<Dot>();
    }
}
