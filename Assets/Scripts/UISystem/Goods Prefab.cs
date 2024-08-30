using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodsPrefab : MonoBehaviour
{
    public itemCreate item;

    // 当点击背包格时要执行....
    public void ItemClicked()
    {
        int index = transform.GetSiblingIndex();
        addtogrocery.ShowDetail(item, index);
    }

    // 点击购买物品
    public void PurchaseItem()
    {   // 物品下标
        int index = transform.GetSiblingIndex();
        // 获取玩家背包
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
        int itemnum = bagList.bagList.Count;
        // 获取玩家信息
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

        // 获取背包
        GameObject grocery = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(3).gameObject;
        grocery.transform.GetChild(3).GetChild(index).GetChild(2).gameObject.SetActive(false);
    }
}
