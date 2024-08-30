using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagGridInfo : MonoBehaviour
{
    public itemCreate item;

    // 当点击背包格时要执行....
    public void ItemClicked()
    {
        int index = transform.GetSiblingIndex();
        addtobag.showItem(item, index);
        print(index);
    }

    // 点击丢弃物品，并从背包中删除该物品
    public void ItemDiscard()
    {
        // 获取点击的物品
        int index = transform.GetSiblingIndex();
        // 获取玩家背包
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
        // 获取背包UI
        GameObject bag = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(1).gameObject;
        // 获取背包格
        GameObject Grid = bag.transform.GetChild(1).gameObject;
        if (bagList.bagList[index].ItemNum == 1){
            // 删除玩家背包中的物品数据
            bagList.bagList.Remove(bagList.bagList[index]);
            // 移除背包UI
            Destroy(Grid.transform.GetChild(index).gameObject);}
        else bagList.bagList[index].ItemNum -= 1;
        // 刷新
        addtobag.RefreshItem();
    }

    // 点击物品栏使用物品，并从背包中删除该物品
    public void ItemUse()
    {
        // 获取点击的物品
        int index = transform.GetSiblingIndex();
        // 获取玩家背包
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
        // 获取背包UI
        GameObject bag = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(1).gameObject;
        // 获取背包格
        GameObject Grid = bag.transform.GetChild(1).gameObject;

        // 如为任务所需物品，添加后续操作
        //---------------关卡1-----------------//
        // 恶作剧
        if( bagList.bagList[index].name == "花环" || bagList.bagList[index].name == "果子" || bagList.bagList[index].name == "喷水的花" )
        {
            print("恶作剧用品：" + bagList.bagList[index].name);
            // 继续与NPC的对话
            Beibei bb = GameObject.FindGameObjectWithTag("beibei").transform.GetComponent<Beibei>();
            bb.Bdia2 = true;
        }

        // 获取汽车尾气、盐湖水
        if(bagList.bagList[index].name == "玻璃瓶")
        {
            // 判断背包是否有空位
            if (bagList.bagList.Count < 10)
            {
                if (ControlCar.TailGas && ControlCar.have) ControlCar.get = true; // 汽车尾气
                else if (LakeGet.have && LakeGet.lake) LakeGet.get = true; // 盐湖水
                else
                {
                    bagList.bagList[index].ItemNum++;
                    UIcontrol.PopUpTip(5);
                }
            }
            else
            {
                UIcontrol.PopUpTip(0);
                bagList.bagList[index].ItemNum++;
            }
        }

        // 狗吠反应
        if (bagList.bagList[index].name == "狗吠反应")
        {
            // 触发使用动画
            GameObject time = GameObject.FindGameObjectWithTag("Time").transform.gameObject;
            time.transform.GetChild(1).gameObject.SetActive(true);
        }
        //---------------关卡1-----------------//

        //---------------关卡2-----------------//
        // 使用木材
        if(bagList.bagList[index].name == "木板")
        {
            marsh.ChangeMarsh();
            bagList.bagList[index].ItemNum = 1;
        }

        // 采集萤石
        if (bagList.bagList[index].name == "萤石")
        {
            // 调用NPC互动动画
            Give.Imageindex(3);
            AnimationControl.Give(1,0);
            // 继续与NPC的对话
            Explorer exp = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(0).gameObject.GetComponent<Explorer>();
            exp.Edia1 = true;
            bagList.bagList[index].ItemNum = 1;
        }

        // 给予零件
        if (bagList.bagList[index].name == "零件")
        {
            // 继续与NPC的对话
            Clockman clockman = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<Clockman>();
            clockman.ljian = true;
            // 触发与NPC的交互动画
            AnimationControl.Give(1,1);
            Give.Imageindex(6);
            bagList.bagList[index].ItemNum = 1;
        }

        // 给予坏的表
        if (bagList.bagList[index].name == "坏的表")
        {
            // 继续对话
            Clockman clockman = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<Clockman>();
            clockman.clock = true;
            // 触发与NPC的交互动画
            AnimationControl.Give(1,1);
            Give.Imageindex(5);
        }

        // 给予酒精
        if (bagList.bagList[index].name == "酒精")
        {
            // 继续对话
            Clockman clockman = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<Clockman>();
            clockman.acholc = true;
            // 触发与NPC的交互动画
            Give.Imageindex(7);
            AnimationControl.Give(1,1);
        }

        // 给予修好的表
        if (bagList.bagList[index].name == "修好的表")
        {
            // 触发与NPC的交互动画
            Explorer explorer = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(0).gameObject.GetComponent<Explorer>();
            AnimationControl.Give(1,0);
            Give.Imageindex(4);
            // 继续对话
            explorer.Edia2 = true;
        }

        // 使用灭虫炸弹
        if (bagList.bagList[index].name == "灭虫炸弹")
        {
            // 触发使用动画
            GameObject time = GameObject.FindGameObjectWithTag("Time").transform.gameObject;
            time.transform.GetChild(2).gameObject.SetActive(true);
        }

        //---------------关卡2-----------------//

        //---------------关卡3-----------------//
        // 使用白磷灯
        if (bagList.bagList[index].name == "白磷")
        {
            // 开灯
            ForeGrond fore = GameObject.Find("Grid").transform.GetChild(2).gameObject.GetComponent<ForeGrond>();
            fore.lightuse = true;
            bagList.bagList[index].ItemNum++;
        }

        // 使用包裹（给旅行家）
        if (bagList.bagList[index].name == "包裹")
        {
            // 继续对话
            Traveller tra = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(0).gameObject.GetComponent<Traveller>();
            tra.pack = true;
            // 触发与NPC的交互动画
            AnimationControl.Give(1, 0);
            Give.Imageindex(8);
        }

        // 使用车前草
        if (bagList.bagList[index].name == "车前草")
        {
            // 继续对话
            Patient pat = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<Patient>();
            pat.Green = true;
            // 触发与NPC的交互动画
            AnimationControl.Give(1, 1);
            Give.Imageindex(9);
        }

        // 使用烧碱溶液
        if(bagList.bagList[index].name == "烧碱溶液")
        {
            // 触发使用动画
            GameObject time = GameObject.FindGameObjectWithTag("Time").transform.gameObject;
            time.transform.GetChild(2).gameObject.SetActive(true);
        }

        //---------------关卡3-----------------//

        //---------------关卡4-----------------//
        // 使用花朵
        if (bagList.bagList[index].name == "兰花" || bagList.bagList[index].name == "向日葵"
            || bagList.bagList[index].name == "玫瑰花" || bagList.bagList[index].name == "百合")
        {
            // 继续对话
            TilemGuard tilem = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<TilemGuard>();
            tilem.flowerindex = 3;
            tilem.flower = true;
        }

        if (bagList.bagList[index].name == "铃兰")
        {
            // 继续对话
            TilemGuard tilem = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<TilemGuard>();
            tilem.flowerindex = 4;
            tilem.flower = true;
            // 触发与NPC的交互动画
            AnimationControl.Give(1, 1);
            Give.Imageindex(11);
        }

        if (bagList.bagList[index].name == "望鹤兰")
        {
            // 继续对话
            TilemGuard tilem = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<TilemGuard>();
            tilem.flowerindex = 5;
            tilem.flower = true;
            // 触发与NPC的交互动画
            AnimationControl.Give(1, 1);
            Give.Imageindex(12);
        }

        if (bagList.bagList[index].name == "尸香魔芋")
        {
            // 继续对话
            TilemGuard tilem = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<TilemGuard>();
            tilem.flowerindex = 6;
            tilem.flower = true;
            // 触发与NPC的交互动画
            AnimationControl.Give(1, 1);
            Give.Imageindex(13);
        }
        //---------------关卡4-----------------//

        // 删除物品
        if (bagList.bagList[index].ItemNum == 1)
        {
            // 删除玩家背包中的物品数据
            bagList.bagList.Remove(bagList.bagList[index]);
            // 移除背包UI
            Destroy(Grid.transform.GetChild(index).gameObject);

        }
        else
        {
            bagList.bagList[index].ItemNum -= 1;
        }

        // 刷新
        addtobag.RefreshItem();
    }
}
