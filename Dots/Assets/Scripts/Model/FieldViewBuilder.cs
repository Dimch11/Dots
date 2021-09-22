using System.Collections.Generic;
using UnityEngine;

public abstract class FieldViewBuilder<T>
{
    protected Field<T> field;
    protected CellDrawer cellDrawer;

    public FieldViewBuilder(Field<T> field, CellDrawer cellDrawer)
    {
        this.field = field;
        this.cellDrawer = cellDrawer;
    }

    public void DrawField()
    {
        RemoveField();
        BuildField();
        FillField();
    }
    public void UpdateField()
    {
        ClearField();
        FillField();
    }

    protected void RemoveField()
    {
        cellDrawer.RemoveAllCells();
    }
    protected void BuildField()
    {
        for (int i = 0; i < field.Height; i++)
        {
            for (int j = 0; j < field.Width; j++)
            {
                cellDrawer.DrawCell(CalcCellPosition(i, j));
            }
        }
    }
    protected Vector3 CalcCellPosition(int heightPos, int widthPos)
    {
        var startPosX = cellDrawer.CellSize * (field.Width - 1) * -0.5f;
        var startPosY = cellDrawer.CellSize * (field.Height - 1) * 0.5f;

        return new Vector3(startPosX + cellDrawer.CellSize * widthPos,
            startPosY - cellDrawer.CellSize * heightPos, 0);
    }
    protected abstract void FillField();
    protected abstract void ClearField();
}
