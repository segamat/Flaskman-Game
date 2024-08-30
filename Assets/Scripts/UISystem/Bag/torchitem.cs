using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchitem : MonoBehaviour
{
    // Start is called before the first frame update
    // 当前父物体
    public Transform fatherItem;
    // 把数据填写到哪个背包
    public bagCreate playerBag;
    // 把数据更新到哪一个数据栏
    public itemCreate item;

    void Start()
    {
        fatherItem = GetComponent<Transform>();
        // 当场景中有多个相同的物体时，运行游戏后自动消除“（x）”
        if (fatherItem.name.Contains("("))
        {
            string[] strArray = fatherItem.name.Split(' ');
            fatherItem.name = strArray[0];
        }
        playerBag = Resources.Load<bagCreate>("bag/bagData/playerbag");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 碰撞检测,拾取路边道具时可用
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerBag.bagList.Count < 10)
            {
                // 更新数据到背包
                updateItemsAndBagData();
                Destroy(fatherItem.gameObject);
            }
            // 弹出背包已满提示
            else
            {
                UIcontrol.PopUpTip(0);
            }
        }
    }

    // 获取物品后更新数据到背包中
    public void updateItemsAndBagData()
    {
        // 判断背包是否有这个物品
        if (!playerBag.bagList.Contains(item)){
            print("add: " + item.name);
            playerBag.bagList.Add(item);
        }
        else
        {
            // 物体数据是否可以叠加
            if (item.superposition)
            {
                item.ItemNum += 1;
            }
            else
            {
                print("add: " + item.name);
                playerBag.bagList.Add(item);
            }
        }

        // 显示到合成界面
        addtocomposeui.RefreshItem();
        // 显示到背包界面
        addtobag.RefreshItem();
    }
}
