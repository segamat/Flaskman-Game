using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeGet : MonoBehaviour
{
    // Start is called before the first frame update
    bagCreate bagList;

    // �Ƿ���Ի�ȡ�κ�ˮ
    public static bool get = false; // ����Ƿ��ڻ�ȡ
    public static bool lake = false; // �Ƿ�����ײ��Χ��
    public static bool have = true; // �Ƿ���Ի�ȡ

    public itemCreate item;
    void Start()
    {
        // ��ȡ��ұ���
        bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
    }

    // Update is called once per frame
    void Update()
    {
        // �жϱ������Ƿ����κ�ˮ��û�вſ��Ի�ȡ
        if (bagList.bagList.Contains(item)) have = false;
        else have = true;
        // �ж�����Ƿ����ڻ�ȡ�κ�ˮ
        if (get) GetLakes();
    }

    // ��ײʱ�ɻ�ȡ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        lake = true;
    }

    // �뿪��ײ��Χ�󲻿ɻ�ȡ
    private void OnCollisionExit2D(Collision2D collision)
    {
        lake = false;
    }

    // ��ȡ�κ�ˮ
    private void GetLakes()
    {
        // ���������κ�ˮ�򲻿��Ի�ȡ
        for (int i = 0; i < bagList.bagList.Count; i++)
        {
            if (bagList.bagList[i].name == "�κ�ˮ") get = false;
        }

        if (get)
        {
            addtocomposeui.additem("�κ�ˮ");
            have = false;
        }
    }
}
