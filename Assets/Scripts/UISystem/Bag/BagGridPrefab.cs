using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagGridPrefab : MonoBehaviour
{
    public itemCreate item;

    // 当点击背包格时要执行....
    public void ItemClicked()
    {
        int index = transform.GetSiblingIndex();
        addtocomposeui.showItem(item, index);
    }

    // 点击元素1，展示到方程式中
    public void Element1Show()
    {
        int index = transform.GetSiblingIndex();
        string element = item.ItemElement1;
        addtocomposeui.showElement(item, element, index);
    }

    // 点击元素2，展示到方程式中
    public void Element2Show()
    {
        int index = transform.GetSiblingIndex();
        string element = item.ItemElement2;
        addtocomposeui.showElement(item, element, index);
    }

    // 点击元素3，展示到方程式中
    public void Element3Show()
    {
        int index = transform.GetSiblingIndex();
        string element = item.ItemElement3;
        addtocomposeui.showElement(item, element, index);
    }
}
