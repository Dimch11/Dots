using System;
using System.Collections.Generic;
using UnityEngine;

public class DotFieldClearer : FieldClearer<Dot>
{
    public event Action<int, int> CellCleared;
    public event Action ClearingComplete;

    public DotFieldClearer(Field<Dot> field) : base(field)
    {

    }

    public override void ClearCell(int height, int width)
    {
        field[height, width].ClearConfig();
        CellCleared?.Invoke(height, width);
    }
    public override bool CellIsEmpty(int height, int width)
    {
        return field[height, width].config == null;
    }
    public void ClearCells(List<Dot> dots)
    {
        foreach (var dot in dots)
        {
            var pos = field.GetIndicesOfElement(dot);
            ClearCell(pos.height, pos.width);
        }

        ClearingComplete.Invoke();
    }
}
