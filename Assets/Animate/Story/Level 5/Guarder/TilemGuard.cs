using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TilemGuard : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform traveller;
    public Transform player;
    private Animator anim;

    // ��ȡ��Ʒ����
    public itemCreate ling;
    public itemCreate he;
    public itemCreate shi;
    public itemCreate lan;
    public itemCreate ri;
    public itemCreate rose;
    public itemCreate bai;
    public itemCreate mirror;
    bagCreate playerbag;

    // �Ի������±�
    private int index = 0;
    private int gindex = 2;
    public int flowerindex = 4;

    // �Ի�����
    private string[] TilemGuardDialogue = {  "ʥ�԰�����˲������ڣ�"
            , "�ðɣ���Ҫ�����ڻ�԰�����������صĻ����Ҿ͸�������Թ�����ʾ��"
            , "����Ǻ����أ���ô�ҽ���������Թ�����ʾ��"
            , "��ʾ����Ҫʱ�̿����Լ����ܿ���ͨ���Թ���·��"
            , "ʱ�̿����Լ����ѵ�����Ҫ�Ҵ��ž�����"};

    private string[] Flower = { "��ѽ���������ͨ�Ļ���ûʲô���صġ�"
            , "�㿴��֦�������Ļ�����һ����С���������ţ�����Ȥ��"
            , "��仨��һֻչ�����ɵ��ɺף��ر�������"
            , "С�ĵ㣬�⻨�������»á�" };

    // �л��Ի���ʱ��
    private float ChangeTime;

    // �Ƿ�����ײ��Χ֮��
    private bool trigger = false;

    // �Ƿ���Լ����Ի�
    public bool star = false;
    // �õ��������Լ����Ի�
    public bool flower = false;
    public bool Labyrinth = false;

    void Start()
    {
        playerbag = Resources.Load<bagCreate>("bag/bagData/playerbag");
        traveller = GetComponent<Transform>();
        print(player);
        anim = traveller.GetChild(4).GetComponent<Animator>();
        anim.SetBool("give", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerbag.bagList.Contains(mirror))
        {
            Labyrinth = true;
        }
        else
        {
            Labyrinth = false;
        }
        ChangDialogue();
    }

    // ��ײ��Χ֮��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Traveller : " + collision.name);
        if (collision.gameObject.name == "Player")
        {
            star = true;
        }
        player.GetChild(0).gameObject.SetActive(true);
        player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = TilemGuardDialogue[0];
        lan.use = true;
        ri.use = true;
        rose.use = true;
        bai.use = true;
        ling.use = true;
        he.use = true;
        shi.use = true;
    }

    // ��ײ��Χ֮��
    private void OnTriggerExit2D(Collider2D collision)
    {
        star = false;
        ChangeTime = 0;
        player.GetChild(0).gameObject.SetActive(false);
        lan.use = false;
        ri.use = false;
        rose.use = false;
        bai.use = false;
        ling.use = false;
        he.use = false;
        shi.use = false;
    }

    // �л��Ի�
    void ChangDialogue()
    {
        if (Input.GetMouseButtonDown(0) && star)
        {
            print(index);
            player.GetChild(0).gameObject.SetActive(true);
            // �ƶ����λ��
            if (player.position != traveller.GetChild(3).transform.position)
            {
                player.position = traveller.GetChild(3).transform.position;
            }
            if (index >= 0 && index <=3 && flower)
            {
                if (index == 0)
                {
                    print("flower: " + flower);
                    player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = Flower[flowerindex - 3];
                    if (flowerindex <=3)
                    {
                        index--;
                        flower = false;
                    }
                }
                else
                {
                    player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = TilemGuardDialogue[gindex];
                    gindex++;
                }
                index++;
            }
            else if(index == 0 && !flower)
            {
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = TilemGuardDialogue[1];
            }
            else if(index == 4 && Labyrinth)
            {
                Transform quest = GameObject.FindGameObjectWithTag("uisystem").transform;
                quest.GetChild(0).gameObject.SetActive(false);
                quest.GetChild(2).gameObject.SetActive(true);
            }
        }
    }

    
}
