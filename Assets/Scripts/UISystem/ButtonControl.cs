using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    // �������ComposeUI����
   public void ComposeButton()
    {
        UIcontrol.WakeCompose();
    }

    // ����ر�С����
    public void CloseGrocery()
    {
        UIcontrol.CloseGrocery();
    }

    // ��������ý���
    public void SettingButton()
    {
        UIcontrol.WakeSetting();
    }

    // �������ʾ
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

    // ���ѡ����ȷ��
    public void SelectCorrectAnwser()
    {
        print("ѡ����ȷ");
        Gardener garden = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(0).GetComponent<Gardener>();
        garden.index++;
        garden.gindex = 10;
        garden.answer = true;
        Transform quest = GameObject.FindGameObjectWithTag("uisystem").transform;
        quest.GetChild(0).gameObject.SetActive(true);
        quest.GetChild(1).gameObject.SetActive(false);
    }

    // ���ѡ������
    public void SelectErrorAnwser()
    {
        print("ѡ�����");
        Gardener garden = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(0).GetComponent<Gardener>();
        garden.index++;
        garden.answer = false;
        Transform quest = GameObject.FindGameObjectWithTag("uisystem").transform;
        quest.GetChild(0).gameObject.SetActive(true);
        quest.GetChild(1).gameObject.SetActive(false);
    }

    // ѡ����ȷ·��
    public void SelectCorrectIntersection()
    {
        print("ѡ����ȷ·��");
        Transform Lab = GameObject.FindGameObjectWithTag("Labyrinth").transform;
        LabyrinthTime lab = Lab.gameObject.GetComponent<LabyrinthTime>();
        Mirror mirror = Lab.GetChild(3).gameObject.GetComponent<Mirror>();
        Lab.GetChild(3).gameObject.SetActive(false);
        Lab.GetChild(mirror.LabyrinthIndex).GetChild(4).gameObject.SetActive(true);
        lab.star = true;
        lab.index = 0;
    }

    // ѡ�����·��
    public void SelectErrorIntersection()
    {
        print("ѡ�����·��");
        Transform Lab = GameObject.FindGameObjectWithTag("Labyrinth").transform;
        LabyrinthTime lab = Lab.gameObject.GetComponent<LabyrinthTime>();
        lab.restar = true;
        lab.index = -1;
    }

    // ѡ��ʼ���Թ�
    public void StarLabyrinth()
    {
        Transform quest = GameObject.FindGameObjectWithTag("uisystem").transform;
        quest.GetChild(2).gameObject.SetActive(false);
        GameObject lab = GameObject.FindGameObjectWithTag("Labyrinth").gameObject;
        LabyrinthTime labt = lab.GetComponent<LabyrinthTime>();
        labt.enabled = true;
        lab.transform.GetChild(0).gameObject.SetActive(true);
    }

    // ѡ���ٵȵ�
    public void WaitLabyrinth()
    {
        TilemGuard tilem = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(1).gameObject.GetComponent<TilemGuard>();
        tilem.Labyrinth = false;
        Transform quest = GameObject.FindGameObjectWithTag("uisystem").transform;
        quest.GetChild(2).gameObject.SetActive(false);
        quest.GetChild(0).gameObject.SetActive(true);
    }
}
