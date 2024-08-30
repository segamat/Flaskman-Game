using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue2 : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform DialogueContro2;
    // 获取UI界面
    GameObject UIinterface;
    // 获取玩家父物体
    private Transform Player;
    private Transform time;

    private Animator dooranim;

    // 玩家对话框内容
    private string[] Playerdialogue = { "马上好了（焦急的等待）。…可以了！门开了!"
            , "我知道了斯特尔，等我回来就带你去参观圣殿，到时候我一定成为了天神的助手。"
            , "快离开吧，别被小登发现了。" };

    private string[] Frienddialogue = { "快快快，小登要回来了"
            , "弗兰斯克，你快走吧，你一定要找到圣殿呀！"
            , "你一定可以的，等你回来，弗兰斯克！" };

    // 动画运行时间
    private float totalTime = 0;
    private int index = -1;
    private int pindex = 0;
    private int findex = 0;

    void Start()
    {
        DialogueContro2 = GetComponent<Transform>();
        // 失活角色脚本
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();
        playerController.enabled = false;
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        // 恢复搅拌棒脚本
        friendControl friendcontrol = GameObject.FindWithTag("friend").GetComponent<friendControl>();
        friendcontrol.GetComponent<friendControl>().enabled = false;

        // 获取铁门动画组件
        dooranim = GameObject.FindGameObjectWithTag("door").transform.GetComponent<Animator>();

        // 关闭UI界面
        UIinterface = GameObject.FindGameObjectWithTag("uisystem").transform.gameObject;
        Destroy(UIinterface);

        // 获取时间线父物体
        time = GameObject.FindGameObjectWithTag("Time").transform;
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        if (totalTime >= 1)
        {
            index++;
            totalTime = 0;
            select(index);
        }
        
    }

    void select(int index)
    {
        if (index >= 2 && index <= 3)
        {
            Dialogue(index);
        }
        if (index == 0)
        {
            ChangeAnim(0);
        }
        if (index == 2)
        {
            ChangeAnim(2);
        }
        if (index >= 4 && index <= 7)
        {
            Dialogue(index);
        }
        if (index == 8)
        {
            time.GetChild(3).gameObject.SetActive(false);
            ChangeAnim(1);
        }
        if(index == 10)
        {
            ChangeAnim(3);
        }
        if (index == 11)
        {
            Close();
        }
    }

    // 改变角色动画效果
    void ChangeAnim(int state)
    {
        // 开门
        if (state == 0)
        {
            print("开门");
            dooranim.SetBool("open", true);
            dooranim.SetBool("close", false);
        }
        // 关门
        else if (state == 1)
        {
            print("关门");
            dooranim.SetBool("open", false);
            dooranim.SetBool("close", true);
        }
        // 打开
        else if (state == 2)
        {
            print("开");
            dooranim.SetBool("open", true);
            dooranim.SetBool("close", true);
        }
        // 恢复
        else
        {
            print("停");
            dooranim.SetBool("open", false);
            dooranim.SetBool("close", false);
        }
    }

    //  对话
    void Dialogue(int index)
    {
        time.GetChild(3).gameObject.SetActive(true);
        if (index == 3 || index == 5 || index == 6)
        {
            print("pindex: " + pindex);
            time.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = Playerdialogue[pindex];
            pindex++;
        }
        else
        {
            print("findex: " + findex);
            time.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = Frienddialogue[findex];
            findex++;
        }
    }

    // 关闭动画
    void Close()
    {
        // 加载场景下标
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
