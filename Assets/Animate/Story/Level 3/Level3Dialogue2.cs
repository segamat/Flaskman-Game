using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level3Dialogue2 : MonoBehaviour
{
    private Transform DialogueContro1;
    GameObject UIinterface;

    Animator playeranim;

    // 获取玩家父物体
    private Transform Player;
    private Transform time;

    // 多长时间，变换一次文本
    private float dialogueChangeTime = 0;

    // 玩家对话框内容
    private string[] Playerdialogue = { "（嗅）呛人的味道没有了，雾真的消散了，"
            , "原来烧碱溶液真的可以吸收二氧化硫，又学到了新知识，离成为天神大人的助手有进一步啦，加油加油！"};

    // 下标
    private int index = 0;
    private int pindex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 失活角色脚本
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();
        playerController.enabled = false;

        // 删除UI界面
        UIinterface = GameObject.FindGameObjectWithTag("uisystem").transform.gameObject;
        Destroy(UIinterface);

        // 获取角色动画组件
        playeranim = GameObject.FindWithTag("Player").transform.GetChild(1).GetComponent<Animator>();
        print(playeranim.name);
        playeranim.SetBool("right", false);
        playeranim.SetBool("left", false);
        playeranim.SetBool("righting", false);
        playeranim.SetBool("lefting", false);
        playeranim.SetBool("give", true);

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
        print(index);
        if(index == 2)
        {
            playeranim.SetBool("right", true);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", false);
            playeranim.SetBool("lefting", false);
            playeranim.SetBool("give", false);
        }
        if (index == 6)
        {
            playeranim.SetBool("right", false);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", true);
            playeranim.SetBool("lefting", false);
        }
        if (index >= 7 && index <= 8)
        {
            print("index: " + index);
            ChangDialogue();
        }
        if (index == 12)
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
        // 加载场景下标
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
