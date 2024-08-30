using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level5Dialogue1 : MonoBehaviour
{
    // Start is called before the first frame update
    Animator playeranim;
    TilemGuard tilem;

    // 获取玩家父物体
    private Transform Player;
    private Transform time;

    // 多长时间，变换一次文本
    private float dialogueChangeTime = 0;

    // 玩家对话框内容
    private string[] Dialogue = { "我好像看到圣殿了！就在这迷宫后，太好了，我马上就能见到天神了。"
            , "站住！你是谁？这是圣殿迷宫，外人不许入内。"
            , "原来真的是圣殿，我是弗兰克斯，一个小烧瓶。"
            , "我想见见天神大人！我想成为天神大人的助手！。"
            , "天神大人可不是你想见就能见到的，就算进了花园，你也无法穿过迷宫。"
            , "我真的很想见见天神大人，求求你啦，拜托拜托！。"
            , "好吧，你要是能在花园里找来最奇特的花，我就告诉你过迷宫的提示。"};

    // 下标
    private int index = 0;
    private int pindex = 1;

    // Start is called before the first frame update
    void Start()
    {
        // 失活角色脚本
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();
        playerController.enabled = false;

        // 
        tilem = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<TilemGuard>();
        tilem.enabled = false;

        // 获取角色动画组件
        playeranim = GameObject.FindWithTag("Player").transform.GetChild(1).GetComponent<Animator>();
        print(playeranim.name);

        // 切换镜头
        time = GameObject.FindGameObjectWithTag("Time").transform;
        ChangeCamera.ChangeFollow();

        // 
        time.GetChild(0).gameObject.SetActive(true);
        time.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = Dialogue[0];

    }

    // Update is called once per frame
    void Update()
    {
        dialogueChangeTime += Time.deltaTime;
        if (dialogueChangeTime >= 1)
        {
            dialogueChangeTime = 0;
            index++;
            select(index);
        }
    }

    // 
    void select(int index)
    {
        print(index);
        if (index == 3)
        {
            playeranim.SetBool("right", false);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", true);
            playeranim.SetBool("lefting", false);
        }
        if (index == 7)
        {
            playeranim.SetBool("right", true);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", false);
            playeranim.SetBool("lefting", false);
        }
        if (index >=7 && index <=12)
        {
            ChangDialogue();
        }
        if (index == 13)
        {
            Close();
        }
    }

    // 控制对话框
    void ChangDialogue()
    {
        time.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = Dialogue[pindex];
        pindex++;
    }

    // 关闭对话框
    void Close()
    {
        time.GetChild(0).gameObject.SetActive(false);
        // 恢复角色动画
        Animator playeranim = GameObject.FindWithTag("Player").transform.GetChild(1).GetComponent<Animator>();
        playeranim.SetBool("right", true);
        playeranim.SetBool("left", false);
        playeranim.SetBool("righting", false);
        playeranim.SetBool("lefting", false);
        // 恢复角色脚本
        PlayerController playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerController.GetComponent<PlayerController>().enabled = true;
        tilem.enabled = true;
        PlayerController.WakeUI();
        // 失活剧情动画
        time.GetChild(1).gameObject.SetActive(false);
    }
}
