using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bag",menuName = "bag/Create New Bag")]
public class bagCreate : ScriptableObject
{
    public List<itemCreate> bagList = new List<itemCreate>();
}
