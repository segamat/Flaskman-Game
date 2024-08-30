using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    // 点击唤醒ComposeUI界面
   public void ComposeButton()
    {
        UIcontrol.WakeCompose();
    }

    // 点击关闭小卖部
    public void CloseGrocery()
    {
        UIcontrol.CloseGrocery();
    }

    // 点击打开设置界面
    public void SettingButton()
    {
        UIcontrol.WakeSetting();
    }

    // 点击打开提示
    public void TipButton()
    {
        GameObject UIinterfact = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).GetChild(4).gameObject;
        UIinterfact.SetActive(true);
        UIinterfact.transform.GetChild(3).gameObject.SetActive(!UIinterfact.transform.GetChild(3).gameObject.activeSelf);
        UIcontrol uicon = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).gameObject.GetComponent<UIcontrol>();
        if (uicon.Shine) uicon.Shine = false;
        if (uicon.ShineState) uicon.ShineTip();
        uicon.recovedTip();
    }

    // 点击选择正确答案
    public void SelectCorrectAnwser()
    {
        print("选择正确");
        Gardener garden = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(0).GetComponent<Gardener>();
        garden.index++;
        garden.gindex = 10;
        garden.answer = true;
        Transform quest = GameObject.FindGameObjectWithTag("uisystem").transform;
        quest.GetChild(0).gameObject.SetActive(true);
        quest.GetChild(1).gameObject.SetActive(false);
    }

    // 点击选择错误答案
    public void SelectErrorAnwser()
    {
        print("选择错误");
        Gardener garden = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(0).GetComponent<Gardener>();
        garden.index++;
        garden.answer = false;
        Transform quest = GameObject.FindGameObjectWithTag("uisystem").transform;
        quest.GetChild(0).gameObject.SetActive(true);
        quest.GetChild(1).gameObject.SetActive(false);
    }

    // 选择正确路口
    public void SelectCorrectIntersection()
    {
        print("选择正确路口");
        Transform Lab = GameObject.FindGameObjectWithTag("Labyrinth").transform;
        LabyrinthTime lab = Lab.gameObject.GetComponent<LabyrinthTime>();
        Mirror mirror = Lab.GetChild(3).gameObject.GetComponent<Mirror>();
        Lab.GetChild(3).gameObject.SetActive(false);
        Lab.GetChild(mirror.LabyrinthIndex).GetChild(4).gameObject.SetActive(true);
        lab.star = true;
        lab.index = 0;
    }

    // 选择错误路口
    public void SelectErrorIntersection()
    {
        print("选择错误路口");
        Transform Lab = GameObject.FindGameObjectWithTag("Labyrinth").transform;
        LabyrinthTime lab = Lab.gameObject.GetComponent<LabyrinthTime>();
        lab.restar = true;
        lab.index = -1;
    }

    // 选择开始闯迷宫
    public void StarLabyrinth()
    {
        Transform quest = GameObject.FindGameObjectWithTag("uisystem").transform;
        quest.GetChild(2).gameObject.SetActive(false);
        GameObject lab = GameObject.FindGameObjectWithTag("Labyrinth").gameObject;
        LabyrinthTime labt = lab.GetComponent<LabyrinthTime>();
        labt.enabled = true;
        lab.transform.GetChild(0).gameObject.SetActive(true);
    }

    // 选择再等等
    public void WaitLabyrinth()
    {
        TilemGuard tilem = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<TilemGuard>();
        tilem.Labyrinth = false;
        Transform quest = GameObject.FindGameObjectWithTag("uisystem").transform;
        quest.GetChild(2).gameObject.SetActive(false);
        quest.GetChild(0).gameObject.SetActive(true);
    }
}
