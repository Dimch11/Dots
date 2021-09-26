using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField]
    private GameplayConfig gameplayConfig;
    [SerializeField]
    private DotFieldDrawer _dotFieldDrawer;
    [SerializeField]
    private InputPanel _inputPanel;

    private DotField _dotField;
    private Vector2[,] _dotFieldCoordinates;
    private RandomDotFieldFiller _randomDotFieldFiller;
    private SelectionHandler _selectionHandler;

    public void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        // ����
        _dotField = new DotField(gameplayConfig.fieldHeight * 2, gameplayConfig.fieldWidth);

        // ����������
        var fieldCoordinatesCalculator = 
            new FieldCoordinatesCalculator(_dotField.Height, _dotField.Width, _dotFieldDrawer.DotSize);
        _dotFieldCoordinates = fieldCoordinatesCalculator.getFieldCoordinates();

        // �������� � ����������� ���������
        _dotFieldDrawer.Construct(_dotField, _dotFieldCoordinates);
        _dotFieldDrawer.DrawField();

        // ���������� ��������� ������������
        _randomDotFieldFiller = new RandomDotFieldFiller(_dotField, gameplayConfig.possibleDots);
        _randomDotFieldFiller.FillEmptyCellsInField();


        // ��������� ����� (��������� �����)
        _selectionHandler = new SelectionHandler(new AdjecentElementsFinder<Dot>(_dotField), _inputPanel);
    }
    private void DoTurn(List<GameObject> dots)
    {
        Debug.Log(dots.Count);
    }
}
