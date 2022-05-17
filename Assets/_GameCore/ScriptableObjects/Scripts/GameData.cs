using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Data", order = 0)]
public class GameData : ScriptableObject
{
    public int currentLevelNumber;
    public int diamondNumber;
    public bool isSoundSettings;
}
