using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class FieldClearer<T>
{
    protected Field<T> field;

    public FieldClearer(Field<T> field)
    {
        this.field = field;
    }

    public void Clear()
    {
        for (int i = 0; i < field.Height; i++)
        {
            for (int j = 0; j < field.Width; j++)
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
