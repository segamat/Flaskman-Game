using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Traveller : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform traveller;
    private Transform player;
    private Animator anim;

    // 获取物品包裹
    itemCreate Pack;
    string itemName = "包裹";

    // 对话内容下标
    private int index = 0;
    private int pindex = 0;
    private int tindex = 1;

    // 对话内容
    private string[] TravellerDialogue = { "哎呀，怎么办呢..."
            , "你好呀朋友，你怎么愁眉苦脸的呢？是遇到什么困难了吗？"
            , "你好小烧瓶，我的包裹不小心掉到旁边的山洞里了"
            , "可是山洞里太黑了，我看不见它在哪，唉~"
            , "我看你在这里晃来晃去的，是不是也遇到困难了？"
            , "是呀，我的路被一片呛人的雾挡住了，不知道怎么过去。"
            , "不过我可以帮你去山洞里把包裹带出来。"
            , "山洞里可黑了，没有灯是没有办法找到的"
            , "要是你真的能帮我带回包裹，我就告诉你怎么过那片雾。"
            , "一言为定！你在这里等我吧！"
            , "可以用利用白磷自燃制作一盏小灯，先用一些矿石加焦炭制取白磷吧"
            , "看！这是不是你的包裹"
            , "真的把我的包裹找到了!"
            , "那片雾其实是二氧化硫气体，只需要找到大量烧碱溶液就可以把二氧化硫全部吸收，就可以安全通过了。"};

    // 切换对话框时间
    private float ChangeTime;

    // 是否在碰撞范围之内
    private bool trigger = false;

    // 是否可以继续对话
    public bool star = false;
    // 得到包裹后可以继续对话
    public bool pack = false; 

    void Start()
    {
        traveller = GetComponent<Transform>();
        print(traveller.name);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = traveller.GetChild(0).GetComponent<Animator>();
        anim.SetBool("give", false);
        Pack = Resources.Load<itemCreate>("bag/itemData/" + itemName);
    }

    // Update is called once per frame
    void Update()
    {
        if (star)
        {
            if (ChangeTime > 1)
            {
                ChangeTime = 0;
            }
            else ChangeTime += Time.deltaTime;
        }
        ChangDialogue();
    }

    // 碰撞范围之内
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Traveller : " + collision.name);
        if (collision.gameObject.name == "Player")
        {
            star = true;
        }
        player.GetChild(0).gameObject.SetActive(true);
        player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = TravellerDialogue[0];
        Pack.use = true;
    }

    // 碰撞范围之外
    private void OnTriggerExit2D(Collider2D collision)
    {
        star = false;
        ChangeTime = 0;
        player.GetChild(0).gameObject.SetActive(false);
        Pack.use = false;
    }

    // 切换对话
    void ChangDialogue()
    {
        if (Input.GetMouseButtonDown(0) && star)
        {
            player.GetChild(0).gameObject.SetActive(true);
            // 移动玩家位置
            if (player.position != traveller.GetChild(3).transform.position)
            {
                player.position = traveller.GetChild(3).transform.position;
            }
            if(index <= 9)
            {
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = TravellerDialogue[tindex];
                tindex++;
                index++;
            }
            if (index >= 10 && index <= 12 && pack)
            {
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = TravellerDialogue[tindex];
                tindex++;
                index++;
            }
            else
            {
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = TravellerDialogue[tindex - 1];
            }
        }
    }
}
