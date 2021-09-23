using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputPanel : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler
{
    public event Action<GameObject> DotSelected;
    public event Action<List<GameObject>> SelectionEnded;

    private DotConfig _firstSelectedDotConfig;
    private List<GameObject> _selectedDots = new List<GameObject>();

    public void OnPointerDown(PointerEventData eventData)
    {
        var hit = GetDotUnderPointer();

        if (hit.transform != null)
        {
            _firstSelectedDotConfig = hit.transform.GetComponent<Dot>().dotConfig;
            AddDotToSelectedDots(hit.transform.gameObject);
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        var hit = GetDotUnderPointer();

        if (hit.transform != null)
        {
            var isNotDotSelected = !_selectedDots.Contains(hit.transform.gameObject);
            var doesDotColorMatchFirstSelectedDot =
                hit.transform.GetComponent<Dot>().dotConfig == _firstSelectedDotConfig;

            if (isNotDotSelected && doesDotColorMatchFirstSelectedDot)
            {
                AddDotToSelectedDots(hit.transform.gameObject);
            }
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (_selectedDots.Count > 0)
        {
            SelectionEnded?.Invoke(_selectedDots);
        }
        _firstSelectedDotConfig = null;
        _selectedDots.Clear();
    }

    private RaycastHit2D GetDotUnderPointer()
    {
        return Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    }
    private void AddDotToSelectedDots(GameObject dot)
    {
        _selectedDots.Add(dot);
        DotSelected?.Invoke(dot);
    }
}
