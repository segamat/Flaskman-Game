using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beibei : MonoBehaviour
{
    // Start is called before the first frame update
    // ��ȡDD�Ľű��ļ�
    //Grocery DD = GameObject.FindWithTag("grocery").transform.GetComponent<Grocery>();
    private Transform DD;
    private Grocery gro;

    // ��ȡ������
    private Transform BB;
    // ��ȡ��Ҹ�����
    public Transform Player;

    // ��ȡ��Ʒ�����͹���
    static string[] itemname = { "��ˮ�Ļ�", "����", "����" };
    public itemCreate flower;
    public itemCreate fruit;
    public itemCreate flowerLoop; 

    // �Ƿ�����ײ��Χ��
    private bool trigger = false;
    // �Ƿ���Ҫ��������
    public bool Bdia1 = false;
    public bool Bdia2 = false;
    // �Ƿ���Դ�����һ������
    private bool next = false;

    // �±�
    int index = 0;
    int BBindex = 1;
    int Pindex = 0;
    // �Ի�����
    private string[] BBdialogue = { "���컹û�����磬��������..."
            , "С�Ǻ���û�к��µĶ���������������������ʿ��"
            , "��Ҫ�����������Ļ��������ù�����������ǰȥ�鿴��ע�ⲻҪ������ม�"
            , "�Ǿ�Ҫ��һ�����Զ�����Ķ�����������,���������������ҿ���"
            , "������һ�������⡣"
            , "��������ȡɱ����е����ʼ���һ����������ȼ�ͻ��й������ˡ�"
            , "�����ſڲ�Զ���ĲݴԱ��Ǽ��õ�ѡ��"};

    private string[] Playerdialogue = { "������֪��С�Ǻ���ʲô��"
            , "��������ʲô�취����������"
            , "�����ҵ��������"};


    void Start()
    {
        DD = GameObject.FindGameObjectWithTag("grocery").transform;
        gro = DD.GetComponent<Grocery>();
        BB = GetComponent<Transform>();
        print(flower);
    }

    // Update is called once per frame
    void Update()
    {
        if (gro.dia) Bdia1 = true;
        if (trigger) Dialogue();
    }

    // ����ײ��Χ�ڣ�ʹ��������Ʒ����
    void OnCollisionEnter2D(Collision2D collision)
    {
        trigger = true;
        print("������ײ��Χ");
        if (index == 0) Bdia1 = true;
        print(Player.name);
        Player.GetChild(0).gameObject.SetActive(true);
        Player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = BBdialogue[0];
        flower.use = true;
        fruit.use = true;
        flowerLoop.use = true;
        if (Bdia1)
        {
            // ʧ���ɫ�ű�
            PlayerController playerController = GameObject.FindWithTag("Player").transform.GetComponent<PlayerController>();
            playerController.enabled = false;
        }
    }

    // ����ײ��Χ֮��
    void OnCollisionExit2D(Collision2D collision)
    {
        trigger = false;
        flower.use = false;
        fruit.use = false;
        flowerLoop.use = false;
        print("�˳���ײ��Χ");
        BB.GetChild(0).gameObject.SetActive(false);
        Player.GetChild(0).gameObject.SetActive(false);
    }

    // ��������
    void Dialogue()
    {
        if (Input.GetMouseButtonDown(0) && Bdia1 && index <= 5)
        {
            if (index == 5)
            {
                Player.GetChild(0).gameObject.SetActive(false);
                BB.GetChild(0).gameObject.SetActive(false);
                // �ָ���ɫ�ű�
                PlayerController playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
                playerController.GetComponent<PlayerController>().enabled = true;
                Bdia1 = false;
                index--;
            }
            else if (index == 0 || index == 3)
            {
                BB.GetChild(0).gameObject.SetActive(false);
                Player.GetChild(0).gameObject.SetActive(true);
                Player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = Playerdialogue[Pindex];
                Pindex++;
            }
            else
            {
                Player.GetChild(0).gameObject.SetActive(false);
                BB.GetChild(0).gameObject.SetActive(true);
                BB.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = BBdialogue[BBindex];
                BBindex++;
            }
            index++;
        }
        else if (Input.GetMouseButtonDown(0) && Bdia2 && index <= 9)
        {
            if (index == 9)
            {
                Player.GetChild(0).gameObject.SetActive(false);
                BB.GetChild(0).gameObject.SetActive(false);
                // �ָ���ɫ�ű�
                PlayerController playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
                playerController.GetComponent<PlayerController>().enabled = true;
                Bdia2 = false;
                next = true;
                BBindex = 1;
            }
            else if (index == 5)
            {
                BB.GetChild(0).gameObject.SetActive(false);
                Player.GetChild(0).gameObject.SetActive(true);
                Player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = Playerdialogue[Pindex];
                Pindex++;
            }
            else
            {
                Player.GetChild(0).gameObject.SetActive(false);
                BB.GetChild(0).gameObject.SetActive(true);
                BB.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = BBdialogue[BBindex];
                BBindex++;
            }
            index++;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            BB.GetChild(0).gameObject.SetActive(true);
            BB.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = BBdialogue[BBindex - 1];
        }
    }
}
