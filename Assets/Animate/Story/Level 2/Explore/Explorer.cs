using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explorer : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform explorer;
    private Transform player;
    private Animator anim;

    // ��ȡ��Ʒ
    itemCreate yinshi;
    itemCreate clock;
    string[] itemName = { "өʯ", "�޺õı�" };

    // �Ի������±�
    private int index = 0;
    private int pindex = 0;
    private int eindex = 1;

    // �Ի�����
    private string[] PlayerDialogue = { "���ѽ���ѣ�����������ʲô�أ�"
            , "����֪��Ҫ��ô�����·�ϵĳ��������Ƕ�ס���ҵ�ȥ·��"
            , "��ȡը����������������Ҳ�֪����ô��ȡը������֪����"
            , "������ı��޺��ˣ��������Ҫ��ô��ȡը���ɡ����ڴ���"
            , "" };

    private string[] ExplorerDialogue = {  "�������԰��Խ̽Խ����Ȥ" 
            , "����ɭ����̽�գ��������ҵ�����԰��������δ֪����Ȥ��"
            , "����ɭ������˺ö����ˣ���Ȼ֪����"
            , "��Ҫ��֪���ʹ�һЩ�����Ļᷢ��Ĳ�ɫʯͷ��������."
            , "өʯ��ÿ�ѽ���Ҷ����������������ѧ͸���ˡ�"
            , "��Ϊ�����Ҿ͸�����ɣ���������ը���ѳ���ȫ������"
            , "һ���µ�������Ҫһ���µı��꣬��ξ����������һ���ҵ��ӱ�ɡ�"
            , "�Ȱ����ҵ����ڸ�����������������ҵ���ȥ��ס���κ���һͷ�������ˡ�"
            , "�޺ñ���Ҿ͸�������ô����ը����"
            , "��Ȼ�޺��ˣ�����ʵ�ܼ򵥣������������������ڹ����²�����ը���Ϳ�����������ˡ�"};

    // �л��Ի���ʱ��
    private float ChangeTime;

    // �Ƿ�����ײ��Χ֮��
    private bool trigger = false;

    // �Ƿ���Լ����Ի�
    public bool star = false;
    public bool Edia1 = false;
    public bool Edia2 = false;

    void Start()
    {
        explorer = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        yinshi = Resources.Load<itemCreate>("bag/itemData/" + itemName[0]);
        clock = Resources.Load<itemCreate>("bag/itemData/" + itemName[1]);
        anim = explorer.GetChild(4).GetComponent<Animator>();
        anim.SetBool("give", false);
    }

    // Update is called once per frame
    void Update()
    {
        Chang();
        
    }

    // ��ײ��Χ֮��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Explorer : " + collision.name);
        if (collision.gameObject.name == "Player")
        {
            star = true;
        }
        player.GetChild(0).gameObject.SetActive(true);
        player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ExplorerDialogue[0];
        yinshi.use = true;
        clock.use = true;
    }

    // ��ײ��Χ֮��
    private void OnTriggerExit2D(Collider2D collision)
    {
        star = false;
        ChangeTime = 0;
        player.GetChild(0).gameObject.SetActive(false);
        yinshi.use = false;
        clock.use = false;
    }

    // �л��Ի���
    void Chang()
    {
        if(Input.GetMouseButtonDown(0) && star)
        {
            player.GetChild(0).gameObject.SetActive(true);
            // �ƶ����λ��
            if ( player.position != explorer.GetChild(3).transform.position )
            {
                player.position = explorer.GetChild(3).transform.position;
            }

            if (index <= 4)
            {
                Dialogue(index);
                index++;
            }
            else if (index > 4 && index <= 10 && Edia1)
            {
                Dialogue1(index);
                index++;
            }
            else if (index >= 11 && index <= 12 && Edia2)
            {
                Dialogue2(index);
                index++;
            }
            else DialogueStar();
        }
    }

    // �Ի���
    void Dialogue(int index)
    {
        // �������
        if (index == 0 || index == 2)
        {
            player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = PlayerDialogue[pindex];
            pindex++;
        }
        // ̽�ռ�����
        else
        {
            player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ExplorerDialogue[eindex];
            eindex++;
        }
    }
    void Dialogue1(int index)
    {
        // �������
        if (index == 7)
        {
            player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = PlayerDialogue[pindex];
            pindex++;
        }
        // ̽�ռ�����
        else
        {
            player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ExplorerDialogue[eindex];
            eindex++;
        }
        if (index == 10)
        {
            Give.Imageindex(5);
            AnimationControl.Give(0, 0);
            addtocomposeui.additem("���ı�");
        }
    }
    void Dialogue2(int index)
    {
        if(index == 11)
        {
            // �������
            player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = PlayerDialogue[pindex];
            pindex++;
        }
        else
        {
            player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ExplorerDialogue[eindex];
            eindex++;
        }
    }
    void DialogueStar()
    {
        player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = ExplorerDialogue[eindex - 1];
    }

}
