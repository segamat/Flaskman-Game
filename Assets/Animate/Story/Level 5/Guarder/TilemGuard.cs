using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TilemGuard : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform traveller;
    public Transform player;
    private Animator anim;

    // 获取物品包裹
    public itemCreate ling;
    public itemCreate he;
    public itemCreate shi;
    public itemCreate lan;
    public itemCreate ri;
    public itemCreate rose;
    public itemCreate bai;
    public itemCreate mirror;
    bagCreate playerbag;

    // 对话内容下标
    private int index = 0;
    private int gindex = 2;
    public int flowerindex = 4;

    // 对话内容
    private string[] TilemGuardDialogue = {  "圣殿花园，外人不可入内！"
            , "好吧，你要是能在花园里找来最奇特的花，我就告诉你过迷宫的提示。"
            , "真的是很奇特，那么我将告诉你过迷宫的提示。"
            , "提示就是要时刻看见自己才能看见通往迷宫的路！"
            , "时刻看见自己？难道是需要我带着镜子吗？"};

    private string[] Flower = { "哎呀，这就是普通的花，没什么奇特的。"
            , "你看这枝花，它的花朵像一个个小坩埚倒挂着，真有趣。"
            , "这朵花像一只展翅欲飞的仙鹤，特别美丽。"
            , "小心点，这花好像能致幻。" };

    // 切换对话框时间
    private float ChangeTime;

    // 是否在碰撞范围之内
    private bool trigger = false;

    // 是否可以继续对话
    public bool star = false;
    // 得到花朵后可以继续对话
    public bool flower = false;
    public bool Labyrinth = false;

    void Start()
    {
        playerbag = Resources.Load<bagCreate>("bag/bagData/playerbag");
        traveller = GetComponent<Transform>();
        print(player);
        anim = traveller.GetChild(4).GetComponent<Animator>();
        anim.SetBool("give", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerbag.bagList.Contains(mirror))
        {
            Labyrinth = true;
        }
        else
        {
            Labyrinth = false;
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
        player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = TilemGuardDialogue[0];
        lan.use = true;
        ri.use = true;
        rose.use = true;
        bai.use = true;
        ling.use = true;
        he.use = true;
        shi.use = true;
    }

    // 碰撞范围之外
    private void OnTriggerExit2D(Collider2D collision)
    {
        star = false;
        ChangeTime = 0;
        player.GetChild(0).gameObject.SetActive(false);
        lan.use = false;
        ri.use = false;
        rose.use = false;
        bai.use = false;
        ling.use = false;
        he.use = false;
        shi.use = false;
    }

    // 切换对话
    void ChangDialogue()
    {
        if (Input.GetMouseButtonDown(0) && star)
        {
            print(index);
            player.GetChild(0).gameObject.SetActive(true);
            // 移动玩家位置
            if (player.position != traveller.GetChild(3).transform.position)
            {
                player.position = traveller.GetChild(3).transform.position;
            }
            if (index >= 0 && index <=3 && flower)
            {
                if (index == 0)
                {
                    print("flower: " + flower);
                    player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = Flower[flowerindex - 3];
                    if (flowerindex <=3)
                    {
                        index--;
                        flower = false;
                    }
                }
                else
                {
                    player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = TilemGuardDialogue[gindex];
                    gindex++;
                }
                index++;
            }
            else if(index == 0 && !flower)
            {
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = TilemGuardDialogue[1];
            }
            else if(index == 4 && Labyrinth)
            {
                Transform quest = GameObject.FindGameObjectWithTag("uisystem").transform;
                quest.GetChild(0).gameObject.SetActive(false);
                quest.GetChild(2).gameObject.SetActive(true);
            }
        }
    }

    
}
