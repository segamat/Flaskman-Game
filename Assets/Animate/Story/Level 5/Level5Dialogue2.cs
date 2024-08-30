using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level5Dialogue2 : MonoBehaviour
{
    // Start is called before the first frame update
    Animator playeranim;

    // 获取玩家父物体
    private Transform Player;
    private Transform time;

    // 多长时间，变换一次文本
    private float dialogueChangeTime = 0;

    // 玩家对话框内容
    private string[] Dialogue = { "我穿过迷宫啦！"
            , "圣殿真的在这里！天神大人也在这里！"
            , "天神大人，我从王国离开，历尽艰难，终于见到你了！（激动，兴奋不已）"
            , "能到这里说明你是一个聪明的小烧瓶，为什么想来见我呢？"
            , "我崇敬天神大人，我想成为您手下的助理，跟着您学知识！"
            , "跟着我学知识可不轻松，是个苦活。"
            , "我不怕，我一定会坚持学下去的！"
            , "勇气可嘉的小朋友，那边先试试看吧，走吧。"};

    // 下标
    private int index = 0;
    private int pindex = 1;

    // Start is called before the first frame update
    void Start()
    {
        // 失活角色脚本
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();
        playerController.enabled = false;

        // 切换镜头
        time = GameObject.FindGameObjectWithTag("Time").transform;
        ChangeCamera.ChangeFollow();

        // 
        time.GetChild(0).gameObject.SetActive(true);
        time.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = Dialogue[0];

        //
        LabyrinthTime labt = GameObject.FindGameObjectWithTag("Labyrinth").gameObject.GetComponent<LabyrinthTime>();
        labt.enabled = false;
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
        if (index >= 2 && index <= 8)
        {
            ChangDialogue();
        }
        if (index == 10)
        {
            Close();
        }
    }

    // 控制对话框
    void ChangDialogue()
    {
        print(index + "  " + pindex);
        time.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = Dialogue[pindex];
        pindex++;
    }

    // 关闭对话框
    void Close()
    {
        // 加载场景下标
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
