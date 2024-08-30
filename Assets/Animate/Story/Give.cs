using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;

public class Give : MonoBehaviour
{
    // 获取父物体
    private Transform tran;
    private Transform Player;
    public Transform Target;
    public Transform item;
    // 获取物品
    public static itemCreate Image;
    // 获取玩家和NPC动画控制组件
    Animator Anim;
    Animator PAnim;
    // 物品名称
    static string[] itemName = { "花环", "果子", "喷水的花" // 0 1 2
            , "萤石", "修好的表"  // 3 4
            , "坏的表", "零件", "酒精"  // 5 6 7 
            , "包裹", "车前草"  // 8 9
            , "消炎药", "铃兰", "望鹤兰", "尸香魔芋"  // 10 11 12 13
            , "碳酸氢钠" };    // 14

    // 动画运行时间
    float totletime = 0;
    int index = 0;
    // 物品下标
    static int imageindex = 0;
    // 玩家和NPC切换动画时间
    public int changeindex;
    public int changeindexp;
    // 关闭时间
    public int closeindex;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        tran = GetComponent<Transform>();
        Anim = Target.GetComponent<Animator>();
        PAnim = Player.GetChild(1).GetComponent<Animator>();
        item.GetComponent<SpriteRenderer>().sprite = Image.ItemImage;
    }

    // Update is called once per frame
    void Update()
    {
        totletime += Time.deltaTime;
        if (totletime > 1)
        {
            print("Give: " + index);
            totletime = 0;
            ChangAnim(index);
            ChangAnimPlay(index);
            index++;
        }
        if (index == closeindex) close();
    }

    // 切换动画
    void ChangAnim(int index)
    {
        if (index == changeindex)
        {
            Anim.SetBool("give", true);
        }
        if (index == changeindex + 2)
        {
            Anim.SetBool("give", false);
        }
    }

    // 切换动画玩家
    void ChangAnimPlay(int index)
    {
        if (index == changeindexp)
        {
            PAnim.SetBool("give", true);
            PAnim.SetBool("left", false);
            PAnim.SetBool("right", false);
            PAnim.SetBool("lefting", false);
            PAnim.SetBool("righting", false);
        }
        if (index == changeindexp + 1)
        {
            PAnim.SetBool("give", false);
            PAnim.SetBool("left", false);
            PAnim.SetBool("right", true);
            PAnim.SetBool("lefting", false);
            PAnim.SetBool("righting", false);
        }
    }

    // 关闭动画
    void close()
    {
        print("关闭动画");
        index = 0;
        item.gameObject.SetActive(false);
        tran.gameObject.SetActive(false);
    }

    // 加载物品图片
    public static void Imageindex(int index)
    {
        imageindex = index;
        Image = Resources.Load<itemCreate>("bag/itemData/" + itemName[imageindex]);
        print(Image.name);
    }

}
