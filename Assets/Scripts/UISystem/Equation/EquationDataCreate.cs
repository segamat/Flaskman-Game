using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bag", menuName = "bag/Create New EquationData")]
public class EquationDataCreate : ScriptableObject
{
    public List<EquationCreate> equationList = new List<EquationCreate>();
}
