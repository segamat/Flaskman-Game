using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class addtocomposeui : MonoBehaviour
{
    // 初始化
    static addtocomposeui toComposeUI;
    static string[] UseName = {"", "", "" };
    void Start()
    {
        if (!toComposeUI)
        {
            toComposeUI = null;
        }
        toComposeUI = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 当界面是激活状态时候调用
    private void OnEnable()
    {
        RefreshItem();
    }

    // 把背包中的物品渲染到合成界面
    public static void addItemtoCompose(itemCreate item)
    {
        // 获取背包格预制体
        BagGridPrefab baggridprefab = Resources.Load<BagGridPrefab>("UI-preform/item");
        // 获取背包父物体
        GameObject bag = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(0).gameObject;
        // 获取背包网格
        GameObject bagGrid = bag.transform.GetChild(3).gameObject;
        // 需要创建背包格预制体，创建到背包上
        BagGridPrefab newitem = Instantiate(baggridprefab, bagGrid.transform.position, Quaternion.identity);
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
        GameObject bag = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(0).gameObject;
        // 获取背包网格
        GameObject bagGrid = bag.transform.GetChild(3).gameObject;

        // 遍历背包网格内物品数量，删除所有子物体
        for (int i = 0;i < bagGrid.transform.childCount; i++)
        {
            if (bagGrid.transform.childCount == 0) break;
            else{
                Destroy(bagGrid.transform.GetChild(i).gameObject);
            }
        }

        //遍历背包数据，将物品加入
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");

        for(int i = 0;i < bagList.bagList.Count; i++)
        {
            if(bagList.bagList[i].mergy) addItemtoCompose(bagList.bagList[i]);
        }
    }

    // 添加物品到背包
    public static void additem(string name)
    {
        bagCreate playerBag;
        itemCreate item;
        playerBag = Resources.Load<bagCreate>("bag/bagData/playerbag");
        item = Resources.Load<itemCreate>("bag/itemData/" + name);

        // 判断背包是否有这个物品
        if (!playerBag.bagList.Contains(item))
        {
            // 背包是否已满
            if (playerBag.bagList.Count < 10){
                playerBag.bagList.Add(item);
            }
            else{
                // 弹出提示
                UIcontrol.PopUpTip(0);
            }
        }
        else{// 物体数据是否可以叠加
            if (item.superposition){
                item.ItemNum += item.ItemNum;
            }
            else{
                // 背包是否已满
                if (playerBag.bagList.Count < 10)playerBag.bagList.Add(item);
                else{
                    // 弹出提示
                    UIcontrol.PopUpTip(0);
                }
            }
        }
        RefreshItem();
        addtobag.RefreshItem();
    }

    // 点击物品显示的内容
    public static void showItem(itemCreate item,int index)
    {
        // 更新描述文本内容
        // 获取背包
        GameObject bag = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(0).gameObject;
        bag.transform.GetChild(5).GetComponent<Text>().text = item.ItemScription;
        // 获取背包网格
        GameObject bagGrid = bag.transform.GetChild(3).gameObject;
        // 显示按钮
        //bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
        for (int i = 0;i < bagGrid.transform.childCount; i++)
        {
            if (i == index)
            {
                int num = item.ItemElementnum;
                if(num != 0)
                {
                    num--;
                    bagGrid.transform.GetChild(i).GetChild(1).gameObject.SetActive(true);
                    bagGrid.transform.GetChild(i).GetChild(1).GetChild(0).GetComponent<Text>().text = item.ItemElement1;
                }
                if (num != 0)
                {
                    num--;
                    bagGrid.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
                    bagGrid.transform.GetChild(i).GetChild(2).GetChild(0).GetComponent<Text>().text = item.ItemElement2;
                }
                if (num != 0)
                {
                    num--;
                    bagGrid.transform.GetChild(i).GetChild(3).gameObject.SetActive(true);
                    bagGrid.transform.GetChild(i).GetChild(3).GetChild(0).GetComponent<Text>().text = item.ItemElement3;
                }
             
            }
            else
            {
                bagGrid.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
                bagGrid.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                bagGrid.transform.GetChild(i).GetChild(3).gameObject.SetActive(false);
            }
        }

    }

    // 点击元素显示到方程式中，填写方程式
    public static void showElement(itemCreate item, string element,int index)
    {
        // 获取合成界面父物体
        GameObject compose = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(0).gameObject;
        // 获取背包网格
        GameObject bagGrid = compose.transform.GetChild(3).gameObject;
        // 消除元素按钮
        for(int i = 0; i < 3; i++) bagGrid.transform.GetChild(index).GetChild(i+1).gameObject.SetActive(false);

        // 获取方程式网格
        GameObject factorList = compose.transform.GetChild(6).gameObject;
        //print(element);

        // 判断方程式是否填满
        int factornum = 0;
        if (!factorList.transform.GetChild(2).gameObject.activeSelf) {
            // 遍历方程式中的元素，查看是否有空位可填写
            for (int i = 0; i < 3; i++)
            {
                if (!factorList.transform.GetChild(i).gameObject.activeSelf)
                {
                    factorList.transform.GetChild(i).gameObject.SetActive(true);
                    factornum = i+1;

                    // 获取元素
                    factorList.transform.GetChild(i).GetComponent<Text>().text = element;
                    UseName[i] = item.name;
                    break;
                }

            }
        }

        // 判断单反应元素化学式
        bool single = false;
        bool sing = false;
        string[] name = { "饱和食盐水", "NaHCO₃", "C₆H₁₂O₆" };
        string fac = factorList.transform.GetChild(0).GetComponent<Text>().text;
        
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (scene == 4) single = false;
        else {
            for (int i = 0; i < 3; i++)
            {
                if (fac == name[i])
                {
                    sing = true;
                    break;
                }
            }
            if (sing && !factorList.transform.GetChild(1).gameObject.activeSelf) single = true;
        }

        // 判断多反应元素化学式
        bool muli = false;
        if (factorList.transform.GetChild(1).gameObject.activeSelf && !factorList.transform.GetChild(4).gameObject.activeSelf) muli = true;

        // 识别是否为有效方程式。是则填满方程式，否则提示方程式错误，清除方程式
        if (muli || single)
        {
            print(muli + "  " + single);
            EquationDataCreate EquationList = Resources.Load<EquationDataCreate>("Equation/EquationData");

            // 遍历方程式列表，寻找符合的方程式
            bool find = false; // 是否填入有效方程式
            int i = 0;
            while (i < EquationList.equationList.Count){
                // 比对方程式反应元素数量，不同则跳过
                if (factornum == EquationList.equationList[i].factor.Length){
                    // 比对元素
                    int accruate = 0;
                    for (int j = 0; j < factornum; j++){
                        string factor = factorList.transform.GetChild(j).GetComponent<Text>().text;
                        print("factor: " + factor);
                        print(EquationList.equationList[i].factor.Length);
                        for (int p = 0; p < EquationList.equationList[i].factor.Length; p++){
                            print(EquationList.equationList[i].factor[p]);
                            if (factor == EquationList.equationList[i].factor[p]){
                                accruate++;}
                        }
                    }
                    // 判断比对结果
                    if (accruate == EquationList.equationList[i].factor.Length){
                        // 打印正确方程式
                        int printlist = 4;
                        for (int q = 0; q < EquationList.equationList[i].product.Length; q++){
                            factorList.transform.GetChild(printlist).gameObject.SetActive(true);
                            factorList.transform.GetChild(printlist).GetComponent<Text>().text = EquationList.equationList[i].product[q];
                            printlist++;}
                        EquationList.equationList[i].use = true;
                        find = true;
                        break;
                    }
                }
                else EquationList.equationList[i].use = false;
                i++;
            }
            if (!find) UIcontrol.PopUpTip(1); // 弹出方程式错误提示
        }
    }

    // 点击展示可选条件
    public static void showCondition()
    {
        // 获取合成界面父物体
        GameObject compose = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(0).gameObject;
        // 获取方程式网格
        GameObject factorList = compose.transform.GetChild(6).gameObject;

        for(int i = 0; i < 4; i++)
        {
            factorList.transform.GetChild(i + 9).gameObject.SetActive(true);
        }
    }

    // 点击选择条件
    public void SelectCondition()
    {
        // 获取方程式列表
        EquationDataCreate EquationList = Resources.Load<EquationDataCreate>("Equation/EquationData");
        // 获取合成界面父物体
        GameObject compose = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(0).gameObject;
        // 获取方程式网格
        GameObject factorList = compose.transform.GetChild(6).gameObject;
        // 获取条件框
        GameObject condition = factorList.transform.GetChild(8).gameObject;

        // 关闭显示的条件
        int index = transform.GetSiblingIndex();
        for (int i = 0; i < 4; i++)
        {
            factorList.transform.GetChild(i + 9).gameObject.SetActive(false);
        }

        // 获取填写的条件
        string beam = factorList.transform.GetChild(11).GetChild(0).gameObject.GetComponent<Text>().text;
        string heat = factorList.transform.GetChild(10).GetChild(0).gameObject.GetComponent<Text>().text;
        string electrolyze = factorList.transform.GetChild(9).GetChild(0).gameObject.GetComponent<Text>().text;
        string nocondition = factorList.transform.GetChild(12).GetChild(0).gameObject.GetComponent<Text>().text;
        string str = factorList.transform.GetChild(index).GetChild(0).gameObject.GetComponent<Text>().text;
        condition.transform.GetChild(1).GetComponent<Text>().text = str;
        condition.transform.GetChild(1).gameObject.SetActive(true);
        condition.transform.GetChild(0).gameObject.SetActive(false);

        // 判断条件是否正确
        for (int i = 0; i < EquationList.equationList.Count; i++)
        {
            if (EquationList.equationList[i].use)
            {
                print(EquationList.equationList[i].name);
                if (EquationList.equationList[i].beam && (str == beam))
                {
                    EquationList.equationList[i].condition = true;
                }
                else if (EquationList.equationList[i].heat && (str == heat))
                {
                    EquationList.equationList[i].condition = true;
                }
                else if (EquationList.equationList[i].electrolyze && (str == electrolyze))
                {
                    EquationList.equationList[i].condition = true;
                }
                else if (EquationList.equationList[i].nocondition && (str == nocondition))
                {
                    EquationList.equationList[i].condition = true;
                }
                else UIcontrol.PopUpTip(2);//弹出条件错误提示
            }
        }

    }

    // 清除所填写的方程式
    public static void clearEquation(bool deleteitem)
    {
        // 获取方程式网格
        GameObject factorList = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(0).GetChild(6).gameObject;

        // 删除所填写内容
        for (int j = 0; j < 8; j++)
        {
            if (j != 3)
            {
                factorList.transform.GetChild(j).GetComponent<Text>().text = string.Empty;
                factorList.transform.GetChild(j).gameObject.SetActive(false);
            }
        }

        if (deleteitem)
        {
            // 遍历背包物品，找到使用的物品，恢复物品未使用状态
            bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
            for (int j = 0; j < bagList.bagList.Count; j++)
            {
                if (bagList.bagList[j].use && bagList.bagList[j].mergy)
                {
                    bagList.bagList[j].use = false;
                }
            }
        }

        // 恢复条件框
        factorList.transform.GetChild(8).GetChild(0).gameObject.SetActive(true);
        factorList.transform.GetChild(8).GetChild(1).GetComponent<Text>().text = string.Empty;
        factorList.transform.GetChild(8).GetChild(1).gameObject.SetActive(false);

        // 恢复使用物品列表
        UseName[1] = UseName[2] = UseName[0] = "";
    }

    // 点击合成按钮，触发生成特效
    public static void showCompose()
    {
        // 获取背包物品数量
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
        int itemnum =bagList.bagList.Count;

        // 获取方程式列表
        EquationDataCreate EquationList = Resources.Load<EquationDataCreate>("Equation/EquationData");
        // 获取合成界面父物体
        GameObject compose = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(0).gameObject;
        // 获取合成界面网格
        GameObject bagGrid = compose.transform.GetChild(3).gameObject;
        // 获取方程式网格
        GameObject factorList = compose.transform.GetChild(6).gameObject;
        // 获取合成化学式的名字
        string EquationName;
        
        // 合成
        for (int i = 0;i< EquationList.equationList.Count; i++)
        {
            if(EquationList.equationList[i].use && EquationList.equationList[i].condition)
            {
                // 查看背包物品数量，背包未满则开始合成
                if(itemnum < 10)
                {
                    // 触发合成特效
                    if (EquationList.equationList[i].additem)
                    {
                        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
                        ComposeAnimControl comainm = player.GetChild(2).gameObject.GetComponent<ComposeAnimControl>();
                        comainm.LoadImage(EquationList.equationList[i].name);
                        print(player.GetChild(2).name);
                        player.GetChild(2).gameObject.SetActive(true);
                    }

                    // 触发腐蚀反应动画
                    EquationName = EquationList.equationList[i].name;
                    if (EquationName == "腐蚀反应")
                    {
                        GameObject time = GameObject.FindGameObjectWithTag("Time").transform.gameObject;
                        time.transform.GetChild(2).gameObject.SetActive(true);
                    }

                    if (!EquationName.Contains("多"))
                    {
                        // 删除使用过的物品
                        // 遍历背包物品，找到合成使用的物品
                        int index = 0;
                        for (int j = 0; j < bagList.bagList.Count; j++)
                        {
                            // 是否为可提取物品
                            if (bagList.bagList[j].mergy) index++;
                            // 遍历使用的物品
                            for (int p = 0; p < 3; p++)
                            {
                                if (bagList.bagList[j].name == UseName[p] && bagList.bagList[j].mergy)
                                {
                                    print(index + " 删除 " + bagList.bagList[j].name);
                                    index--;
                                    bagList.bagList[j].use = false;
                                    // 删除玩家背包中的物品数据
                                    bagList.bagList.Remove(bagList.bagList[j]);
                                    // 移除背包UI
                                    Destroy(bagGrid.transform.GetChild(index).gameObject);
                                    j--;
                                    p = 3;
                                }
                            }
                        }
                        // 清除方程式
                        clearEquation(false);
                    }
                    else
                    {
                        // 合成多余物品
                        clearEquation(true);
                        UIcontrol.PopUpTip(6);
                    }
                    // 恢复方程式条件和使用痕迹
                    EquationList.equationList[i].condition = false;
                    EquationList.equationList[i].use = false;

                    // 判断是否需要添加物品到背包
                    if (EquationList.equationList[i].additem)
                    {
                        print(EquationList.equationList[i].name);
                        additem(EquationList.equationList[i].name);
                    }

                    // 刷新物品栏
                    addtobag.RefreshItem();
                    break;
                }
                else
                {
                    // 弹出提示
                    UIcontrol.PopUpTip(0);
                }
            }
            else if(EquationList.equationList[i].use && !EquationList.equationList[i].condition)
            {
                // 弹出提示
                UIcontrol.PopUpTip(1);
            }

        }
    }

    // 点击清除按钮，清空方程式
    public static void ClearClick()
    {
        clearEquation(true);
    }
}


