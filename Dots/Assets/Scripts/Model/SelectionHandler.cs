using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionHandler
{
    public event Action<List<Dot>> SelectionEnded;

    private List<Dot> _selectedDots;
    private AdjecentElementsFinder<Dot> _adjecentElementsFinder;

    private Dot _curDot;

    public SelectionHandler(AdjecentElementsFinder<Dot> adjecentElementsFinder, InputPanel inputPanel)
    {
        _adjecentElementsFinder = adjecentElementsFinder;
        inputPanel.BeforeSelectionStarted += StartSelection;
        inputPanel.TryingSelectDot += TrySelectDot;
        inputPanel.SelectionEnded += EndSelection;
    }

    public void StartSelection()
    {
        _selectedDots = new List<Dot>();
    }
    public void TrySelectDot(Dot dot)
    {
        _curDot = dot;

        if (CanSelectDot())
        {
            _selectedDots.Add(_curDot);
        }
    }
    public void EndSelection()
    {
        SelectionEnded?.Invoke(_selectedDots);
    }

    private bool CanSelectDot()
    {
        if (_selectedDots.Count > 0)
        {
            var dotIsAlreadyInList = _selectedDots.Contains(_curDot);

            var firstDotConfig = _selectedDots[0].config;
            var dotsHaveTheSameConfig = firstDotConfig == _curDot.config;
            
            if (!dotIsAlreadyInList && dotsHaveTheSameConfig && CurDotIsAdjacentToLastSelected())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }
    private bool CurDotIsAdjacentToLastSelected()
    {
        var adjDots = _adjecentElementsFinder.GetAdjacentElements(_selectedDots[_selectedDots.Count - 1]);

        for (int i = 0; i < adjDots.Count; i++)
        {
            if (_curDot == adjDots[i])
            {
                return true;
            }
        }

        return false;
    }
}
