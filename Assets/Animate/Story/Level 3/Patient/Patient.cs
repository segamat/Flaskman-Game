using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patient : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform patient;
    private Transform player;
    private Animator anim;

    // ��ȡ��Ʒ����
    itemCreate green;
    string itemName = "��ǰ��";

    // �Ի������±�
    private int index = 0;
    private int pindex = 0;
    private int Paindex = 1;

    // �Ի�����
    private string[] PatientDialogue = {  "�ȿ�...�ȿ�..."
            , "�������������ӣ���Ҫ�Ұ�æ��"
            , "�ȿȣ����е㲻������ȿȣ������ҵ�ҩ������"
            , "�ȿȣ�����ԣ��ȿȣ�������һ�㣬�ȿȣ���ǰ���𣬿ȿȣ�"
            , "û���⡣����û������ǰ�ݡ�"
            , "�ȿȣ�����ҶƬ�ǿ����εģ��ȿȣ��г�����"
            , "��֪���ˣ�������������Ϣһ�°ɣ������ϻ�����"
            , "�ҵ���������"
            , "�ȿȣ�лл�㣬�ȿȣ��Ҵ�������������ȿȡ�"
            , "�ȿȣ���Ϊ���꣬������һ��̼�����ưɣ��ȿȡ�"
            , "�ۣ�̫���ˣ���������Ҫ��л����"};

    // �л��Ի���ʱ��
    private float ChangeTime;

    // �Ƿ�����ײ��Χ֮��
    private bool trigger = false;

    // �Ƿ���Լ����Ի�
    public bool star = false;
    // �õ���������Լ����Ի�
    public bool Green = false;

    void Start()
    {
        patient = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = patient.GetChild(0).GetComponent<Animator>();
        anim.SetBool("give", false);
        green = Resources.Load<itemCreate>("bag/itemData/" + itemName);
    }

    // Update is called once per frame
    void Update()
    {
        if (star)
        {
            if (ChangeTime > 1)
            {
                ChangeTime = 0;
            }
            else ChangeTime += Time.deltaTime;
        }
        ChangDialogue();
    }

    // ��ײ��Χ֮��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Patient : " + collision.name);
        if (collision.gameObject.name == "Player")
        {
            star = true;
        }
        player.GetChild(0).gameObject.SetActive(true);
        player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = PatientDialogue[0];
        green.use = true;
    }

    // ��ײ��Χ֮��
    private void OnTriggerExit2D(Collider2D collision)
    {
        star = false;
        ChangeTime = 0;
        player.GetChild(0).gameObject.SetActive(false);
        green.use = false;
    }

    // �л��Ի�
    void ChangDialogue()
    {
        if (Input.GetMouseButtonDown(0) && star)
        {
            player.GetChild(0).gameObject.SetActive(true);
            // �ƶ����λ��
            if (player.position != patient.GetChild(3).transform.position)
            {
                player.position = patient.GetChild(3).transform.position;
            }
            if (index <= 5)
            {
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = PatientDialogue[Paindex];
                Paindex++;
                index++;
            }
            if (index >= 6 && index <= 9 && Green)
            {
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = PatientDialogue[Paindex];
                if(index == 9)
                {
                    Give.Imageindex(14);
                    AnimationControl.Give(0, 1);
                    addtocomposeui.additem("̼������");
                }
                Paindex++;
                index++;
            }
            else player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = PatientDialogue[Paindex - 1];
        }
    }
}
