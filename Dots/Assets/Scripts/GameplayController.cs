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
    private ViewAnimationController<Dot> _viewAnimationController;

    public void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        Initializate();
        SetEvents();

        _dotFieldDrawer.DrawField();
        _randomDotFieldFiller.FillEmptyCellsInField();
    }

    private void Initializate()
    {
        InitDotField();
        InitDotFieldCoordinates();
        InitFieldClearer();
        InitDotFieldDrawer();
        InitRandomDotFiller();
        InitSelectionHandler();
        InitFieldElementsMover();
        InitFieldGravitationBalancer();
        InitViewAnimationController();
    }
    private void SetEvents()
    {
        BindSelectionHandlerToInputPanel();
        ClearCellsWhenSelectionEnded();
        BalanceFieldAfterCleaning();
        FillFieldAfterBalancing();
        BindAnimationToMover();
    }

    private void BindSelectionHandlerToInputPanel()
    {
        _inputPanel.BeforeSelectionStarted += _selectionHandler.StartSelection;
        _inputPanel.TryingSelectDot += _selectionHandler.TrySelectDot;
        _inputPanel.SelectionEnded += _selectionHandler.EndSelection;
    }
    private void ClearCellsWhenSelectionEnded()
    {
        _selectionHandler.SelectionEnded += _fieldClearer.ClearCells;
    }
    private void BalanceFieldAfterCleaning()
    {
        _fieldClearer.ClearingComplete += _fieldGravitationBalancer.BalanceField;
    }
    private void FillFieldAfterBalancing()
    {
        _fieldGravitationBalancer.FieldBalanced += () => StartCoroutine(FillAfterTime());
    }
    private IEnumerator FillAfterTime()
    {
        yield return new WaitForSeconds(0.8f);
        _randomDotFieldFiller.FillEmptyCellsInField();
    }
    private void BindAnimationToMover()
    {
        _fieldElementsMover.BeforeElementSwap += _viewAnimationController.SwapElements;
    }

    
    private void InitDotField()
    {
        _dotField = new Field<Dot>(gameplayConfig.fieldHeight * 2, gameplayConfig.fieldWidth);
    }
    private void InitDotFieldCoordinates()
    {
        var fieldCoordinatesCalculator =
                    new FieldCoordinatesCalculator(_dotField.Height, _dotField.Width, _dotFieldDrawer.DotSize);
        _dotFieldCoordinates = fieldCoordinatesCalculator.getFieldCoordinates();
    }
    private void InitFieldClearer()
    {
        _fieldClearer = new DotFieldClearer(_dotField);
    }
    private void InitDotFieldDrawer()
    {
        _dotFieldDrawer.Construct(_dotField, _dotFieldCoordinates);
    }
    private void InitRandomDotFiller()
    {
        _randomDotFieldFiller = new RandomDotFieldFiller(_dotField, _fieldClearer, gameplayConfig.possibleDots);
    }
    private void InitSelectionHandler()
    {
        _selectionHandler = new SelectionHandler(new AdjecentElementsFinder<Dot>(_dotField));
    }
    private void InitFieldElementsMover()
    {
        _fieldElementsMover = new FieldElementsMover<Dot>(_dotField);
    }
    private void InitFieldGravitationBalancer()
    {
        _fieldGravitationBalancer = new FieldGravitationBalancer<Dot>(_dotField, _fieldClearer, _fieldElementsMover);
    }
    private void InitViewAnimationController()
    {
        _viewAnimationController = new ViewAnimationController<Dot>();
        _viewAnimationController.Construct(_dotField, _dotFieldCoordinates);
    }
}
