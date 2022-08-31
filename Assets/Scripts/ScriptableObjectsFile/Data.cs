using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MenuData", fileName = "DataFile")]
public class Data : ScriptableObject
{
    public bool[] islevels;
    public int levelCount;
}
