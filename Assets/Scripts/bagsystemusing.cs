using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagsystemusing : MonoBehaviour
{
    // ��ͼ�ϵ�ͨ����ײ���ʰȡ����Ʒ������ο�torchitem.cs
    // �����Ʒ����ұ���,ͬʱˢ����Ʒ���ͺϳɽ���
    // ����ֱ���ں����ڵ���  addtocomposeui.additem(name);
    // Ҳ����д����κ���
    public static void additem(string name)// nameΪ��Ҫ��ӵ���Ʒ����
    {
        bagCreate playerBag;
        itemCreate item;
        playerBag = Resources.Load<bagCreate>("bag/bagData/playerbag"); // ������ұ���
        item = Resources.Load<itemCreate>("bag/itemData/" + name); // ������Ʒ

        // �жϱ����Ƿ��������Ʒ
        if (!playerBag.bagList.Contains(item))
        {
            // �����Ƿ�����
            if (playerBag.bagList.Count <= 10)
            {
                playerBag.bagList.Add(item);
            }
            else
            {
                UIcontrol.PopUpTip(0);// �����Ի�����ʾ��������
            }
        }
        else
        {// ���������Ƿ���Ե���
            if (item.superposition)
            {
                item.ItemNum += 1;
            }
            else
            {
                // �����Ƿ�����
                if (playerBag.bagList.Count <= 11) playerBag.bagList.Add(item);
                else
                {
                    UIcontrol.PopUpTip(0);// �����Ի�����ʾ��������
                }
            }
        }
        // ˢ����Ʒ���ͺϳɽ���
        addtobag.RefreshItem();
        addtocomposeui.RefreshItem();
        
    }

    // ʹ�ú󣬴���ұ�����ɾ����Ʒ
    // ���ڿ���ʹ����Ʒ�󣬽�item.use��Ϊtrue
    // itemCreate item = Resources.Load<itemCreate>("bag/itemData/" + name); // ������Ʒ
    // item.use = true;
    // ���ú�����Ʒ������Ʒ�Ż���ʾʹ�ð�����
    // BagGridInfo.cs �е� ItemUse() �����������ʹ����Ʒ�ĺ�������
}
