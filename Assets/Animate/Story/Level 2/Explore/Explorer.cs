using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explorer : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform explorer;
    private Transform player;
    private Animator anim;

    // 获取物品
    itemCreate yinshi;
    itemCreate clock;
    string[] itemName = { "萤石", "修好的表" };

    // 对话内容下标
    private int index = 0;
    private int pindex = 0;
    private int eindex = 1;

    // 对话内容
    private string[] PlayerDialogue = { "你好呀朋友，你在这里做什么呢？"
            , "那你知道要这么消灭道路上的虫子吗，它们堵住了我的去路。"
            , "制取炸弹！你真聪明。但我不知道这么制取炸弹，你知道吗？"
            , "给，你的表修好了，快告诉我要怎么制取炸弹吧。（期待）"
            , "" };

    private string[] ExplorerDialogue = {  "奇妙的乐园，越探越有乐趣" 
            , "我在森林里探险，这里是我的游乐园，充满了未知和乐趣。"
            , "我在森林里待了好多年了，当然知道。"
            , "你要想知道就带一些沼泽后的会发光的彩色石头来交换吧."
            , "萤石真好看呀，我都不舍得拿来制作光学透镜了。"
            , "作为交换我就告诉你吧，可以制作炸弹把虫子全都消灭。"
            , "一个新的问题需要一个新的报酬，这次就让你帮我修一下我的钟表吧。"
            , "先帮我找到掉在附近的三个零件，你找到后去找住在盐湖另一头的修钟人。"
            , "修好表后我就告诉你怎么制作炸弹。"
            , "果然修好了，这其实很简单，可以用氯气和氢气在光照下产生爆炸，就可以消灭虫子了。"};

    // 切换对话框时间
    private float ChangeTime;

    // 是否在碰撞范围之内
    private bool trigger = false;

    // 是否可以继续对话
    public bool star = false;
    public bool Edia1 = false;
    public bool Edia2 = false;

    void Start()
    {
        explorer = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        yinshi = Resources.Load<itemCreate>("bag/itemData/" + itemName[0]);
        clock = Resources.Load<itemCreate>("bag/itemData/" + itemName[1]);
        anim = explorer.GetChild(4).GetComponent<Animator>();
        anim.SetBool("give", false);
    }

    // Update is called once per frame
    void Update()
    {
        Chang();
        
    }

    // 碰撞范围之内
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Explorer : " + collision.name);
        if (collision.gameObject.name == "Player")
        {
            star = true;
        }
        player.GetChild(0).gameObject.SetActive(true);
        player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ExplorerDialogue[0];
        yinshi.use = true;
        clock.use = true;
    }

    // 碰撞范围之外
    private void OnTriggerExit2D(Collider2D collision)
    {
        star = false;
        ChangeTime = 0;
        player.GetChild(0).gameObject.SetActive(false);
        yinshi.use = false;
        clock.use = false;
    }

    // 切换对话框
    void Chang()
    {
        if(Input.GetMouseButtonDown(0) && star)
        {
            player.GetChild(0).gameObject.SetActive(true);
            // 移动玩家位置
            if ( player.position != explorer.GetChild(3).transform.position )
            {
                player.position = explorer.GetChild(3).transform.position;
            }

            if (index <= 4)
            {
                Dialogue(index);
                index++;
            }
            else if (index > 4 && index <= 10 && Edia1)
            {
                Dialogue1(index);
                index++;
            }
            else if (index >= 11 && index <= 12 && Edia2)
            {
                Dialogue2(index);
                index++;
            }
            else DialogueStar();
        }
    }

    // 对话框
    void Dialogue(int index)
    {
        // 玩家内容
        if (index == 0 || index == 2)
        {
            player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = PlayerDialogue[pindex];
            pindex++;
        }
        // 探险家内容
        else
        {
            player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ExplorerDialogue[eindex];
            eindex++;
        }
    }
    void Dialogue1(int index)
    {
        // 玩家内容
        if (index == 7)
        {
            player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = PlayerDialogue[pindex];
            pindex++;
        }
        // 探险家内容
        else
        {
            player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ExplorerDialogue[eindex];
            eindex++;
        }
        if (index == 10)
        {
            Give.Imageindex(5);
            AnimationControl.Give(0, 0);
            addtocomposeui.additem("坏的表");
        }
    }
    void Dialogue2(int index)
    {
        if(index == 11)
        {
            // 玩家内容
            player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = PlayerDialogue[pindex];
            pindex++;
        }
        else
        {
            player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ExplorerDialogue[eindex];
            eindex++;
        }
    }
    void DialogueStar()
    {
        player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ExplorerDialogue[eindex - 1];
    }

}
