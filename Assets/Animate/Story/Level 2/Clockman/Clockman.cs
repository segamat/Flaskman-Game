using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clockman : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform clockman;
    private Transform player;
    private Animator anim;

    // 获取物品
    itemCreate lingjian;
    itemCreate bagclock;
    itemCreate Acholc;
    string[] itemName = { "零件", "坏的表", "酒精"};

    // 对话内容下标
    private int index = 0;
    private int cindex = 1;

    // 对话内容
    private string[] ClockmanDialogue = {  "时间滴答滴答地走"
            , "你好，请问你可以帮我修一下表吗"
            , "修表那可是我的强项，我什么表都可以修好。"
            , "但这可不是免费的，你需要给我带来一些酒精做为报酬。"
            , "（这好办，酒精可以用糖类物质制取）（思考）"
            , "一言为定，你先帮我修表把，我一定会给你带来酒精的。"
            , "（现在我需要去找一点提取糖类物质的植物）"
            , "你果然带来了酒精，真是厉害。给，你的表，已经修好了"
            , "哇~，你修得真好，太感谢了。有机会再见！"};

    // 切换对话框时间
    private float ChangeTime;

    // 是否在碰撞范围之内
    private bool trigger = false;

    // 是否可以继续对话
    public bool star = false;
    public bool ljian = false;
    public bool clock = false;
    public bool acholc = false;

    void Start()
    {
        clockman = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lingjian = Resources.Load<itemCreate>("bag/itemData/" + itemName[0]);
        bagclock = Resources.Load<itemCreate>("bag/itemData/" + itemName[1]);
        Acholc = Resources.Load<itemCreate>("bag/itemData/" + itemName[2]);
        anim = clockman.GetChild(4).GetComponent<Animator>();
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
        print("Clockman : " + collision.name);
        if (collision.gameObject.name == "Player")
        {
            star = true;
        }
        player.GetChild(0).gameObject.SetActive(true);
        player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ClockmanDialogue[0];
        if (lingjian.ItemNum == 3) lingjian.use = true;
        bagclock.use = true;
        Acholc.use = true;
    }

    // 碰撞范围之外
    private void OnTriggerExit2D(Collider2D collision)
    {
        star = false;
        ChangeTime = 0;
        player.GetChild(0).gameObject.SetActive(false);
        lingjian.use = false;
        bagclock.use = false;
        Acholc.use = false;
    }

    // 切换对话
    void ChangDialogue()
    {
        if (Input.GetMouseButtonDown(0) && star)
        {
            player.GetChild(0).gameObject.SetActive(true);
            // 移动玩家位置
            if (player.position != clockman.GetChild(3).transform.position)
            {
                player.position = clockman.GetChild(3).transform.position;
            }
            if (index <= 5 && ljian && clock)
            {
                player.GetChild(0).gameObject.SetActive(true);
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ClockmanDialogue[cindex];
                cindex++;
                index++;
            }
            else if(index >=6 && index <= 7 && acholc)
            {
                player.GetChild(0).gameObject.SetActive(true);
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ClockmanDialogue[cindex];
                if(index == 7)
                {
                    Give.Imageindex(4);
                    AnimationControl.Give(0, 1);
                    addtocomposeui.additem("修好的表");
                }
                cindex++;
                index++;
            }
            else if (!acholc && ljian && clock)
            {
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ClockmanDialogue[3];
            }
            else player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ClockmanDialogue[0];
        }
    }
}
