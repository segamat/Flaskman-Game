using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addtobag : MonoBehaviour
{
    static addtobag tobagUI;
    // Start is called before the first frame update
    void Start()
    {
        if (!tobagUI)
        {
            tobagUI = null;
        }
        tobagUI = this;
        RefreshItem(); // ˢ����Ʒ��
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �ѱ����е���Ʒ��Ⱦ���ϳɽ���
    public static void addItemtoBag(itemCreate item)
    {
        // ��ȡ������Ԥ����
        BagGridInfo baggridprefab = Resources.Load<BagGridInfo>("UI-preform/BagGrid");
        // ��ȡ����������
        GameObject bag = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(1).gameObject;
        // ��ȡ��������
        GameObject bagGrid = bag.transform.GetChild(1).gameObject;
        // ��Ҫ����������Ԥ���壬������������
        BagGridInfo newitem = Instantiate(baggridprefab, bagGrid.transform.position, Quaternion.identity);
        // ����һ�¸�����
        newitem.gameObject.transform.SetParent(bagGrid.transform);

        // ��ֵ����
        newitem.item = item;
        // ��ֵԤ������ʾ��ͼƬ������
        newitem.GetComponent<Image>().sprite = item.ItemImage;
        newitem.gameObject.transform.GetChild(0).GetComponent<Text>().text = item.ItemNum.ToString();
    }

    // ˢ����Ʒ����
    public static void RefreshItem()
    {
        // ��ȡ����
        GameObject bag = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(1).gameObject;
        // ��ȡ��������
        GameObject bagGrid = bag.transform.GetChild(1).gameObject;
        // ����������������Ʒ������ɾ������������
        for (int i = 0; i < bagGrid.transform.childCount; i++){
            if (bagGrid.transform.childCount == 0) break;
            else Destroy(bagGrid.transform.GetChild(i).gameObject);
        }
        //�����������ݣ�����Ʒ��������
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
        for (int i = 0; i < bagList.bagList.Count; i++)
            addItemtoBag(bagList.bagList[i]);
    }

    // �����Ʒ��ʾ������
    public static void showItem(itemCreate item, int index)
    {
        // ��ȡ����
        GameObject bag = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(1).gameObject;
        // ��ȡ��������
        GameObject bagGrid = bag.transform.GetChild(1).gameObject;
        // ��ʾ��ť
        for (int i = 0; i < bagGrid.transform.childCount; i++){
            if (i == index){
                bool state = bagGrid.transform.GetChild(i).GetChild(1).gameObject.activeSelf;
                bagGrid.transform.GetChild(i).GetChild(1).gameObject.SetActive(!state);
                bagGrid.transform.GetChild(i).GetChild(1).GetComponent<Text>().text = item.name;
                bagGrid.transform.GetChild(i).GetChild(2).gameObject.SetActive(!state);
                if (item.name == "ľ��" && item.ItemNum == 3) item.use = true;
                if (item.name == "���" && item.ItemNum == 3) item.use = true;
                if (item.use) bagGrid.transform.GetChild(i).GetChild(3).gameObject.SetActive(!state);

            }
            else{
                bagGrid.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
                bagGrid.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                bagGrid.transform.GetChild(i).GetChild(3).gameObject.SetActive(false);
            }
        }
    }
}
