using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;

public class Give : MonoBehaviour
{
    // ��ȡ������
    private Transform tran;
    private Transform Player;
    public Transform Target;
    public Transform item;
    // ��ȡ��Ʒ
    public static itemCreate Image;
    // ��ȡ��Һ�NPC�����������
    Animator Anim;
    Animator PAnim;
    // ��Ʒ����
    static string[] itemName = { "����", "����", "��ˮ�Ļ�" // 0 1 2
            , "өʯ", "�޺õı�"  // 3 4
            , "���ı�", "���", "�ƾ�"  // 5 6 7 
            , "����", "��ǰ��"  // 8 9
            , "����ҩ", "����", "������", "ʬ��ħ��"  // 10 11 12 13
            , "̼������" };    // 14

    // ��������ʱ��
    float totletime = 0;
    int index = 0;
    // ��Ʒ�±�
    static int imageindex = 0;
    // ��Һ�NPC�л�����ʱ��
    public int changeindex;
    public int changeindexp;
    // �ر�ʱ��
    public int closeindex;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        tran = GetComponent<Transform>();
        Anim = Target.GetComponent<Animator>();
        PAnim = Player.GetChild(1).GetComponent<Animator>();
        item.GetComponent<SpriteRenderer>().sprite = Image.ItemImage;
    }

    // Update is called once per frame
    void Update()
    {
        totletime += Time.deltaTime;
        if (totletime > 1)
        {
            print("Give: " + index);
            totletime = 0;
            ChangAnim(index);
            ChangAnimPlay(index);
            index++;
        }
        if (index == closeindex) close();
    }

    // �л�����
    void ChangAnim(int index)
    {
        if (index == changeindex)
        {
            Anim.SetBool("give", true);
        }
        if (index == changeindex + 2)
        {
            Anim.SetBool("give", false);
        }
    }

    // �л��������
    void ChangAnimPlay(int index)
    {
        if (index == changeindexp)
        {
            PAnim.SetBool("give", true);
            PAnim.SetBool("left", false);
            PAnim.SetBool("right", false);
            PAnim.SetBool("lefting", false);
            PAnim.SetBool("righting", false);
        }
        if (index == changeindexp + 1)
        {
            PAnim.SetBool("give", false);
            PAnim.SetBool("left", false);
            PAnim.SetBool("right", true);
            PAnim.SetBool("lefting", false);
            PAnim.SetBool("righting", false);
        }
    }

    // �رն���
    void close()
    {
        print("�رն���");
        index = 0;
        item.gameObject.SetActive(false);
        tran.gameObject.SetActive(false);
    }

    // ������ƷͼƬ
    public static void Imageindex(int index)
    {
        imageindex = index;
        Image = Resources.Load<itemCreate>("bag/itemData/" + itemName[imageindex]);
        print(Image.name);
    }

}
