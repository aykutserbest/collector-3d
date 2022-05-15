using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates a level object from the editor
/// </summary>
[CreateAssetMenu(fileName = "NewLevel", menuName = "ScriptableObjects/Level", order = 1)]
public class Level : ScriptableObject
{
   public int levelNumber;
   public GameObject levelMesh;
   public int holeCount;
   

}
