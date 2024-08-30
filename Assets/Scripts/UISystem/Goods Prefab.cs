using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodsPrefab : MonoBehaviour
{
    public itemCreate item;

    // �����������ʱҪִ��....
    public void ItemClicked()
    {
        int index = transform.GetSiblingIndex();
        addtogrocery.ShowDetail(item, index);
    }

    // ���������Ʒ
    public void PurchaseItem()
    {   // ��Ʒ�±�
        int index = transform.GetSiblingIndex();
        // ��ȡ��ұ���
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
        int itemnum = bagList.bagList.Count;
        // ��ȡ�����Ϣ
        PlayerController playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        int fund = playerController.fund;
        if(fund >= item.price){
            if(itemnum < 10){
                addtocomposeui.additem(item.name);
                playerController.fund -= item.price;
                addtobag.RefreshItem();
            }
            else UIcontrol.PopUpTip(0);
        }
        else UIcontrol.PopUpTip(4);

        // ��ȡ����
        GameObject grocery = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(3).gameObject;
        grocery.transform.GetChild(3).GetChild(index).GetChild(2).gameObject.SetActive(false);
    }
}
