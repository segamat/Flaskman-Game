using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level5Dialogue1 : MonoBehaviour
{
    // Start is called before the first frame update
    Animator playeranim;
    TilemGuard tilem;

    // ��ȡ��Ҹ�����
    private Transform Player;
    private Transform time;

    // �೤ʱ�䣬�任һ���ı�
    private float dialogueChangeTime = 0;

    // ��ҶԻ�������
    private string[] Dialogue = { "�Һ��񿴵�ʥ���ˣ��������Թ���̫���ˣ������Ͼ��ܼ��������ˡ�"
            , "վס������˭������ʥ���Թ������˲������ڡ�"
            , "ԭ�������ʥ����Ǹ�����˹��һ��С��ƿ��"
            , "�������������ˣ������Ϊ������˵����֣���"
            , "������˿ɲ�����������ܼ����ģ�������˻�԰����Ҳ�޷������Թ���"
            , "����ĺ������������ˣ��������������а��У���"
            , "�ðɣ���Ҫ�����ڻ�԰�����������صĻ����Ҿ͸�������Թ�����ʾ��"};

    // �±�
    private int index = 0;
    private int pindex = 1;

    // Start is called before the first frame update
    void Start()
    {
        // ʧ���ɫ�ű�
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();
        playerController.enabled = false;

        // 
        tilem = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<TilemGuard>();
        tilem.enabled = false;

        // ��ȡ��ɫ�������
        playeranim = GameObject.FindWithTag("Player").transform.GetChild(1).GetComponent<Animator>();
        print(playeranim.name);

        // �л���ͷ
        time = GameObject.FindGameObjectWithTag("Time").transform;
        ChangeCamera.ChangeFollow();

        // 
        time.GetChild(0).gameObject.SetActive(true);
        time.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = Dialogue[0];

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
        if (index == 3)
        {
            playeranim.SetBool("right", false);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", true);
            playeranim.SetBool("lefting", false);
        }
        if (index == 7)
        {
            playeranim.SetBool("right", true);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", false);
            playeranim.SetBool("lefting", false);
        }
        if (index >=7 && index <=12)
        {
            ChangDialogue();
        }
        if (index == 13)
        {
            Close();
        }
    }

    // ���ƶԻ���
    void ChangDialogue()
    {
        time.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = Dialogue[pindex];
        pindex++;
    }

    // �رնԻ���
    void Close()
    {
        time.GetChild(0).gameObject.SetActive(false);
        // �ָ���ɫ����
        Animator playeranim = GameObject.FindWithTag("Player").transform.GetChild(1).GetComponent<Animator>();
        playeranim.SetBool("right", true);
        playeranim.SetBool("left", false);
        playeranim.SetBool("righting", false);
        playeranim.SetBool("lefting", false);
        // �ָ���ɫ�ű�
        PlayerController playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerController.GetComponent<PlayerController>().enabled = true;
        tilem.enabled = true;
        PlayerController.WakeUI();
        // ʧ����鶯��
        time.GetChild(1).gameObject.SetActive(false);
    }
}
