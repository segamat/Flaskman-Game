using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue1 : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform DialogueControl;
    // ��ȡUI����
    GameObject UIinterface;
    // ��ȡ��Ҹ�����
    private Transform Player;
    // ��ҶԻ�������
    string Playerdialogue = "������Ҫ��������ƻ��ˣ��Ͱ���DD˵�ķ���";

    // ��������ʱ��
    private float totalTime = 0;
    private int index = 0;

    void Start()
    {
        DialogueControl = GetComponent<Transform>();
        // ʧ���ɫ�ű�
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();
        playerController.enabled = false;

        Player = GameObject.FindGameObjectWithTag("Player").transform;

        // 
        UIinterface = GameObject.FindGameObjectWithTag("uisystem").transform.gameObject;
        Destroy(UIinterface);
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        if(totalTime >= 1)
        {
            index++;
            totalTime = 0;
        }
        if (index == 4)
        {
            ChangeAnim(0);
        }
        if (index == 7)
        {
            ChangeAnim(1);
        }
        if (index == 10)
        {
            ChangeAnim(2);
        }
        if (index == 11)
        {
            Dialogue();
        }
        if (index == 13)
        {
            Close();
        }
    }

    // �ı��ɫ����Ч��
    void ChangeAnim(int state)
    {
        // ��ȡ��ɫ�������
        Animator playeranim = GameObject.FindWithTag("Player").transform.GetComponent<Animator>();

        // ������
        if (state == 0)
        {
            print("������");
            playeranim.SetBool("right", false);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", false);
            playeranim.SetBool("lefting", true);
        }
        // ������
        else if(state == 1)
        {
            print("������");
            playeranim.SetBool("right", false);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", true);
            playeranim.SetBool("lefting", false);
        }
        // ͣ
        else
        {
            print("ͣ");
            playeranim.SetBool("right", true);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", false);
            playeranim.SetBool("lefting", false);
        }
    }

    // 
    void Dialogue()
    {
        Player.GetChild(0).gameObject.SetActive(true);
        Player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = Playerdialogue;
    }
 
    // 
    void Close()
    {
        // �ָ���ɫ����
        Animator playeranim = GameObject.FindWithTag("Player").transform.GetComponent<Animator>();
        playeranim.SetBool("right", true);
        playeranim.SetBool("left", false);
        playeranim.SetBool("righting", false);
        playeranim.SetBool("lefting", false);
        // �ָ���ɫ�ű�
        PlayerController playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerController.GetComponent<PlayerController>().enabled = true;
        PlayerController.WakeUI();
        Player.GetChild(0).gameObject.SetActive(false);
        // �ָ�������ű�
        friendControl friendcontrol = GameObject.FindWithTag("friend").GetComponent<friendControl>();
        friendcontrol.GetComponent<friendControl>().enabled = true;
        // ��UI����
        GameObject UI = GameObject.FindGameObjectWithTag("uisystem").transform.gameObject;
        UI.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        UI.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        UI.transform.GetChild(0).GetChild(0).GetChild(6).GetChild(0).gameObject.SetActive(true);
        UI.transform.GetChild(0).GetChild(0).GetChild(6).GetChild(0).gameObject.GetComponent<Text>().text = "AI";
        // ʧ����鶯��
        GameObject time = GameObject.FindGameObjectWithTag("Time").transform.gameObject;
        time.transform.GetChild(1).gameObject.SetActive(false);
    }
}
