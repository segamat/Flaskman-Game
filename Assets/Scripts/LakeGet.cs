using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeGet : MonoBehaviour
{
    // Start is called before the first frame update
    bagCreate bagList;

    // 是否可以获取盐湖水
    public static bool get = false; // 玩家是否在获取
    public static bool lake = false; // 是否在碰撞范围内
    public static bool have = true; // 是否可以获取

    public itemCreate item;
    void Start()
    {
        // 获取玩家背包
        bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
    }

    // Update is called once per frame
    void Update()
    {
        // 判断背包中是否有盐湖水，没有才可以获取
        if (bagList.bagList.Contains(item)) have = false;
        else have = true;
        // 判断玩家是否正在获取盐湖水
        if (get) GetLakes();
    }

    // 碰撞时可获取
    private void OnCollisionEnter2D(Collision2D collision)
    {
        lake = true;
    }

    // 离开碰撞范围后不可获取
    private void OnCollisionExit2D(Collision2D collision)
    {
        lake = false;
    }

    // 获取盐湖水
    private void GetLakes()
    {
        // 背包中有盐湖水则不可以获取
        for (int i = 0; i < bagList.bagList.Count; i++)
        {
            if (bagList.bagList[i].name == "盐湖水") get = false;
        }

        if (get)
        {
            addtocomposeui.additem("盐湖水");
            have = false;
        }
    }
}
