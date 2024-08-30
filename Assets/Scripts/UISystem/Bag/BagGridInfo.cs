using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagGridInfo : MonoBehaviour
{
    public itemCreate item;

    // �����������ʱҪִ��....
    public void ItemClicked()
    {
        int index = transform.GetSiblingIndex();
        addtobag.showItem(item, index);
        print(index);
    }

    // ���������Ʒ�����ӱ�����ɾ������Ʒ
    public void ItemDiscard()
    {
        // ��ȡ�������Ʒ
        int index = transform.GetSiblingIndex();
        // ��ȡ��ұ���
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
        // ��ȡ����UI
        GameObject bag = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(1).gameObject;
        // ��ȡ������
        GameObject Grid = bag.transform.GetChild(1).gameObject;
        if (bagList.bagList[index].ItemNum == 1){
            // ɾ����ұ����е���Ʒ����
            bagList.bagList.Remove(bagList.bagList[index]);
            // �Ƴ�����UI
            Destroy(Grid.transform.GetChild(index).gameObject);}
        else bagList.bagList[index].ItemNum -= 1;
        // ˢ��
        addtobag.RefreshItem();
    }

    // �����Ʒ��ʹ����Ʒ�����ӱ�����ɾ������Ʒ
    public void ItemUse()
    {
        // ��ȡ�������Ʒ
        int index = transform.GetSiblingIndex();
        // ��ȡ��ұ���
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
        // ��ȡ����UI
        GameObject bag = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(1).gameObject;
        // ��ȡ������
        GameObject Grid = bag.transform.GetChild(1).gameObject;

        // ��Ϊ����������Ʒ����Ӻ�������
        //---------------�ؿ�1-----------------//
        // ������
        if( bagList.bagList[index].name == "����" || bagList.bagList[index].name == "����" || bagList.bagList[index].name == "��ˮ�Ļ�" )
        {
            print("��������Ʒ��" + bagList.bagList[index].name);
            // ������NPC�ĶԻ�
            Beibei bb = GameObject.FindGameObjectWithTag("beibei").transform.GetComponent<Beibei>();
            bb.Bdia2 = true;
        }

        // ��ȡ����β�����κ�ˮ
        if(bagList.bagList[index].name == "����ƿ")
        {
            // �жϱ����Ƿ��п�λ
            if (bagList.bagList.Count < 10)
            {
                if (ControlCar.TailGas && ControlCar.have) ControlCar.get = true; // ����β��
                else if (LakeGet.have && LakeGet.lake) LakeGet.get = true; // �κ�ˮ
                else
                {
                    bagList.bagList[index].ItemNum++;
                    UIcontrol.PopUpTip(5);
                }
            }
            else
            {
                UIcontrol.PopUpTip(0);
                bagList.bagList[index].ItemNum++;
            }
        }

        // ���ͷ�Ӧ
        if (bagList.bagList[index].name == "���ͷ�Ӧ")
        {
            // ����ʹ�ö���
            GameObject time = GameObject.FindGameObjectWithTag("Time").transform.gameObject;
            time.transform.GetChild(1).gameObject.SetActive(true);
        }
        //---------------�ؿ�1-----------------//

        //---------------�ؿ�2-----------------//
        // ʹ��ľ��
        if(bagList.bagList[index].name == "ľ��")
        {
            marsh.ChangeMarsh();
            bagList.bagList[index].ItemNum = 1;
        }

        // �ɼ�өʯ
        if (bagList.bagList[index].name == "өʯ")
        {
            // ����NPC��������
            Give.Imageindex(3);
            AnimationControl.Give(1,0);
            // ������NPC�ĶԻ�
            Explorer exp = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(0).gameObject.GetComponent<Explorer>();
            exp.Edia1 = true;
            bagList.bagList[index].ItemNum = 1;
        }

        // �������
        if (bagList.bagList[index].name == "���")
        {
            // ������NPC�ĶԻ�
            Clockman clockman = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<Clockman>();
            clockman.ljian = true;
            // ������NPC�Ľ�������
            AnimationControl.Give(1,1);
            Give.Imageindex(6);
            bagList.bagList[index].ItemNum = 1;
        }

        // ���軵�ı�
        if (bagList.bagList[index].name == "���ı�")
        {
            // �����Ի�
            Clockman clockman = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<Clockman>();
            clockman.clock = true;
            // ������NPC�Ľ�������
            AnimationControl.Give(1,1);
            Give.Imageindex(5);
        }

        // ����ƾ�
        if (bagList.bagList[index].name == "�ƾ�")
        {
            // �����Ի�
            Clockman clockman = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<Clockman>();
            clockman.acholc = true;
            // ������NPC�Ľ�������
            Give.Imageindex(7);
            AnimationControl.Give(1,1);
        }

        // �����޺õı�
        if (bagList.bagList[index].name == "�޺õı�")
        {
            // ������NPC�Ľ�������
            Explorer explorer = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(0).gameObject.GetComponent<Explorer>();
            AnimationControl.Give(1,0);
            Give.Imageindex(4);
            // �����Ի�
            explorer.Edia2 = true;
        }

        // ʹ�����ը��
        if (bagList.bagList[index].name == "���ը��")
        {
            // ����ʹ�ö���
            GameObject time = GameObject.FindGameObjectWithTag("Time").transform.gameObject;
            time.transform.GetChild(2).gameObject.SetActive(true);
        }

        //---------------�ؿ�2-----------------//

        //---------------�ؿ�3-----------------//
        // ʹ�ð��׵�
        if (bagList.bagList[index].name == "����")
        {
            // ����
            ForeGrond fore = GameObject.Find("Grid").transform.GetChild(2).gameObject.GetComponent<ForeGrond>();
            fore.lightuse = true;
            bagList.bagList[index].ItemNum++;
        }

        // ʹ�ð����������мң�
        if (bagList.bagList[index].name == "����")
        {
            // �����Ի�
            Traveller tra = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(0).gameObject.GetComponent<Traveller>();
            tra.pack = true;
            // ������NPC�Ľ�������
            AnimationControl.Give(1, 0);
            Give.Imageindex(8);
        }

        // ʹ�ó�ǰ��
        if (bagList.bagList[index].name == "��ǰ��")
        {
            // �����Ի�
            Patient pat = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<Patient>();
            pat.Green = true;
            // ������NPC�Ľ�������
            AnimationControl.Give(1, 1);
            Give.Imageindex(9);
        }

        // ʹ���ռ���Һ
        if(bagList.bagList[index].name == "�ռ���Һ")
        {
            // ����ʹ�ö���
            GameObject time = GameObject.FindGameObjectWithTag("Time").transform.gameObject;
            time.transform.GetChild(2).gameObject.SetActive(true);
        }

        //---------------�ؿ�3-----------------//

        //---------------�ؿ�4-----------------//
        // ʹ�û���
        if (bagList.bagList[index].name == "����" || bagList.bagList[index].name == "���տ�"
            || bagList.bagList[index].name == "õ�廨" || bagList.bagList[index].name == "�ٺ�")
        {
            // �����Ի�
            TilemGuard tilem = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<TilemGuard>();
            tilem.flowerindex = 3;
            tilem.flower = true;
        }

        if (bagList.bagList[index].name == "����")
        {
            // �����Ի�
            TilemGuard tilem = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<TilemGuard>();
            tilem.flowerindex = 4;
            tilem.flower = true;
            // ������NPC�Ľ�������
            AnimationControl.Give(1, 1);
            Give.Imageindex(11);
        }

        if (bagList.bagList[index].name == "������")
        {
            // �����Ի�
            TilemGuard tilem = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<TilemGuard>();
            tilem.flowerindex = 5;
            tilem.flower = true;
            // ������NPC�Ľ�������
            AnimationControl.Give(1, 1);
            Give.Imageindex(12);
        }

        if (bagList.bagList[index].name == "ʬ��ħ��")
        {
            // �����Ի�
            TilemGuard tilem = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<TilemGuard>();
            tilem.flowerindex = 6;
            tilem.flower = true;
            // ������NPC�Ľ�������
            AnimationControl.Give(1, 1);
            Give.Imageindex(13);
        }
        //---------------�ؿ�4-----------------//

        // ɾ����Ʒ
        if (bagList.bagList[index].ItemNum == 1)
        {
            // ɾ����ұ����е���Ʒ����
            bagList.bagList.Remove(bagList.bagList[index]);
            // �Ƴ�����UI
            Destroy(Grid.transform.GetChild(index).gameObject);

        }
        else
        {
            bagList.bagList[index].ItemNum -= 1;
        }

        // ˢ��
        addtobag.RefreshItem();
    }
}
