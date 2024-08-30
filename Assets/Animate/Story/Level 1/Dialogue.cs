using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    // ��ȡcontrol��
    private Transform DialogueControl;
    // �ı�
    private string[] flaskdialogue = { "���裬�㿴���ҵ���ʲô��һ��ͨ�����ĵ�ͼ��"
            , "�����ڿ���ʵ�������ˣ���һ��Ҫ�ҵ���������������֣�"
            , "���Ҿ�͵͵�ܳ�ȥ���ҿ���Ҫ��Ϊ��������ֵģ��ٴ�����Ѷ����£�"
            , "����������ʰ��������������ſڸ�����ϰɡ�"
            , "�������ǵ���취��������"
            , "�������ǿ���ȥС������������Ե��õ�С�����ϰ�DD��"};
    private string[] frienddialogue = { "ʲô��������չ���һ��鿴��ͼ��"
            , "�������ͨ������·��"
            , "��һ�����Եģ���������費��ͬ���"
            , "������˵���������Σ��..."
            , "���Ұ����ܳ�ȥ�����ͣ���ƿ��һ����������������ģ�"
            , "��Ҫ��취�ƻ�������������������֮�������뿪����"
            , "�߰ɣ�"};
    // �೤ʱ�䣬�任һ���ı�
    private float dialogueChangeTime = 0;
    // �±�
    private int index = 0;
    private int playerindex = 0;
    private int friendindex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dialogueChangeTime += Time.deltaTime;
        if(dialogueChangeTime >= 1)
        {
            ChangeText();
            dialogueChangeTime = 0;
        }
    }

    // �任�ı�
    public void ChangeText()
    {
        // ��ֵ�ı���
        DialogueControl = GetComponent<Transform>();
        
        if (index == 9)
        {
            // �رնԻ�
            DialogueControl.GetChild(0).gameObject.SetActive(false);
            DialogueControl.GetChild(1).gameObject.SetActive(false);
            DialogueControl.GetChild(2).gameObject.SetActive(false);
            Animator playeranim = GameObject.FindWithTag("Player").transform.GetChild(1).GetComponent<Animator>();
            playeranim.SetBool("right", false);
            playeranim.SetBool("left", false);
            playeranim.SetBool("righting", true);
            playeranim.SetBool("lefting", false);
        }
        else if(index < 9)// �����ı���
        {
            if(index == 0)
            {
                // ʧ���ɫ�ű�
                PlayerController playerController = GameObject.FindWithTag("Player").transform.GetComponent<PlayerController>();
                playerController.enabled = false;
            }
            if ((index == 0)||(index == 3)||(index == 6)||(index == 8))
            {
                DialogueControl.GetChild(2).gameObject.SetActive(false);
                DialogueControl.GetChild(1).gameObject.SetActive(true);
                DialogueControl.GetChild(1).GetChild(0).GetComponent<Text>().text = flaskdialogue[playerindex];
                playerindex++;
            }
            else
            {
                DialogueControl.GetChild(1).gameObject.SetActive(false);
                DialogueControl.GetChild(2).gameObject.SetActive(true);
                DialogueControl.GetChild(2).GetChild(0).GetComponent<Text>().text = frienddialogue[friendindex];
                friendindex++;
            }
        }
        else if (index == 13)
        {
            ChangeCamera.ChangeFollow(); // �л�����ͷ�������
        }
        else if (index >= 16 && index < 20)
        {
            if (index == 16 || index == 18)
            {
                DialogueControl.GetChild(2).gameObject.SetActive(false);
                DialogueControl.GetChild(1).gameObject.SetActive(true);
                DialogueControl.GetChild(1).GetChild(0).GetComponent<Text>().text = flaskdialogue[playerindex];
                playerindex++;
            }
            else
            {
                DialogueControl.GetChild(1).gameObject.SetActive(false);
                DialogueControl.GetChild(2).gameObject.SetActive(true);
                DialogueControl.GetChild(2).GetChild(0).GetComponent<Text>().text = frienddialogue[friendindex];
                friendindex++;
            }
        }
        else if(index == 20)
        {
            DialogueControl.GetChild(2).gameObject.SetActive(false);
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
            // �ָ�������ű�
            friendControl friendcontrol = GameObject.FindWithTag("friend").GetComponent<friendControl>();
            friendcontrol.GetComponent<friendControl>().enabled = true;
            // ʧ��UI������ʾ�ű�
            GameObject UIinfact = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).gameObject;
            UIinfact.SetActive(true);
            GameObject time = GameObject.FindGameObjectWithTag("Time").transform.gameObject;
            time.transform.GetChild(0).gameObject.SetActive(false);
            GameObject dia = GameObject.FindGameObjectWithTag("Dialogue").transform.gameObject;
            Destroy(dia);
        }
        index++;
    }
}
