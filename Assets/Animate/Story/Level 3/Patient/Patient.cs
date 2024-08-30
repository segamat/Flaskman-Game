using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patient : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform patient;
    private Transform player;
    private Animator anim;

    // 获取物品包裹
    itemCreate green;
    string itemName = "车前草";

    // 对话内容下标
    private int index = 0;
    private int pindex = 0;
    private int Paindex = 1;

    // 对话内容
    private string[] PatientDialogue = {  "咳咳...咳咳..."
            , "你好像不舒服的样子，需要我帮忙吗？"
            , "咳咳，是有点不舒服，咳咳，但是我的药用完了"
            , "咳咳，你可以，咳咳，帮我找一点，咳咳，车前草吗，咳咳？"
            , "没问题。但我没见过车前草。"
            , "咳咳，它的叶片是宽卵形的，咳咳，有长柄。"
            , "我知道了，你先在这里休息一下吧，我马上回来。"
            , "找到啦，给你"
            , "咳咳，谢谢你，咳咳，我待会就用了它，咳咳。"
            , "咳咳，作为报酬，我送你一个碳酸氢钠吧，咳咳。"
            , "哇！太好了，正好我需要，谢啦！"};

    // 切换对话框时间
    private float ChangeTime;

    // 是否在碰撞范围之内
    private bool trigger = false;

    // 是否可以继续对话
    public bool star = false;
    // 得到包裹后可以继续对话
    public bool Green = false;

    void Start()
    {
        patient = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = patient.GetChild(0).GetComponent<Animator>();
        anim.SetBool("give", false);
        green = Resources.Load<itemCreate>("bag/itemData/" + itemName);
    }

    // Update is called once per frame
    void Update()
    {
        if (star)
        {
            if (ChangeTime > 1)
            {
                ChangeTime = 0;
            }
            else ChangeTime += Time.deltaTime;
        }
        ChangDialogue();
    }

    // 碰撞范围之内
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Patient : " + collision.name);
        if (collision.gameObject.name == "Player")
        {
            star = true;
        }
        player.GetChild(0).gameObject.SetActive(true);
        player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = PatientDialogue[0];
        green.use = true;
    }

    // 碰撞范围之外
    private void OnTriggerExit2D(Collider2D collision)
    {
        star = false;
        ChangeTime = 0;
        player.GetChild(0).gameObject.SetActive(false);
        green.use = false;
    }

    // 切换对话
    void ChangDialogue()
    {
        if (Input.GetMouseButtonDown(0) && star)
        {
            player.GetChild(0).gameObject.SetActive(true);
            // 移动玩家位置
            if (player.position != patient.GetChild(3).transform.position)
            {
                player.position = patient.GetChild(3).transform.position;
            }
            if (index <= 5)
            {
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = PatientDialogue[Paindex];
                Paindex++;
                index++;
            }
            if (index >= 6 && index <= 9 && Green)
            {
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = PatientDialogue[Paindex];
                if(index == 9)
                {
                    Give.Imageindex(14);
                    AnimationControl.Give(0, 1);
                    addtocomposeui.additem("碳酸氢钠");
                }
                Paindex++;
                index++;
            }
            else player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = PatientDialogue[Paindex - 1];
        }
    }
}
