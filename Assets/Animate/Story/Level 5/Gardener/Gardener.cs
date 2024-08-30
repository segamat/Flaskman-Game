using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gardener : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform gardener;
    private Transform player;
    private Animator anim;

    // �Ի������±�
    public int index = 0;
    public int gindex = 1;

    // �Ի�����
    private string[] GardenerDialogue = {  "������������С����쳤��"
            , "��ѽ����������ʥ������������ҵ�������˿ɲ���ඡ�"
            , "�ǵģ������ҵ�ʥ�Ҳ�Ƕ��������˵İ�æ��"
            , "԰���������������������ô�ã�֪��֪�������о����أ�"
            , "����ô����뵽�˹��Թ��Ĺؼ��ˣ����Ǵ�����"
            , "�����о��ӣ���������Թ�ֻ�����Լ��ľ���Ӵ��"
            , "����Ҫ���ܻش���һ�����⣬�Ҿ͸���һ����ʾ��"
            , "�ã���������ɡ�"
            , "���ź��������ˡ�"
            , "��ֻ�ܸ�������ȡ������Ҫ�õ�������Һ��һ������������"
            , "��ϲ�����������ǡ�����ҩ������ȡ������Һ��ԭ��֮һ"
            , "����������Һ��һ����������������������"
            , "лл԰����������һ������������ҵľ��ӵģ�"};

    // �л��Ի���ʱ��
    private float ChangeTime;

    // �Ƿ�����ײ��Χ֮��
    private bool trigger = false;

    // �Ƿ���Լ����Ի�
    public bool star = false;
    // �Ƿ���
    public bool answer = false;

    void Start()
    {
        gardener = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = gardener.GetChild(4).GetComponent<Animator>();
        anim.SetBool("give", false);
    }

    // Update is called once per frame
    void Update()
    {
        ChangDialogue();
    }

    // ��ײ��Χ֮��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Gardener : " + collision.name);
        if (collision.gameObject.name == "Player")
        {
            star = true;
        }
        player.GetChild(0).gameObject.SetActive(true);
        player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = GardenerDialogue[0];
    }

    // ��ײ��Χ֮��
    private void OnTriggerExit2D(Collider2D collision)
    {
        star = false;
        ChangeTime = 0;
        player.GetChild(0).gameObject.SetActive(false);
    }

    // �л��Ի�
    void ChangDialogue()
    {
        if (Input.GetMouseButtonDown(0) && star)
        {
            player.GetChild(0).gameObject.SetActive(true);
            print(index);
            // �ƶ����λ��
            if (player.position != gardener.GetChild(3).transform.position)
            {
                player.position = gardener.GetChild(3).transform.position;
            }
            if (index <= 6)
            {
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = GardenerDialogue[gindex];
                gindex++;
                index++;
            }
            else if (index == 7 && !answer)
            {
                print("������");
                Transform quest = GameObject.FindGameObjectWithTag("uisystem").transform;
                quest.GetChild(0).gameObject.SetActive(false);
                quest.GetChild(1).gameObject.SetActive(true);
            }
            else if(!answer && index >= 8 && index <=9)
            {
                print("�ش����");
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = GardenerDialogue[gindex];
                gindex++;
                index++;
            }
            else if(answer && index >= 8 && index <= 9)
            {
                print("�ش���ȷ");
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = GardenerDialogue[gindex];
                gindex++;
                index++;
                if (index == 9)
                {
                    Give.Imageindex(10);
                    AnimationControl.Give(0, 0);
                    addtocomposeui.additem("����ҩ");
                }
            }
            else if (index == 10)
            {
                gindex = 12;
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = GardenerDialogue[gindex];
                gindex++;
            }
            else player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = GardenerDialogue[0];
        }
    }
}