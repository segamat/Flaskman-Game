using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clockman : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform clockman;
    private Transform player;
    private Animator anim;

    // ��ȡ��Ʒ
    itemCreate lingjian;
    itemCreate bagclock;
    itemCreate Acholc;
    string[] itemName = { "���", "���ı�", "�ƾ�"};

    // �Ի������±�
    private int index = 0;
    private int cindex = 1;

    // �Ի�����
    private string[] ClockmanDialogue = {  "ʱ��δ�δ����"
            , "��ã���������԰�����һ�±���"
            , "�ޱ��ǿ����ҵ�ǿ���ʲô�������޺á�"
            , "����ɲ�����ѵģ�����Ҫ���Ҵ���һЩ�ƾ���Ϊ���ꡣ"
            , "����ð죬�ƾ�����������������ȡ����˼����"
            , "һ��Ϊ�������Ȱ����ޱ�ѣ���һ�����������ƾ��ġ�"
            , "����������Ҫȥ��һ����ȡ�������ʵ�ֲ�"
            , "���Ȼ�����˾ƾ�������������������ı��Ѿ��޺���"
            , "��~�����޵���ã�̫��л�ˡ��л����ټ���"};

    // �л��Ի���ʱ��
    private float ChangeTime;

    // �Ƿ�����ײ��Χ֮��
    private bool trigger = false;

    // �Ƿ���Լ����Ի�
    public bool star = false;
    public bool ljian = false;
    public bool clock = false;
    public bool acholc = false;

    void Start()
    {
        clockman = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lingjian = Resources.Load<itemCreate>("bag/itemData/" + itemName[0]);
        bagclock = Resources.Load<itemCreate>("bag/itemData/" + itemName[1]);
        Acholc = Resources.Load<itemCreate>("bag/itemData/" + itemName[2]);
        anim = clockman.GetChild(4).GetComponent<Animator>();
        anim.SetBool("give", false);
    }

    // Update is called once per frame
    void Update()
    {
        ChangDialogue();
    }

    // ��ײ��Χ֮��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Clockman : " + collision.name);
        if (collision.gameObject.name == "Player")
        {
            star = true;
        }
        player.GetChild(0).gameObject.SetActive(true);
        player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ClockmanDialogue[0];
        if (lingjian.ItemNum == 3) lingjian.use = true;
        bagclock.use = true;
        Acholc.use = true;
    }

    // ��ײ��Χ֮��
    private void OnTriggerExit2D(Collider2D collision)
    {
        star = false;
        ChangeTime = 0;
        player.GetChild(0).gameObject.SetActive(false);
        lingjian.use = false;
        bagclock.use = false;
        Acholc.use = false;
    }

    // �л��Ի�
    void ChangDialogue()
    {
        if (Input.GetMouseButtonDown(0) && star)
        {
            player.GetChild(0).gameObject.SetActive(true);
            // �ƶ����λ��
            if (player.position != clockman.GetChild(3).transform.position)
            {
                player.position = clockman.GetChild(3).transform.position;
            }
            if (index <= 5 && ljian && clock)
            {
                player.GetChild(0).gameObject.SetActive(true);
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ClockmanDialogue[cindex];
                cindex++;
                index++;
            }
            else if(index >=6 && index <= 7 && acholc)
            {
                player.GetChild(0).gameObject.SetActive(true);
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ClockmanDialogue[cindex];
                if(index == 7)
                {
                    Give.Imageindex(4);
                    AnimationControl.Give(0, 1);
                    addtocomposeui.additem("�޺õı�");
                }
                cindex++;
                index++;
            }
            else if (!acholc && ljian && clock)
            {
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ClockmanDialogue[3];
            }
            else player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ClockmanDialogue[0];
        }
    }
}
