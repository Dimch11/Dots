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
        // поле
        _dotField = new Field<Dot>(gameplayConfig.fieldHeight * 2, gameplayConfig.fieldWidth);

        // координаты
        var fieldCoordinatesCalculator = 
            new FieldCoordinatesCalculator(_dotField.Height, _dotField.Width, _dotFieldDrawer.DotSize);
        _dotFieldCoordinates = fieldCoordinatesCalculator.getFieldCoordinates();

        // очистка поля
        _fieldClearer = new DotFieldClearer(_dotField);

        // создание и расстановка элементов
        _dotFieldDrawer.Construct(_dotField, _dotFieldCoordinates);
        _dotFieldDrawer.DrawField();

        // добавление элементам конфигураций
        _randomDotFieldFiller = new RandomDotFieldFiller(_dotField, _fieldClearer, gameplayConfig.possibleDots);
        _randomDotFieldFiller.FillEmptyCellsInField();

        // обработка ввода (выделения точек)
        _selectionHandler = new SelectionHandler(new AdjecentElementsFinder<Dot>(_dotField));
        _inputPanel.BeforeSelectionStarted += _selectionHandler.StartSelection;
        _inputPanel.TryingSelectDot += _selectionHandler.TrySelectDot;
        _inputPanel.SelectionEnded += _selectionHandler.EndSelection;

        // очистка выбранных точек когда выборка готова
        _selectionHandler.SelectionEnded += _fieldClearer.ClearCells;

        // swap элементов поля
        _fieldElementsMover = new FieldElementsMover<Dot>(_dotField);

        // балансировка после очистки
        _fieldGravitationBalancer = new FieldGravitationBalancer<Dot>(_dotField, _fieldClearer, _fieldElementsMover);
        _fieldClearer.ClearingComplete += _fieldGravitationBalancer.BalanceField;

        // заполнение поля после балансировки
        _fieldGravitationBalancer.FieldBalanced += () => StartCoroutine(FillAfterTime());


        // контроль анимаций
        _viewAnimationController = new ViewAnimationController<Dot>();
        _viewAnimationController.Construct(_dotField, _dotFieldCoordinates);
        _fieldElementsMover.BeforeElementSwap += _viewAnimationController.SwapElements;


        


        _selectionHandler.SelectionEnded += TEST;
    }
    private void TEST(List<Dot> dots)
    {
        Debug.Log(dots.Count);
    }
    private IEnumerator FillAfterTime()
    {
        yield return new WaitForSeconds(0.8f);
        _randomDotFieldFiller.FillEmptyCellsInField();
    }
}
