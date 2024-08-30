using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagGridPrefab : MonoBehaviour
{
    public itemCreate item;

    // �����������ʱҪִ��....
    public void ItemClicked()
    {
        int index = transform.GetSiblingIndex();
        addtocomposeui.showItem(item, index);
    }

    // ���Ԫ��1��չʾ������ʽ��
    public void Element1Show()
    {
        int index = transform.GetSiblingIndex();
        string element = item.ItemElement1;
        addtocomposeui.showElement(item, element, index);
    }

    // ���Ԫ��2��չʾ������ʽ��
    public void Element2Show()
    {
        int index = transform.GetSiblingIndex();
        string element = item.ItemElement2;
        addtocomposeui.showElement(item, element, index);
    }

    // ���Ԫ��3��չʾ������ʽ��
    public void Element3Show()
    {
        int index = transform.GetSiblingIndex();
        string element = item.ItemElement3;
        addtocomposeui.showElement(item, element, index);
    }
}
