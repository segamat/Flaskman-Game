using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item name",menuName = "bag/Create new item")]
public class itemCreate : ScriptableObject
{
    //物品名
    public string ItemName;

    //物品图片
    public Sprite ItemImage;

    //物品描述
    public string ItemScription;

    //物品数量
    public int ItemNum;

    //物品所含元素
    public int ItemElementnum;
    public string ItemElement1;
    public string ItemElement2;
    public string ItemElement3;

    //商品所需金币
    public int price;

    //是否可以提取元素
    public bool mergy;

    //是否可以使用物品
    public bool use;

    //是否可以累加物品
    public bool superposition;
    
}
