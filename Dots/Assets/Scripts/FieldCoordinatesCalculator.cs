using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCoordinatesCalculator
{
    private int _fieldHeight;
    private int _fieldWidth;
    private float _cellSize;


    public FieldCoordinatesCalculator(int fieldHeight, int fieldWidth, float cellSize)
    {
        _fieldHeight = fieldHeight;
        _fieldWidth = fieldWidth;
        _cellSize = cellSize;
    }

    public Vector2[,] getFieldCoordinates()
    {
        var fieldCoordinates = new Vector2[_fieldHeight, _fieldWidth];

        for (int i = 0; i < _fieldHeight; i++)
        {
            for (int j = 0; j < _fieldWidth; j++)
            {
                fieldCoordinates[i, j] = CalcElementPosition(i, j);
            }
        }

        return fieldCoordinates;
    }
    protected Vector3 CalcElementPosition(int heightPos, int widthPos)
    {
        var startPosX = _cellSize * (_fieldWidth - 1) * -0.5f;
        var startPosY = _cellSize * (_fieldHeight - 1) * 0.5f;

        return new Vector3(startPosX + _cellSize * widthPos,
            startPosY - _cellSize * heightPos, 0);
    }
}
