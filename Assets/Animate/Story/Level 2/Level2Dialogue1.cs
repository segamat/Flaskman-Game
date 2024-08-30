using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Dialogue1 : MonoBehaviour
{
    private Transform DialogueContro1;

    // 获取UI界面
    GameObject UIinterface;

    Animator playeranim;

    // 获取玩家父物体
    private Transform Player;
    private Transform time;

    // 多长时间，变换一次文本
    private float dialogueChangeTime = 0;

    // 玩家对话框内容
    private string[] Playerdialogue = { "天哪！这里有好多虫子，完全堵住了道路，我该这么消灭这些虫子呢。"
            , "看看森林里会有什么可用的东西吧。"};

    // 下标
    private int index = 0;
    private int pindex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 失活角色脚本
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();
        playerController.enabled = false;

        // 获取角色动画组件
        playeranim = GameObject.FindWithTag("Player").transform.GetChild(1).GetComponent<Animator>();
        playeranim.SetBool("right", false);
        playeranim.SetBool("left", false);
        playeranim.SetBool("righting", true);
        playeranim.SetBool("lefting", false);

        // 切换镜头
        time = GameObject.FindGameObjectWithTag("Time").transform;
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
        if (index == 3)
        {
            playeranim.SetBool("right", true);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", false);
            playeranim.SetBool("lefting", false);
            ChangeCamera.ChangeFollow();
        }
        if (index >= 5 && index <= 6)
        {
            print("index: " + index);
            ChangDialogue();
        }
        if (index == 7)
        {
            Close();
        }
    }

    // 控制对话框
    void ChangDialogue()
    {
        print(pindex);
        time.GetChild(0).gameObject.SetActive(true);
        time.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = Playerdialogue[pindex];
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
        PlayerController.WakeUI();
        // 失活剧情动画
        time.GetChild(1).gameObject.SetActive(false);
    }

}
