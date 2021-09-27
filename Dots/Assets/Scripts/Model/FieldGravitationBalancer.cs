using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGravitationBalancer<T>
{
    private readonly Field<T> _field;
    private readonly FieldClearer<T> _fieldClearer;
    private readonly FieldElementsMover<T> _fieldElementsMover;

    private int _curColumn;
    private int _curRow;

    public FieldGravitationBalancer(Field<T> field, FieldClearer<T> fieldClearer, FieldElementsMover<T> fieldElementsMover)
    {
        _field = field;
        _fieldClearer = fieldClearer;
        _fieldElementsMover = fieldElementsMover;
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
        var newRow = FindEmptyRowInColumn();

        if (newRow != _curRow)
        {
            _fieldElementsMover.SwapElements((_curRow, _curColumn), (newRow, _curColumn));
        }
    }
    private int FindEmptyRowInColumn()
    {
        for (int i = _field.Height - 1; i > _curRow; i--)
        {
            if (_fieldClearer.CellIsEmpty(i, _curColumn))
            {
                return i;
            }
        }

        return _curRow;
    }
}
