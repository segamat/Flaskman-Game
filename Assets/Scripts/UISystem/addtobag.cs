using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addtobag : MonoBehaviour
{
    static addtobag tobagUI;
    // Start is called before the first frame update
    void Start()
    {
        if (!tobagUI)
        {
            tobagUI = null;
        }
        tobagUI = this;
        RefreshItem(); // 刷新物品栏
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 把背包中的物品渲染到合成界面
    public static void addItemtoBag(itemCreate item)
    {
        // 获取背包格预制体
        BagGridInfo baggridprefab = Resources.Load<BagGridInfo>("UI-preform/BagGrid");
        // 获取背包父物体
        GameObject bag = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(1).gameObject;
        // 获取背包网格
        GameObject bagGrid = bag.transform.GetChild(1).gameObject;
        // 需要创建背包格预制体，创建到背包上
        BagGridInfo newitem = Instantiate(baggridprefab, bagGrid.transform.position, Quaternion.identity);
        // 设置一下父物体
        newitem.gameObject.transform.SetParent(bagGrid.transform);

        // 赋值操作
        newitem.item = item;
        // 赋值预制体显示的图片和数量
        newitem.GetComponent<Image>().sprite = item.ItemImage;
        newitem.gameObject.transform.GetChild(0).GetComponent<Text>().text = item.ItemNum.ToString();
    }

    // 刷新物品数据
    public static void RefreshItem()
    {
        // 获取背包
        GameObject bag = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(1).gameObject;
        // 获取背包网格
        GameObject bagGrid = bag.transform.GetChild(1).gameObject;
        // 遍历背包网格内物品数量，删除所有子物体
        for (int i = 0; i < bagGrid.transform.childCount; i++){
            if (bagGrid.transform.childCount == 0) break;
            else Destroy(bagGrid.transform.GetChild(i).gameObject);
        }
        //遍历背包数据，将物品加入网格
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
        for (int i = 0; i < bagList.bagList.Count; i++)
            addItemtoBag(bagList.bagList[i]);
    }

    // 点击物品显示的内容
    public static void showItem(itemCreate item, int index)
    {
        // 获取背包
        GameObject bag = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(1).gameObject;
        // 获取背包网格
        GameObject bagGrid = bag.transform.GetChild(1).gameObject;
        // 显示按钮
        for (int i = 0; i < bagGrid.transform.childCount; i++){
            if (i == index){
                bool state = bagGrid.transform.GetChild(i).GetChild(1).gameObject.activeSelf;
                bagGrid.transform.GetChild(i).GetChild(1).gameObject.SetActive(!state);
                bagGrid.transform.GetChild(i).GetChild(1).GetComponent<Text>().text = item.name;
                bagGrid.transform.GetChild(i).GetChild(2).gameObject.SetActive(!state);
                if (item.name == "木板" && item.ItemNum == 3) item.use = true;
                if (item.name == "零件" && item.ItemNum == 3) item.use = true;
                if (item.use) bagGrid.transform.GetChild(i).GetChild(3).gameObject.SetActive(!state);

            }
            else{
                bagGrid.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
                bagGrid.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                bagGrid.transform.GetChild(i).GetChild(3).gameObject.SetActive(false);
            }
        }
    }
}
