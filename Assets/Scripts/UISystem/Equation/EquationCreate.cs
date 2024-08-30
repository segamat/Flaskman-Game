using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "equation name", menuName = "bag/Create new equation")]
public class EquationCreate : ScriptableObject
{
    // 方程式反应物
    public string[] factor = new string[3];

    // 方程式反应条件
    public bool beam; //光照
    public bool heat; //加热、高温
    public bool electrolyze; // 电解
    public bool nocondition; // 无特殊反应条件

    // 方程式生成物
    public string[] product = new string[3];

    // 是否被使用
    public bool use;

    // 是否选择正确的条件
    public bool condition;

    // 是否需要添加生成物到背包中
    public bool additem;
}
