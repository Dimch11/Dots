using System;
using System.Collections.Generic;

public abstract class Field<T>
{
    public T this[int heightPos, int widthPos]
    {
        get
        {
            return cells[heightPos, widthPos];
        }
        set
        {
            cells[heightPos, widthPos] = value;
        }
    }

    public int Height { get => cells.GetLength(0); }
    public int Width { get => cells.GetLength(1); }

    protected T[,] cells;

    public Field(int height, int width)
    {
        cells = new T[height, width];
    }

    public void Clear()
    {
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                ClearCell(i, j);
            }
        }
    }
    public void ClearCells(List<(int height, int width)> cells)
    {
        foreach (var cell in cells)
        {
            ClearCell(cell.height, cell.width);
        }
    }
    public abstract void ClearCell(int height, int width);
    public abstract bool CellIsEmpty(int height, int width);
}