using System;
using System.Collections.Generic;
using UnityEngine;

public class DotFieldDrawer : MonoBehaviour
{
    public GameObject DotPrefab;

    private Field<Dot> _field;
    private Vector2[,] _dotCoordinates;

    public float DotSize
    {
        get => DotPrefab.GetComponent<Renderer>().bounds.size.x;
    }

    public void Construct(Field<Dot> field, Vector2[,] dotCoordinates)
    {
        _field = field;
        _dotCoordinates = dotCoordinates;
    }

    public void DrawField()
    {
        for (int i = 0; i < _field.Height; i++)
        {
            for (int j = 0; j < _field.Width; j++)
            {
                DrawDot(i, j);
            }
        }
    }
    private void DrawDot(int Height, int Width)
    {
        var newDot = Instantiate(DotPrefab);
        newDot.transform.SetParent(transform);
        newDot.transform.localPosition = _dotCoordinates[Height, Width];
        _field[Height, Width] = newDot.GetComponent<Dot>();
    }
}
