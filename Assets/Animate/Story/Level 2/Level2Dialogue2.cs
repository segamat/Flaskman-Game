using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2Dialogue2 : MonoBehaviour
{
    private Transform DialogueContro2;

    // ��ȡUI����
    GameObject UIinterface;

    Animator playeranim;

    // ��ȡ��Ҹ�����
    private Transform Player;
    private Transform time;

    // �೤ʱ�䣬�任һ���ı�
    private float dialogueChangeTime = 0;

    // ��ҶԻ�������
    private string[] Playerdialogue = { "��~~�������ըЧ��Ȼ��һ�㣬���Ӷ�����ɾ��ˡ�"
            , "̽�ռҹ�Ȼ����ʶ�㣬��������ɭ����̽���Ѿõ����ߡ�"
            , "��ҲҪ����Ŭ����ʵ�����롣СС��ƿ�ˣ�Զ���԰ܣ����ͣ�"};

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
        playeranim.SetBool("right", false);
        playeranim.SetBool("left", false);
        playeranim.SetBool("righting", true);
        playeranim.SetBool("lefting", false);

        // ɾ��UI����
        UIinterface = GameObject.FindGameObjectWithTag("uisystem").transform.gameObject;
        Destroy(UIinterface);

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
        // ʧ����鶯��
        time.GetChild(1).gameObject.SetActive(false);
        // ���س����±�
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
