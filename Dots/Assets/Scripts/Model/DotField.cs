using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotField : Field<Dot>
{
    public DotField(int height, int width) : base(height, width)
    {

    }

    public override bool CellIsEmpty(int height, int width)
    {
        return cells[height, width].GetComponent<Dot>().dotConfig == null;
    }
    public override void ClearCell(int height, int width)
    {
        cells[height, width] = null;
    }
}
