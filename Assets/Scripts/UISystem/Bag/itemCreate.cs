using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item name",menuName = "bag/Create new item")]
public class itemCreate : ScriptableObject
{
    //��Ʒ��
    public string ItemName;

    //��ƷͼƬ
    public Sprite ItemImage;

    //��Ʒ����
    public string ItemScription;

    //��Ʒ����
    public int ItemNum;

    //��Ʒ����Ԫ��
    public int ItemElementnum;
    public string ItemElement1;
    public string ItemElement2;
    public string ItemElement3;

    //��Ʒ������
    public int price;

    //�Ƿ������ȡԪ��
    public bool mergy;

    //�Ƿ����ʹ����Ʒ
    public bool use;

    //�Ƿ�����ۼ���Ʒ
    public bool superposition;
    
}
