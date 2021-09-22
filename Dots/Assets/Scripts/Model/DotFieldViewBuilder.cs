using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotFieldViewBuilder : FieldViewBuilder<Dot>
{
    public DotFieldViewBuilder(Field<Dot> field, CellDrawer cellDrawer) : base(field, cellDrawer)
    {

    }

    protected override void FillField()
    {
        for (int i = 0; i < field.Height; i++)
        {
            for (int j = 0; j < field.Width; j++)
            {
                cellDrawer[i, j].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = field[i, j].sprite;
            }
        }
    }
    protected override void ClearField()
    {
        for (int i = 0; i < field.Height; i++)
        {
            for (int j = 0; j < field.Width; j++)
            {
                cellDrawer[i, j].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            }
        }
    }
}
