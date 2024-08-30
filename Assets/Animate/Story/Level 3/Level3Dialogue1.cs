using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3Dialogue1 : MonoBehaviour
{
    private Transform DialogueContro1;

    Animator playeranim;

    // ��ȡ��Ҹ�����
    private Transform Player;
    private Transform time;

    // �೤ʱ�䣬�任һ���ı�
    private float dialogueChangeTime = 0;

    // ��ҶԻ�������
    private string[] Playerdialogue = { "�ȿȣ������ǺŶ��Ҳ������·������ȥ�ˣ�����취��ɢ��Ƭ��"
            , "����ɭ�������ʲô���õĶ����ɡ�"};

    // �±�
    private int index = 0;
    private int pindex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // ʧ���ɫ�ű�
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();
        playerController.enabled = false;

        // ��ȡ��ɫ�������
        playeranim = GameObject.FindWithTag("Player").transform.GetChild(1).GetComponent<Animator>();
        print(playeranim.name);
        

        // �л���ͷ
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
        if (index == 1)
        {
            playeranim.SetBool("right", false);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", true);
            playeranim.SetBool("lefting", false);
        }
        if (index == 4)
        {
            playeranim.SetBool("right", true);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", false);
            playeranim.SetBool("lefting", false);
            ChangeCamera.ChangeFollow();
        }
        if (index >= 8 && index <= 9)
        {
            print("index: " + index);
            ChangDialogue();
        }
        if (index == 10)
        {
            Close();
        }
    }

    // ���ƶԻ���
    void ChangDialogue()
    {
        print(pindex);
        time.GetChild(0).gameObject.SetActive(true);
        time.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = Playerdialogue[pindex];
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
        PlayerController.WakeUI();
        // ʧ����鶯��
        time.GetChild(1).gameObject.SetActive(false);
    }
}
