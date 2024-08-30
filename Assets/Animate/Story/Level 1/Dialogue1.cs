using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue1 : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform DialogueControl;
    // 获取UI界面
    GameObject UIinterface;
    // 获取玩家父物体
    private Transform Player;
    // 玩家对话框内容
    string Playerdialogue = "我们需要尽快把锁破坏了，就按照DD说的方法";

    // 动画运行时间
    private float totalTime = 0;
    private int index = 0;

    void Start()
    {
        DialogueControl = GetComponent<Transform>();
        // 失活角色脚本
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();
        playerController.enabled = false;

        Player = GameObject.FindGameObjectWithTag("Player").transform;

        // 
        UIinterface = GameObject.FindGameObjectWithTag("uisystem").transform.gameObject;
        Destroy(UIinterface);
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        if(totalTime >= 1)
        {
            index++;
            totalTime = 0;
        }
        if (index == 4)
        {
            ChangeAnim(0);
        }
        if (index == 7)
        {
            ChangeAnim(1);
        }
        if (index == 10)
        {
            ChangeAnim(2);
        }
        if (index == 11)
        {
            Dialogue();
        }
        if (index == 13)
        {
            Close();
        }
    }

    // 改变角色动画效果
    void ChangeAnim(int state)
    {
        // 获取角色动画组件
        Animator playeranim = GameObject.FindWithTag("Player").transform.GetComponent<Animator>();

        // 向左走
        if (state == 0)
        {
            print("向左走");
            playeranim.SetBool("right", false);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", false);
            playeranim.SetBool("lefting", true);
        }
        // 向上走
        else if(state == 1)
        {
            print("向上走");
            playeranim.SetBool("right", false);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", true);
            playeranim.SetBool("lefting", false);
        }
        // 停
        else
        {
            print("停");
            playeranim.SetBool("right", true);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", false);
            playeranim.SetBool("lefting", false);
        }
    }

    // 
    void Dialogue()
    {
        Player.GetChild(0).gameObject.SetActive(true);
        Player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = Playerdialogue;
    }
 
    // 
    void Close()
    {
        // 恢复角色动画
        Animator playeranim = GameObject.FindWithTag("Player").transform.GetComponent<Animator>();
        playeranim.SetBool("right", true);
        playeranim.SetBool("left", false);
        playeranim.SetBool("righting", false);
        playeranim.SetBool("lefting", false);
        // 恢复角色脚本
        PlayerController playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerController.GetComponent<PlayerController>().enabled = true;
        PlayerController.WakeUI();
        Player.GetChild(0).gameObject.SetActive(false);
        // 恢复搅拌棒脚本
        friendControl friendcontrol = GameObject.FindWithTag("friend").GetComponent<friendControl>();
        friendcontrol.GetComponent<friendControl>().enabled = true;
        // 打开UI界面
        GameObject UI = GameObject.FindGameObjectWithTag("uisystem").transform.gameObject;
        UI.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        UI.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        UI.transform.GetChild(0).GetChild(0).GetChild(6).GetChild(0).gameObject.SetActive(true);
        UI.transform.GetChild(0).GetChild(0).GetChild(6).GetChild(0).gameObject.GetComponent<Text>().text = "AI";
        // 失活剧情动画
        GameObject time = GameObject.FindGameObjectWithTag("Time").transform.gameObject;
        time.transform.GetChild(1).gameObject.SetActive(false);
    }
}
