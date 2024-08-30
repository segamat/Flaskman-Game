using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addtogrocery : MonoBehaviour
{
    static addtogrocery togroceryUI;
    private Transform Grocery;
    int fund;
    // Start is called before the first frame update
    void Start()
    {
        if (!togroceryUI)
        {
            togroceryUI = null;
        }
        togroceryUI = this;
        ShowGoods();
        
    }

    // Update is called once per frame
    void Update()
    {
        fund = GameObject.FindWithTag("Player").GetComponent<PlayerController>().fund;
        Grocery = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(3).GetChild(6).transform;
        Grocery.GetChild(0).GetComponent<Text>().text = fund.ToString();
    }

    // �����Ʒ��С��������
    void addItem(itemCreate item)
    {
        // ��ȡ������Ԥ����
        GoodsPrefab goods = Resources.Load<GoodsPrefab>("UI-preform/goods");
        // ��ȡ����������
        GameObject grocery = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(3).gameObject;
        // ��ȡ��������
        GameObject groceryGrid = grocery.transform.GetChild(3).gameObject;
        // ��Ҫ����������Ԥ���壬������������
        GoodsPrefab newitem = Instantiate(goods, groceryGrid.transform.position, Quaternion.identity);
        // ����һ�¸�����
        newitem.gameObject.transform.SetParent(groceryGrid.transform);

        // ��ֵ����
        newitem.item = item;
        // ��ֵԤ������ʾ��ͼƬ������
        newitem.GetComponent<Image>().sprite = item.ItemImage;
        newitem.gameObject.transform.GetChild(1).GetComponent<Text>().text = item.price.ToString();
    }

    // ��Ⱦ��Ʒ��UI����
    void ShowGoods()
    {
        // ��ȡС�������ݿ�
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/groceryBag");
        
        for (int i = 0; i < bagList.bagList.Count; i++)
        {
            addItem(bagList.bagList[i]);
        }
    }

    // �����ʾ��ϸ����
    public static void ShowDetail(itemCreate item, int index)
    {
        // ���������ı�����
        // ��ȡ����
        GameObject grocery = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(3).gameObject;
        // ��ȡ��������
        GameObject groceryGrid = grocery.transform.GetChild(3).gameObject;
        // ��ʾ��ť
        for (int i = 0; i < groceryGrid.transform.childCount; i++)
        {
            if (i == index)
            {
                print(index);
                GameObject good = grocery.transform.GetChild(3).GetChild(index).GetChild(2).gameObject;
                good.SetActive(!good.activeSelf);
                grocery.transform.GetChild(3).GetChild(index).GetChild(1).GetComponent<Text>().text = item.price.ToString();
                grocery.transform.GetChild(4).GetComponent<Text>().text = item.ItemScription;
            }
        }
    }

}
