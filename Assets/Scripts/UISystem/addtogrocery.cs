using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addtogrocery : MonoBehaviour
{
    static addtogrocery togroceryUI;
    private Transform Grocery;
    int fund;
    // Start is called before the first frame update
    void Start()
    {
        if (!togroceryUI)
        {
            togroceryUI = null;
        }
        togroceryUI = this;
        ShowGoods();
        
    }

    // Update is called once per frame
    void Update()
    {
        fund = GameObject.FindWithTag("Player").GetComponent<PlayerController>().fund;
        Grocery = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(3).GetChild(6).transform;
        Grocery.GetChild(0).GetComponent<Text>().text = fund.ToString();
    }

    // 添加物品到小卖部界面
    void addItem(itemCreate item)
    {
        // 获取背包格预制体
        GoodsPrefab goods = Resources.Load<GoodsPrefab>("UI-preform/goods");
        // 获取背包父物体
        GameObject grocery = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(3).gameObject;
        // 获取背包网格
        GameObject groceryGrid = grocery.transform.GetChild(3).gameObject;
        // 需要创建背包格预制体，创建到背包上
        GoodsPrefab newitem = Instantiate(goods, groceryGrid.transform.position, Quaternion.identity);
        // 设置一下父物体
        newitem.gameObject.transform.SetParent(groceryGrid.transform);

        // 赋值操作
        newitem.item = item;
        // 赋值预制体显示的图片和数量
        newitem.GetComponent<Image>().sprite = item.ItemImage;
        newitem.gameObject.transform.GetChild(1).GetComponent<Text>().text = item.price.ToString();
    }

    // 渲染物品进UI界面
    void ShowGoods()
    {
        // 获取小卖部数据库
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/groceryBag");
        
        for (int i = 0; i < bagList.bagList.Count; i++)
        {
            addItem(bagList.bagList[i]);
        }
    }

    // 点击显示详细内容
    public static void ShowDetail(itemCreate item, int index)
    {
        // 更新描述文本内容
        // 获取背包
        GameObject grocery = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(3).gameObject;
        // 获取背包网格
        GameObject groceryGrid = grocery.transform.GetChild(3).gameObject;
        // 显示按钮
        for (int i = 0; i < groceryGrid.transform.childCount; i++)
        {
            if (i == index)
            {
                print(index);
                GameObject good = grocery.transform.GetChild(3).GetChild(index).GetChild(2).gameObject;
                good.SetActive(!good.activeSelf);
                grocery.transform.GetChild(3).GetChild(index).GetChild(1).GetComponent<Text>().text = item.price.ToString();
                grocery.transform.GetChild(4).GetComponent<Text>().text = item.ItemScription;
            }
        }
    }

}
