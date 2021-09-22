using System;
using System.Collections.Generic;
using UnityEngine;

public class CellDrawer : MonoBehaviour
{
    public GameObject CellPrefab;
    public float CellSize
    {
        get => CellPrefab.GetComponent<Renderer>().bounds.size.x;
    }
    public GameObject this[int heightPos, int widthPos]
    {
        get => _displayedCells[_fieldWidth * heightPos + widthPos];
    }

    private List<GameObject> _displayedCells = new List<GameObject>();
    private int _fieldWidth;


    public void Construct(int fieldWidth)
    {
        _fieldWidth = fieldWidth;
    }
    public void DrawCell(Vector3 position)
    {
        var newCell = Instantiate(CellPrefab);
        newCell.transform.SetParent(transform);
        newCell.transform.localPosition = position;
        _displayedCells.Add(newCell);
    }
    public void RemoveAllCells()
    {
        foreach (var cell in _displayedCells)
        {
            Destroy(cell);
        }
        _displayedCells.Clear();
    }
}
