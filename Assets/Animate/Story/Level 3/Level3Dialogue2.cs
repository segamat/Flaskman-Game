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

    // ��ȡ��Ҹ�����
    private Transform Player;
    private Transform time;

    // �೤ʱ�䣬�任һ���ı�
    private float dialogueChangeTime = 0;

    // ��ҶԻ�������
    private string[] Playerdialogue = { "���ᣩǺ�˵�ζ��û���ˣ��������ɢ�ˣ�"
            , "ԭ���ռ���Һ��Ŀ������ն���������ѧ������֪ʶ�����Ϊ������˵������н�һ���������ͼ��ͣ�"};

    // �±�
    private int index = 0;
    private int pindex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // ʧ���ɫ�ű�
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();
        playerController.enabled = false;

        // ɾ��UI����
        UIinterface = GameObject.FindGameObjectWithTag("uisystem").transform.gameObject;
        Destroy(UIinterface);

        // ��ȡ��ɫ�������
        playeranim = GameObject.FindWithTag("Player").transform.GetChild(1).GetComponent<Animator>();
        print(playeranim.name);
        playeranim.SetBool("right", false);
        playeranim.SetBool("left", false);
        playeranim.SetBool("righting", false);
        playeranim.SetBool("lefting", false);
        playeranim.SetBool("give", true);

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
        // ���س����±�
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
