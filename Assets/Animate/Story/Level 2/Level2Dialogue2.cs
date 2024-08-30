using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2Dialogue2 : MonoBehaviour
{
    private Transform DialogueContro2;

    // 获取UI界面
    GameObject UIinterface;

    Animator playeranim;

    // 获取玩家父物体
    private Transform Player;
    private Transform time;

    // 多长时间，变换一次文本
    private float dialogueChangeTime = 0;

    // 玩家对话框内容
    private string[] Playerdialogue = { "哇~~，这个爆炸效果然不一般，虫子都消灭干净了。"
            , "探险家果然见多识广，不愧是在森林里探险已久的勇者。"
            , "我也要继续努力，实现梦想。小小烧瓶人，远不言败！加油！"};

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

        // 删除UI界面
        UIinterface = GameObject.FindGameObjectWithTag("uisystem").transform.gameObject;
        Destroy(UIinterface);

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
        if (index == 2)
        {
            playeranim.SetBool("right", false);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", false);
            playeranim.SetBool("lefting", true);
            ChangeCamera.ChangeFollow();
        }
        if (index == 4)
        {
            playeranim.SetBool("right", true);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", false);
            playeranim.SetBool("lefting", false);
        }
        if (index >= 7 && index <= 9)
        {
            print("index: " + index);
            ChangDialogue();
        }
        if (index == 9)
        {
            playeranim.SetBool("right", false);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", true);
            playeranim.SetBool("lefting", false);
        }
        if (index == 13)
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
        // 失活剧情动画
        time.GetChild(1).gameObject.SetActive(false);
        // 加载场景下标
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
