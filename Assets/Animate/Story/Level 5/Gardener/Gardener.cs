using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gardener : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform gardener;
    private Transform player;
    private Animator anim;

    // 对话内容下标
    public int index = 0;
    public int gindex = 1;

    // 对话内容
    private string[] GardenerDialogue = {  "浇花浇花，让小花快快长大。"
            , "哎呀，你是来找圣殿的吗？现在能找到这里的人可不多喽。"
            , "是的，我能找到圣殿，也是多亏了许多人的帮忙。"
            , "园丁先生，你在这里待了这么久，知不知道哪里有镜子呢？"
            , "你这么快就想到了过迷宫的关键了，真是聪明。"
            , "我是有镜子，但是想过迷宫只能用自己的镜子哟。"
            , "但你要是能回答我一个问题，我就给你一点提示。"
            , "好，放马过来吧。"
            , "很遗憾，你答错了。"
            , "我只能告诉你制取镜子需要用到银氨溶液和一个玻璃容器。"
            , "恭喜你答对啦，这是【消炎药】，制取银氨溶液的原料之一"
            , "有了银氨溶液和一个玻璃容器才能制作镜子"
            , "谢谢园丁先生，我一定可以制造出我的镜子的！"};

    // 切换对话框时间
    private float ChangeTime;

    // 是否在碰撞范围之内
    private bool trigger = false;

    // 是否可以继续对话
    public bool star = false;
    // 是否答对
    public bool answer = false;

    void Start()
    {
        gardener = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = gardener.GetChild(4).GetComponent<Animator>();
        anim.SetBool("give", false);
    }

    // Update is called once per frame
    void Update()
    {
        ChangDialogue();
    }

    // 碰撞范围之内
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Gardener : " + collision.name);
        if (collision.gameObject.name == "Player")
        {
            star = true;
        }
        player.GetChild(0).gameObject.SetActive(true);
        player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = GardenerDialogue[0];
    }

    // 碰撞范围之外
    private void OnTriggerExit2D(Collider2D collision)
    {
        star = false;
        ChangeTime = 0;
        player.GetChild(0).gameObject.SetActive(false);
    }

    // 切换对话
    void ChangDialogue()
    {
        if (Input.GetMouseButtonDown(0) && star)
        {
            player.GetChild(0).gameObject.SetActive(true);
            print(index);
            // 移动玩家位置
            if (player.position != gardener.GetChild(3).transform.position)
            {
                player.position = gardener.GetChild(3).transform.position;
            }
            if (index <= 6)
            {
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = GardenerDialogue[gindex];
                gindex++;
                index++;
            }
            else if (index == 7 && !answer)
            {
                print("打开问题");
                Transform quest = GameObject.FindGameObjectWithTag("uisystem").transform;
                quest.GetChild(0).gameObject.SetActive(false);
                quest.GetChild(1).gameObject.SetActive(true);
            }
            else if(!answer && index >= 8 && index <=9)
            {
                print("回答错误");
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = GardenerDialogue[gindex];
                gindex++;
                index++;
            }
            else if(answer && index >= 8 && index <= 9)
            {
                print("回答正确");
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = GardenerDialogue[gindex];
                gindex++;
                index++;
                if (index == 9)
                {
                    Give.Imageindex(10);
                    AnimationControl.Give(0, 0);
                    addtocomposeui.additem("消炎药");
                }
            }
            else if (index == 10)
            {
                gindex = 12;
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = GardenerDialogue[gindex];
                gindex++;
            }
            else player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = GardenerDialogue[0];
        }
    }
}