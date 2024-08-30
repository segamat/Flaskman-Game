using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    // ��ȡUI�ĸ�Ԫ��
    private Transform UItest;
    public float tipTime;
    public bool StarTime = true;
    public int Scerentindex;

    // ��ʾ���
    public bool Tipstar = true;
    public bool Shine = false;
    public bool ShineState = false;
    int TipIndex = 0;
    int scene;
    int starindex;
    float shinetime;

    // �ؿ���ʾ����
    string[] Tipdialogue = { 
        // �ؿ�1: 0 1 2
        "����β���к���һ��������������̼��̼�⻯����ȵ�"
            , "������������϶���̼����������ķ�Ӧ"
            , "���ͷ�Ӧ: ����̼+һ������=����ȼ��=����+һ����̼+��������+��" 

            // �ؿ�2: 3 4 5
            , "������ľ����Ϊ���Ӷɹ�����"
            , "����������к��������ǡ����ǵ���������"
            , "��ⱥ�͵�ʳ��ˮ�������������ص�����"
            
            // �ؿ�3: 6 7 8
            , "�׿�ʯ��ʯӢɰ�ͽ�̿�ںܸߵ��¶��¿�����ȡ����"
            , "ɽ�������ʯ�Ҽ�ˮ��������һЩ��������"
            , "̼���ƺ������������ռ���Һ��ԭ��"  

            // �ؿ�4: 9 10 11
            , "������Һ��Ҫ�÷��ϵ�һˮ�ϰ��ͽ����κϳ�"
            , "�����������Һ�����쾵�ӵ���Ҫԭ��"
            , "�����Ǽ���������Һ�ڸ��µ�����¿����ڲ����������Ƴ���"}; 


    void Start()
    {
        UItest = GetComponent<Transform>();
        recovedTip();
        scene = SceneManager.GetActiveScene().buildIndex;
        starindex = (scene - 1) * 3;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeUIPanel();
        recovedTip();
        if (Tipstar)
        {
            tipTime += Time.deltaTime;
            if (tipTime >= 1)
            {
                tipTime = 0;
                TipIndex++;
                if (TipIndex == 60 || TipIndex == 120 || TipIndex == 180)
                {
                    Shine = true;
                    DisplayTip(TipIndex / 60);
                }
            }
        }
        if (Shine)
        {
            shinetime += Time.deltaTime;
            if(shinetime >= 1)
            {
                shinetime = 0;
                ShineTip();
            }
        }
    }

    //��������UI���
    void ChangeUIPanel()
    {
        // �򿪺ϳɽ���
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UItest.GetChild(1).gameObject.SetActive(false);
            UItest.GetChild(2).gameObject.SetActive(false);
            UItest.GetChild(3).gameObject.SetActive(false);
            UItest.GetChild(0).gameObject.SetActive(!UItest.GetChild(0).gameObject.activeSelf);
        }

        // �����˵�
        if (Input.GetKeyDown(KeyCode.H))
        {
            UItest.GetChild(1).gameObject.SetActive(false);
            UItest.GetChild(0).gameObject.SetActive(false);
            UItest.GetChild(2).gameObject.SetActive(!UItest.GetChild(2).gameObject.activeSelf);
        }
    }

    // �ָ���ʾ��
    public void recovedTip()
    {
        if (UItest.GetChild(4).GetChild(0).gameObject.activeSelf || UItest.GetChild(4).GetChild(1).gameObject.activeSelf 
            || UItest.GetChild(4).GetChild(2).gameObject.activeSelf || UItest.GetChild(4).GetChild(4).gameObject.activeSelf
            || UItest.GetChild(4).GetChild(5).gameObject.activeSelf || UItest.GetChild(4).GetChild(6).gameObject.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                UItest.GetChild(4).GetChild(0).gameObject.SetActive(false);
                UItest.GetChild(4).GetChild(1).gameObject.SetActive(false);
                UItest.GetChild(4).GetChild(2).gameObject.SetActive(false);
                UItest.GetChild(4).GetChild(4).gameObject.SetActive(false);
                UItest.GetChild(4).GetChild(5).gameObject.SetActive(false);
                UItest.GetChild(4).GetChild(6).gameObject.SetActive(false);
                UItest.GetChild(4).gameObject.SetActive(false);
            }
        }
    }
    
    // �������ComposeUI����
    public static void WakeCompose()
    {
        GameObject ComposeUI = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(0).gameObject;
        ComposeUI.SetActive(!ComposeUI.activeSelf);
        GameObject UIinteface = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).gameObject;
        if (!ComposeUI.activeSelf)
        {
            UIinteface.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            UIinteface.transform.GetChild(1).gameObject.SetActive(false);
            UIinteface.transform.GetChild(2).gameObject.SetActive(false);
            UIinteface.transform.GetChild(3).gameObject.SetActive(false);
        }
    }

    // �������SettingUI����
    public static void WakeSetting()
    {
        GameObject SettingUI = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(2).gameObject;
        SettingUI.SetActive(!SettingUI.activeSelf);
    }

    // ������ʾ��
    public static void PopUpTip(int index)
    {
        //float time = 3;
        GameObject TipUI = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(4).gameObject;
        TipUI.SetActive(true);
        //print(TipUI.transform.name);
        print(TipUI.transform.GetChild(index).gameObject.name);
        TipUI.transform.GetChild(index).gameObject.SetActive(true);
    }

    // ��С����
    public static void Opengrocery()
    {
        GameObject UIcontrol = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).gameObject;
        UIcontrol.transform.GetChild(3).gameObject.SetActive(true);
        UIcontrol.transform.GetChild(0).gameObject.SetActive(false);
        UIcontrol.transform.GetChild(1).gameObject.SetActive(false);
        UIcontrol.transform.GetChild(2).gameObject.SetActive(false);
        UIcontrol.transform.GetChild(4).gameObject.SetActive(false);
    }

    // �ر�С����
    public static void CloseGrocery()
    {
        GameObject UIcontrol = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).gameObject;
        UIcontrol.transform.GetChild(3).gameObject.SetActive(false);
        UIcontrol.transform.GetChild(4).gameObject.SetActive(true);
        UIcontrol.transform.GetChild(1).gameObject.SetActive(true);
    }

    // ��ʾ����ʾ��ʾ
    public void DisplayTip(int num)
    {
        Transform tip = UItest.GetChild(4).GetChild(3).transform;
        tip.GetChild(num).gameObject.SetActive(true);
        tip.GetChild(num).gameObject.GetComponent<Text>().text = Tipdialogue[starindex];
        starindex++;
    }

    // ��˸��ʾ��ť
    public void ShineTip()
    {
        Image image = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(5).GetChild(1).gameObject.GetComponent<Image>();
        if (ShineState) image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        else image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);

        ShineState = !ShineState;
    }
}