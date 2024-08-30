using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grocery : MonoBehaviour
{
    // Start is called before the first frame update
    // �Ƿ���Ҫ����
    public bool dia = false;
    // �Ƿ���Խ�����һ������
    public bool next = false;
    // ����Ի�
    private string[] PlayerDialogue = { "DD����֪��֪��С�Ǻ���ʲô��"
            , "����֪�����������ƻ�����"
            , "�ðɡ�" };

    private string[] DDdialogue = { "��ӭ����С������"
            , "��Ҳ��֪���ء�"
            , "����ס��ҽԺ���Ϸ��ı�������֪����"
            , "���ҵ���֪���������Ը�ʴ����" };
    private int index = 1;
    private int Playerindex = 0;
    private int Groveryindex = 1;

    // ��ȡ�Ի�����
    private Transform DD;
    // ��ȡ��ƿ������
    private Transform Player;

    void Start()
    {
        DD = GetComponent<Transform>().parent;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Dialogue();
    }

    // ����ײ��Χ��
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (index == 1) dia = true;
        DD.GetChild(1).gameObject.SetActive(true);
        DD.GetChild(1).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = DDdialogue[0];
        if (dia)
        {
            // ʧ����DD����С����
            DD.GetComponent<ClickControl>().enabled = false;
            // ʧ���ɫ�ű�
            PlayerController playerController = GameObject.FindWithTag("Player").transform.GetComponent<PlayerController>();
            playerController.enabled = false;
        }
    }

    // ����ײ��Χ֮��
    void OnCollisionExit2D(Collision2D collision)
    {
        DD.GetChild(1).gameObject.SetActive(false);
    }
    
    // ��������
    void Dialogue()
    {
        if (Input.GetMouseButtonDown(0) && dia && index <= 8)
        {
            if (index > 6)
            {
                Player.GetChild(0).gameObject.SetActive(false);
                DD.GetChild(1).gameObject.SetActive(false);
                // �ָ���ɫ�ű�
                PlayerController playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
                playerController.GetComponent<PlayerController>().enabled = true;
                // �ָ��������С��������
                DD.GetComponent<ClickControl>().enabled = true;
                // ������Ի��ű�
                Beibei bb = GameObject.FindGameObjectWithTag("beibei").GetComponent<Beibei>();
                bb.enabled = true;

                dia = false;
                next = true;
            }
            else if (index == 1 || index == 4 || index == 6)
            {
                DD.GetChild(1).gameObject.SetActive(false);
                Player.GetChild(0).gameObject.SetActive(true);
                Player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = PlayerDialogue[Playerindex];
                Playerindex++;
            }
            else
            {
                Player.GetChild(0).gameObject.SetActive(false);
                DD.GetChild(1).gameObject.SetActive(true);
                DD.GetChild(1).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = DDdialogue[Groveryindex];
                Groveryindex++;
            }
            index++;
        }
    }
}
