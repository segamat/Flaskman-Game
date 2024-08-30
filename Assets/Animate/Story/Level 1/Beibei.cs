using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beibei : MonoBehaviour
{
    // Start is called before the first frame update
    // 获取DD的脚本文件
    //Grocery DD = GameObject.FindWithTag("grocery").transform.GetComponent<Grocery>();
    private Transform DD;
    private Grocery gro;

    // 获取父物体
    private Transform BB;
    // 获取玩家父物体
    public Transform Player;

    // 获取物品花环和果子
    static string[] itemname = { "喷水的花", "果子", "花环" };
    public itemCreate flower;
    public itemCreate fruit;
    public itemCreate flowerLoop; 

    // 是否在碰撞范围内
    private bool trigger = false;
    // 是否需要触发剧情
    public bool Bdia1 = false;
    public bool Bdia2 = false;
    // 是否可以触发下一个剧情
    private bool next = false;

    // 下标
    int index = 0;
    int BBindex = 1;
    int Pindex = 0;
    // 对话内容
    private string[] BBdialogue = { "今天还没恶作剧，让我想想..."
            , "小登好像没有害怕的东西，他是我们王国的勇士。"
            , "但要是你想恶作剧的话，可以用狗叫声吸引他前去查看，注意不要被发现喔。"
            , "那就要用一个可以恶作剧的东西来交换了,可以在王国内找找看。"
            , "这真是一个好主意。"
            , "可以用提取杀虫剂中的物质加上一氧化氮，点燃就会有狗叫声了。"
            , "王国门口不远处的草丛便是极好的选择"};

    private string[] Playerdialogue = { "优优你知道小登害怕什么吗？"
            , "那优优有什么办法不被发现吗"
            , "我们找到了这个。"};


    void Start()
    {
        DD = GameObject.FindGameObjectWithTag("grocery").transform;
        gro = DD.GetComponent<Grocery>();
        BB = GetComponent<Transform>();
        print(flower);
    }

    // Update is called once per frame
    void Update()
    {
        if (gro.dia) Bdia1 = true;
        if (trigger) Dialogue();
    }

    // 在碰撞范围内，使恶作剧物品可用
    void OnCollisionEnter2D(Collision2D collision)
    {
        trigger = true;
        print("进入碰撞范围");
        if (index == 0) Bdia1 = true;
        print(Player.name);
        Player.GetChild(0).gameObject.SetActive(true);
        Player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = BBdialogue[0];
        flower.use = true;
        fruit.use = true;
        flowerLoop.use = true;
        if (Bdia1)
        {
            // 失活角色脚本
            PlayerController playerController = GameObject.FindWithTag("Player").transform.GetComponent<PlayerController>();
            playerController.enabled = false;
        }
    }

    // 在碰撞范围之外
    void OnCollisionExit2D(Collision2D collision)
    {
        trigger = false;
        flower.use = false;
        fruit.use = false;
        flowerLoop.use = false;
        print("退出碰撞范围");
        BB.GetChild(0).gameObject.SetActive(false);
        Player.GetChild(0).gameObject.SetActive(false);
    }

    // 触发剧情
    void Dialogue()
    {
        if (Input.GetMouseButtonDown(0) && Bdia1 && index <= 5)
        {
            if (index == 5)
            {
                Player.GetChild(0).gameObject.SetActive(false);
                BB.GetChild(0).gameObject.SetActive(false);
                // 恢复角色脚本
                PlayerController playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
                playerController.GetComponent<PlayerController>().enabled = true;
                Bdia1 = false;
                index--;
            }
            else if (index == 0 || index == 3)
            {
                BB.GetChild(0).gameObject.SetActive(false);
                Player.GetChild(0).gameObject.SetActive(true);
                Player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = Playerdialogue[Pindex];
                Pindex++;
            }
            else
            {
                Player.GetChild(0).gameObject.SetActive(false);
                BB.GetChild(0).gameObject.SetActive(true);
                BB.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = BBdialogue[BBindex];
                BBindex++;
            }
            index++;
        }
        else if (Input.GetMouseButtonDown(0) && Bdia2 && index <= 9)
        {
            if (index == 9)
            {
                Player.GetChild(0).gameObject.SetActive(false);
                BB.GetChild(0).gameObject.SetActive(false);
                // 恢复角色脚本
                PlayerController playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
                playerController.GetComponent<PlayerController>().enabled = true;
                Bdia2 = false;
                next = true;
                BBindex = 1;
            }
            else if (index == 5)
            {
                BB.GetChild(0).gameObject.SetActive(false);
                Player.GetChild(0).gameObject.SetActive(true);
                Player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = Playerdialogue[Pindex];
                Pindex++;
            }
            else
            {
                Player.GetChild(0).gameObject.SetActive(false);
                BB.GetChild(0).gameObject.SetActive(true);
                BB.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = BBdialogue[BBindex];
                BBindex++;
            }
            index++;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            BB.GetChild(0).gameObject.SetActive(true);
            BB.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = BBdialogue[BBindex - 1];
        }
    }
}
