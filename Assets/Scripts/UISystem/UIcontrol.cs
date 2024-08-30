using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    // 获取UI的父元素
    private Transform UItest;
    public float tipTime;
    public bool StarTime = true;
    public int Scerentindex;

    // 提示相关
    public bool Tipstar = true;
    public bool Shine = false;
    public bool ShineState = false;
    int TipIndex = 0;
    int scene;
    int starindex;
    float shinetime;

    // 关卡提示内容
    string[] Tipdialogue = { 
        // 关卡1: 0 1 2
        "汽车尾气中含有一氧化氮、二氧化碳、碳氢化合物等等"
            , "氮氧化合物加上二硫化碳可能有奇妙的反应"
            , "狗吠反应: 二硫化碳+一氧化氮=（点燃）=氮气+一氧化碳+二氧化硫+硫" 

            // 关卡2: 3 4 5
            , "可以用木板作为垫子渡过沼泽"
            , "甘蔗和玉米中含有葡萄糖、蔗糖等糖类物质"
            , "电解饱和的食盐水会生成两种神秘的气体"
            
            // 关卡3: 6 7 8
            , "磷矿石、石英砂和焦炭在很高的温度下可以制取白磷"
            , "山洞里的生石灰加水可以生成一些碱性物质"
            , "碳酸钠和氢氧化钙是烧碱溶液的原料"  

            // 关卡4: 9 10 11
            , "银氨溶液需要用肥料的一水合氨和金属盐合成"
            , "糖类和银氨溶液是制造镜子的主要原料"
            , "葡萄糖加上银氨溶液在高温的情况下可以在玻璃容器上制出镜"}; 


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

    //按键唤醒UI面板
    void ChangeUIPanel()
    {
        // 打开合成界面
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UItest.GetChild(1).gameObject.SetActive(false);
            UItest.GetChild(2).gameObject.SetActive(false);
            UItest.GetChild(3).gameObject.SetActive(false);
            UItest.GetChild(0).gameObject.SetActive(!UItest.GetChild(0).gameObject.activeSelf);
        }

        // 打开主菜单
        if (Input.GetKeyDown(KeyCode.H))
        {
            UItest.GetChild(1).gameObject.SetActive(false);
            UItest.GetChild(0).gameObject.SetActive(false);
            UItest.GetChild(2).gameObject.SetActive(!UItest.GetChild(2).gameObject.activeSelf);
        }
    }

    // 恢复提示框
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
    
    // 点击唤醒ComposeUI界面
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

    // 点击唤醒SettingUI界面
    public static void WakeSetting()
    {
        GameObject SettingUI = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(2).gameObject;
        SettingUI.SetActive(!SettingUI.activeSelf);
    }

    // 弹出提示框
    public static void PopUpTip(int index)
    {
        //float time = 3;
        GameObject TipUI = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(4).gameObject;
        TipUI.SetActive(true);
        //print(TipUI.transform.name);
        print(TipUI.transform.GetChild(index).gameObject.name);
        TipUI.transform.GetChild(index).gameObject.SetActive(true);
    }

    // 打开小卖部
    public static void Opengrocery()
    {
        GameObject UIcontrol = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).gameObject;
        UIcontrol.transform.GetChild(3).gameObject.SetActive(true);
        UIcontrol.transform.GetChild(0).gameObject.SetActive(false);
        UIcontrol.transform.GetChild(1).gameObject.SetActive(false);
        UIcontrol.transform.GetChild(2).gameObject.SetActive(false);
        UIcontrol.transform.GetChild(4).gameObject.SetActive(false);
    }

    // 关闭小卖部
    public static void CloseGrocery()
    {
        GameObject UIcontrol = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).gameObject;
        UIcontrol.transform.GetChild(3).gameObject.SetActive(false);
        UIcontrol.transform.GetChild(4).gameObject.SetActive(true);
        UIcontrol.transform.GetChild(1).gameObject.SetActive(true);
    }

    // 提示框显示提示
    public void DisplayTip(int num)
    {
        Transform tip = UItest.GetChild(4).GetChild(3).transform;
        tip.GetChild(num).gameObject.SetActive(true);
        tip.GetChild(num).gameObject.GetComponent<Text>().text = Tipdialogue[starindex];
        starindex++;
    }

    // 闪烁提示按钮
    public void ShineTip()
    {
        Image image = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(5).GetChild(1).gameObject.GetComponent<Image>();
        if (ShineState) image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        else image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);

        ShineState = !ShineState;
    }
}