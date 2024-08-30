using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchitem : MonoBehaviour
{
    // Start is called before the first frame update
    // ��ǰ������
    public Transform fatherItem;
    // ��������д���ĸ�����
    public bagCreate playerBag;
    // �����ݸ��µ���һ��������
    public itemCreate item;

    void Start()
    {
        fatherItem = GetComponent<Transform>();
        // ���������ж����ͬ������ʱ��������Ϸ���Զ���������x����
        if (fatherItem.name.Contains("("))
        {
            string[] strArray = fatherItem.name.Split(' ');
            fatherItem.name = strArray[0];
        }
        playerBag = Resources.Load<bagCreate>("bag/bagData/playerbag");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ��ײ���,ʰȡ·�ߵ���ʱ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerBag.bagList.Count < 10)
            {
                // �������ݵ�����
                updateItemsAndBagData();
                Destroy(fatherItem.gameObject);
            }
            // ��������������ʾ
            else
            {
                UIcontrol.PopUpTip(0);
            }
        }
    }

    // ��ȡ��Ʒ��������ݵ�������
    public void updateItemsAndBagData()
    {
        // �жϱ����Ƿ��������Ʒ
        if (!playerBag.bagList.Contains(item)){
            print("add: " + item.name);
            playerBag.bagList.Add(item);
        }
        else
        {
            // ���������Ƿ���Ե���
            if (item.superposition)
            {
                item.ItemNum += 1;
            }
            else
            {
                print("add: " + item.name);
                playerBag.bagList.Add(item);
            }
        }

        // ��ʾ���ϳɽ���
        addtocomposeui.RefreshItem();
        // ��ʾ����������
        addtobag.RefreshItem();
    }
}
