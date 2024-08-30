using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue2 : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform DialogueContro2;
    // ��ȡUI����
    GameObject UIinterface;
    // ��ȡ��Ҹ�����
    private Transform Player;
    private Transform time;

    private Animator dooranim;

    // ��ҶԻ�������
    private string[] Playerdialogue = { "���Ϻ��ˣ������ĵȴ������������ˣ��ſ���!"
            , "��֪����˹�ض������һ����ʹ���ȥ�ι�ʥ���ʱ����һ����Ϊ����������֡�"
            , "���뿪�ɣ���С�Ƿ����ˡ�" };

    private string[] Frienddialogue = { "���죬С��Ҫ������"
            , "����˹�ˣ�����߰ɣ���һ��Ҫ�ҵ�ʥ��ѽ��"
            , "��һ�����Եģ��������������˹�ˣ�" };

    // ��������ʱ��
    private float totalTime = 0;
    private int index = -1;
    private int pindex = 0;
    private int findex = 0;

    void Start()
    {
        DialogueContro2 = GetComponent<Transform>();
        // ʧ���ɫ�ű�
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();
        playerController.enabled = false;
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        // �ָ�������ű�
        friendControl friendcontrol = GameObject.FindWithTag("friend").GetComponent<friendControl>();
        friendcontrol.GetComponent<friendControl>().enabled = false;

        // ��ȡ���Ŷ������
        dooranim = GameObject.FindGameObjectWithTag("door").transform.GetComponent<Animator>();

        // �ر�UI����
        UIinterface = GameObject.FindGameObjectWithTag("uisystem").transform.gameObject;
        Destroy(UIinterface);

        // ��ȡʱ���߸�����
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

    // �ı��ɫ����Ч��
    void ChangeAnim(int state)
    {
        // ����
        if (state == 0)
        {
            print("����");
            dooranim.SetBool("open", true);
            dooranim.SetBool("close", false);
        }
        // ����
        else if (state == 1)
        {
            print("����");
            dooranim.SetBool("open", false);
            dooranim.SetBool("close", true);
        }
        // ��
        else if (state == 2)
        {
            print("��");
            dooranim.SetBool("open", true);
            dooranim.SetBool("close", true);
        }
        // �ָ�
        else
        {
            print("ͣ");
            dooranim.SetBool("open", false);
            dooranim.SetBool("close", false);
        }
    }

    //  �Ի�
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

    // �رն���
    void Close()
    {
        // ���س����±�
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
