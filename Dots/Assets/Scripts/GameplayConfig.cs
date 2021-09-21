using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameplayConfig", menuName = "ScriptableObjects/GameplayConfig", order = 1)]
public class GameplayConfig : ScriptableObject
{
    public List<Dot> possibleDots;
    [Header("Field")]
    public int fieldHeight;
    public int fieldWidth;
}
