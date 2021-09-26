using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldClearer<T>
{
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
    public void ClearCell(int height, int width);
    public bool CellIsEmpty(int height, int width);
}
