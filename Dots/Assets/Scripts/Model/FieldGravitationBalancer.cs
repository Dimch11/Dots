using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGravitationBalancer<T>
{
    public event Action<Vector2, Vector2> ElementMoved;

    private readonly Field<T> _field;

    private int _curColumn;
    private int _curRow;

    public FieldGravitationBalancer(Field<T> field)
    {
        _field = field;
    }

    public void BalanceField()
    {
        for (int i = 0; i < _field.Width; i++)
        {
            _curColumn = i;
            BalanceColumn();
        }
    }
    private void BalanceColumn()
    {
        for (int i = _field.Height - 1; i >= 0; i--)
        {
            _curRow = i;
            BalanceElement();
        }
    }
    private void BalanceElement()
    {
        var newPos = FindEmptyRowInColumn();

        if (newPos != _curRow)
        {
            MoveCurElementToNewRow(newPos);
        }
    }
    private int FindEmptyRowInColumn()
    {
        for (int i = _field.Height - 1; i > _curRow; i--)
        {
            if (_field.CellIsEmpty(i, _curColumn))
            {
                return i;
            }
        }

        return _curRow;
    }
    private void MoveCurElementToNewRow(int newRow)
    {
        _field[newRow, _curColumn] = _field[_curRow, _curColumn];
        _field.ClearCell(_curRow, _curColumn);

        ElementMoved?.Invoke(new Vector2(_curRow, _curColumn), new Vector2(newRow, _curColumn));
    }
}
