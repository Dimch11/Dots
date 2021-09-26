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

    private Field<Dot> _dotField;
    private Vector2[,] _dotFieldCoordinates;
    private DotFieldClearer _fieldClearer;
    private RandomDotFieldFiller _randomDotFieldFiller;
    private SelectionHandler _selectionHandler;
    private FieldGravitationBalancer<Dot> _fieldGravitationBalancer;
    private FieldElementsMover<Dot> _fieldElementsMover;

    public void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        // ����
        _dotField = new Field<Dot>(gameplayConfig.fieldHeight * 2, gameplayConfig.fieldWidth);

        // ����������
        var fieldCoordinatesCalculator = 
            new FieldCoordinatesCalculator(_dotField.Height, _dotField.Width, _dotFieldDrawer.DotSize);
        _dotFieldCoordinates = fieldCoordinatesCalculator.getFieldCoordinates();

        // ������� ����
        _fieldClearer = new DotFieldClearer(_dotField);

        // �������� � ����������� ���������
        _dotFieldDrawer.Construct(_dotField, _dotFieldCoordinates);
        _dotFieldDrawer.DrawField();

        // ���������� ��������� ������������
        _randomDotFieldFiller = new RandomDotFieldFiller(_dotField, _fieldClearer, gameplayConfig.possibleDots);
        _randomDotFieldFiller.FillEmptyCellsInField();

        // ��������� ����� (��������� �����)
        _selectionHandler = new SelectionHandler(new AdjecentElementsFinder<Dot>(_dotField), _inputPanel);

        // ������� ��������� ����� ����� ������� ������
        _selectionHandler.SelectionEnded += _fieldClearer.ClearCells;

        // swap ��������� ����
        _fieldElementsMover = new FieldElementsMover<Dot>(_dotField);

        // ������������ ����� �������
        _fieldGravitationBalancer = new FieldGravitationBalancer<Dot>(_dotField, _fieldClearer, _fieldElementsMover);
        _fieldClearer.ClearingComplete += _fieldGravitationBalancer.BalanceField;


    }
    private void TEST(List<Dot> dots)
    {
        Debug.Log(dots.Count);
    }
}
