using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marsh : MonoBehaviour
{
    // Start is called before the first frame update
    static Transform mar;
    public itemCreate wood;
    void Start()
    {
        mar = GameObject.Find("Marsh").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ��ײʱ������ʹ����������3��ľ��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && wood.ItemNum >= 3)
        {
            wood.use = true;
        }
    }

    // �뿪��ײ�󲻿�ʹ��ľ��
    private void OnCollisionExit2D(Collision2D collision)
    {
        wood.use = false;
    }

    // �ı�����״̬�����ľ��
    public static void ChangeMarsh()
    {
        mar.GetChild(1).gameObject.SetActive(true);
        mar.GetChild(0).gameObject.SetActive(false);
    }
}
