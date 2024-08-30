using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagsystemusing : MonoBehaviour
{
    // 地图上的通过碰撞检测拾取的物品，具体参考torchitem.cs
    // 添加物品到玩家背包,同时刷新物品栏和合成界面
    // 可以直接在函数内调用  addtocomposeui.additem(name);
    // 也可以写下这段函数
    public static void additem(string name)// name为需要添加的物品名称
    {
        bagCreate playerBag;
        itemCreate item;
        playerBag = Resources.Load<bagCreate>("bag/bagData/playerbag"); // 下载玩家背包
        item = Resources.Load<itemCreate>("bag/itemData/" + name); // 下载物品

        // 判断背包是否有这个物品
        if (!playerBag.bagList.Contains(item))
        {
            // 背包是否已满
            if (playerBag.bagList.Count <= 10)
            {
                playerBag.bagList.Add(item);
            }
            else
            {
                UIcontrol.PopUpTip(0);// 弹出对话框，提示背包已满
            }
        }
        else
        {// 物体数据是否可以叠加
            if (item.superposition)
            {
                item.ItemNum += 1;
            }
            else
            {
                // 背包是否已满
                if (playerBag.bagList.Count <= 11) playerBag.bagList.Add(item);
                else
                {
                    UIcontrol.PopUpTip(0);// 弹出对话框，提示背包已满
                }
            }
        }
        // 刷新物品栏和合成界面
        addtobag.RefreshItem();
        addtocomposeui.RefreshItem();
        
    }

    // 使用后，从玩家背包中删除物品
    // 需在可以使用物品后，将item.use置为true
    // itemCreate item = Resources.Load<itemCreate>("bag/itemData/" + name); // 下载物品
    // item.use = true;
    // 设置后点击物品栏内物品才会显示使用按键。
    // BagGridInfo.cs 中的 ItemUse() 函数，可添加使用物品的后续操作
}
