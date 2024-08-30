using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Traveller : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform traveller;
    private Transform player;
    private Animator anim;

    // ��ȡ��Ʒ����
    itemCreate Pack;
    string itemName = "����";

    // �Ի������±�
    private int index = 0;
    private int pindex = 0;
    private int tindex = 1;

    // �Ի�����
    private string[] TravellerDialogue = { "��ѽ����ô����..."
            , "���ѽ���ѣ�����ô��ü�������أ�������ʲô��������"
            , "���С��ƿ���ҵİ�����С�ĵ����Աߵ�ɽ������"
            , "����ɽ����̫���ˣ��ҿ����������ģ���~"
            , "�ҿ��������������ȥ�ģ��ǲ���Ҳ���������ˣ�"
            , "��ѽ���ҵ�·��һƬǺ�˵���ס�ˣ���֪����ô��ȥ��"
            , "�����ҿ��԰���ȥɽ����Ѱ�����������"
            , "ɽ����ɺ��ˣ�û�е���û�а취�ҵ���"
            , "Ҫ��������ܰ��Ҵ��ذ������Ҿ͸�������ô����Ƭ��"
            , "һ��Ϊ��������������Ұɣ�"
            , "���������ð�����ȼ����һյС�ƣ�����һЩ��ʯ�ӽ�̿��ȡ���װ�"
            , "�������ǲ�����İ���"
            , "��İ��ҵİ����ҵ���!"
            , "��Ƭ����ʵ�Ƕ����������壬ֻ��Ҫ�ҵ������ռ���Һ�Ϳ��԰Ѷ�������ȫ�����գ��Ϳ��԰�ȫͨ���ˡ�"};

    // �л��Ի���ʱ��
    private float ChangeTime;

    // �Ƿ�����ײ��Χ֮��
    private bool trigger = false;

    // �Ƿ���Լ����Ի�
    public bool star = false;
    // �õ���������Լ����Ի�
    public bool pack = false; 

    void Start()
    {
        traveller = GetComponent<Transform>();
        print(traveller.name);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = traveller.GetChild(0).GetComponent<Animator>();
        anim.SetBool("give", false);
        Pack = Resources.Load<itemCreate>("bag/itemData/" + itemName);
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
        print("Traveller : " + collision.name);
        if (collision.gameObject.name == "Player")
        {
            star = true;
        }
        player.GetChild(0).gameObject.SetActive(true);
        player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = TravellerDialogue[0];
        Pack.use = true;
    }

    // ��ײ��Χ֮��
    private void OnTriggerExit2D(Collider2D collision)
    {
        star = false;
        ChangeTime = 0;
        player.GetChild(0).gameObject.SetActive(false);
        Pack.use = false;
    }

    // �л��Ի�
    void ChangDialogue()
    {
        if (Input.GetMouseButtonDown(0) && star)
        {
            player.GetChild(0).gameObject.SetActive(true);
            // �ƶ����λ��
            if (player.position != traveller.GetChild(3).transform.position)
            {
                player.position = traveller.GetChild(3).transform.position;
            }
            if(index <= 9)
            {
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = TravellerDialogue[tindex];
                tindex++;
                index++;
            }
            if (index >= 10 && index <= 12 && pack)
            {
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = TravellerDialogue[tindex];
                tindex++;
                index++;
            }
            else
            {
                player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = TravellerDialogue[tindex - 1];
            }
        }
    }
}
