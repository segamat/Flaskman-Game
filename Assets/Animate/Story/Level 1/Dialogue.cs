using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    // 获取control层
    private Transform DialogueControl;
    // 文本
    private string[] flaskdialogue = { "阿拌，你看我找到了什么！一张通往神殿的地图！"
            , "我终于可以实现梦想了，我一定要找到神殿，当上天神的助手！"
            , "那我就偷偷跑出去，我可是要成为天神的助手的，再大的困难都不怕！"
            , "那我现在收拾行李，我们在王国门口附近汇合吧。"
            , "看来我们得想办法引开守卫"
            , "或许我们可以去小卖部，问问人缘最好得小卖部老板DD。"};
    private string[] frienddialogue = { "什么！（阿拌凑过来一起查看地图）"
            , "这真的是通往神殿的路！"
            , "你一定可以的！但是你爸妈不会同意的"
            , "他们总说王国外面很危险..."
            , "那我帮你跑出去，加油，阿瓶你一定可以完成你的梦想的！"
            , "还要想办法破坏锁，才能在引开守卫之后让你离开王国"
            , "走吧！"};
    // 多长时间，变换一次文本
    private float dialogueChangeTime = 0;
    // 下标
    private int index = 0;
    private int playerindex = 0;
    private int friendindex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dialogueChangeTime += Time.deltaTime;
        if(dialogueChangeTime >= 1)
        {
            ChangeText();
            dialogueChangeTime = 0;
        }
    }

    // 变换文本
    public void ChangeText()
    {
        // 赋值文本框
        DialogueControl = GetComponent<Transform>();
        
        if (index == 9)
        {
            // 关闭对话
            DialogueControl.GetChild(0).gameObject.SetActive(false);
            DialogueControl.GetChild(1).gameObject.SetActive(false);
            DialogueControl.GetChild(2).gameObject.SetActive(false);
            Animator playeranim = GameObject.FindWithTag("Player").transform.GetChild(1).GetComponent<Animator>();
            playeranim.SetBool("right", false);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", true);
            playeranim.SetBool("lefting", false);
        }
        else if(index < 9)// 激活文本框
        {
            if(index == 0)
            {
                // 失活角色脚本
                PlayerController playerController = GameObject.FindWithTag("Player").transform.GetComponent<PlayerController>();
                playerController.enabled = false;
            }
            if ((index == 0)||(index == 3)||(index == 6)||(index == 8))
            {
                DialogueControl.GetChild(2).gameObject.SetActive(false);
                DialogueControl.GetChild(1).gameObject.SetActive(true);
                DialogueControl.GetChild(1).GetChild(0).GetComponent<Text>().text = flaskdialogue[playerindex];
                playerindex++;
            }
            else
            {
                DialogueControl.GetChild(1).gameObject.SetActive(false);
                DialogueControl.GetChild(2).gameObject.SetActive(true);
                DialogueControl.GetChild(2).GetChild(0).GetComponent<Text>().text = frienddialogue[friendindex];
                friendindex++;
            }
        }
        else if (index == 13)
        {
            ChangeCamera.ChangeFollow(); // 切换摄像头跟随对象
        }
        else if (index >= 16 && index < 20)
        {
            if (index == 16 || index == 18)
            {
                DialogueControl.GetChild(2).gameObject.SetActive(false);
                DialogueControl.GetChild(1).gameObject.SetActive(true);
                DialogueControl.GetChild(1).GetChild(0).GetComponent<Text>().text = flaskdialogue[playerindex];
                playerindex++;
            }
            else
            {
                DialogueControl.GetChild(1).gameObject.SetActive(false);
                DialogueControl.GetChild(2).gameObject.SetActive(true);
                DialogueControl.GetChild(2).GetChild(0).GetComponent<Text>().text = frienddialogue[friendindex];
                friendindex++;
            }
        }
        else if(index == 20)
        {
            DialogueControl.GetChild(2).gameObject.SetActive(false);
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
            // 恢复搅拌棒脚本
            friendControl friendcontrol = GameObject.FindWithTag("friend").GetComponent<friendControl>();
            friendcontrol.GetComponent<friendControl>().enabled = true;
            // 失活UI控制显示脚本
            GameObject UIinfact = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).gameObject;
            UIinfact.SetActive(true);
            GameObject time = GameObject.FindGameObjectWithTag("Time").transform.gameObject;
            time.transform.GetChild(0).gameObject.SetActive(false);
            GameObject dia = GameObject.FindGameObjectWithTag("Dialogue").transform.gameObject;
            Destroy(dia);
        }
        index++;
    }
}
