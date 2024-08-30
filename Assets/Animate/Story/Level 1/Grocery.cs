using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grocery : MonoBehaviour
{
    // Start is called before the first frame update
    // 是否需要剧情
    public bool dia = false;
    // 是否可以进行下一个剧情
    public bool next = false;
    // 人物对话
    private string[] PlayerDialogue = { "DD，你知不知道小登害怕什么？"
            , "那你知道怎样可以破坏锁吗？"
            , "好吧。" };

    private string[] DDdialogue = { "欢迎来到小卖部！"
            , "我也不知道呢。"
            , "但是住在医院左上方的杯杯可能知道。"
            , "这我倒是知道，汞可以腐蚀锁。" };
    private int index = 1;
    private int Playerindex = 0;
    private int Groveryindex = 1;

    // 获取对话物体
    private Transform DD;
    // 获取烧瓶人物体
    private Transform Player;

    void Start()
    {
        DD = GetComponent<Transform>().parent;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Dialogue();
    }

    // 在碰撞范围内
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (index == 1) dia = true;
        DD.GetChild(1).gameObject.SetActive(true);
        DD.GetChild(1).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = DDdialogue[0];
        if (dia)
        {
            // 失活点击DD触发小卖部
            DD.GetComponent<ClickControl>().enabled = false;
            // 失活角色脚本
            PlayerController playerController = GameObject.FindWithTag("Player").transform.GetComponent<PlayerController>();
            playerController.enabled = false;
        }
    }

    // 在碰撞范围之外
    void OnCollisionExit2D(Collision2D collision)
    {
        DD.GetChild(1).gameObject.SetActive(false);
    }
    
    // 触发剧情
    void Dialogue()
    {
        if (Input.GetMouseButtonDown(0) && dia && index <= 8)
        {
            if (index > 6)
            {
                Player.GetChild(0).gameObject.SetActive(false);
                DD.GetChild(1).gameObject.SetActive(false);
                // 恢复角色脚本
                PlayerController playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
                playerController.GetComponent<PlayerController>().enabled = true;
                // 恢复点击触发小卖部界面
                DD.GetComponent<ClickControl>().enabled = true;
                // 激活杯杯对话脚本
                Beibei bb = GameObject.FindGameObjectWithTag("beibei").GetComponent<Beibei>();
                bb.enabled = true;

                dia = false;
                next = true;
            }
            else if (index == 1 || index == 4 || index == 6)
            {
                DD.GetChild(1).gameObject.SetActive(false);
                Player.GetChild(0).gameObject.SetActive(true);
                Player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = PlayerDialogue[Playerindex];
                Playerindex++;
            }
            else
            {
                Player.GetChild(0).gameObject.SetActive(false);
                DD.GetChild(1).gameObject.SetActive(true);
                DD.GetChild(1).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = DDdialogue[Groveryindex];
                Groveryindex++;
            }
            index++;
        }
    }
}
