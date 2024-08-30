using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthTime : MonoBehaviour
{
    // Start is called before the first frame update
    // ѡ��������ʾʱ��
    public float totaltime = 0;
    public int index = 0;
    // �Ƿ���Կ�ʼ����·�ڶ���
    public bool star = false;
    // �Ƿ���Ҫ���¿�ʼ�Թ���Ϸ
    public bool restar = false;

    // ��ȡ������
    Transform Labyrinth; // �Թ�
    Transform Player; // ���

    // ��ȡ���ӿ��ƽű�
    Mirror mirror;

    void Start()
    {
        // �رնԻ�
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Player.GetChild(0).gameObject.SetActive(false);
        // ���Թ���ͼ�;���ͼƬ
        Labyrinth = GameObject.FindGameObjectWithTag("Labyrinth").transform;
        Labyrinth.GetChild(3).gameObject.SetActive(true);
        Labyrinth.GetChild(4).gameObject.SetActive(true);
        // ��ȡ���ӿ��ƽű�
        mirror = Labyrinth.GetChild(3).gameObject.GetComponent<Mirror>();
    }

    // Update is called once per frame
    void Update()
    {
        // �رս���·�ڶ���
        if (star)
        {
            totaltime += Time.deltaTime;
            if (totaltime >= 1)
            {
                print(index);
                index++;
                totaltime = 0;
                if (index == 2) CloseAnim();
            }
        }

        // ���¿�ʼ���Թ������ر����¿�ʼ��ʾ
        if (restar)
        {
            if (index == -1)
            {
                SelectError();
                index++;
            }
            else
            {
                totaltime += Time.deltaTime;
                if (totaltime >= 1)
                {
                    index++;
                    totaltime = 0;
                    if (index == 1) CloseTip();
                }
            }
        }
    }

    // �رն���
    void CloseAnim()
    {
        // ���غ󣬽���������鶯��
        if (mirror.LabyrinthIndex == 2)
        {
            // �رյ�ǰ��ͼ
            Labyrinth.GetChild(3).gameObject.SetActive(true);
            Labyrinth.GetChild(4).gameObject.SetActive(true);
            Labyrinth.GetChild(mirror.LabyrinthIndex).gameObject.SetActive(false);
            // ������������
            GameObject time = GameObject.FindGameObjectWithTag("Time").gameObject;
            time.transform.GetChild(2).gameObject.SetActive(true);
        }
        // ѡ����ȷ·�ں󣬹رս���·�ڶ������л��Թ���ͼ
        else
        {
            // �رյ�ǰ��ͼ
            Labyrinth.GetChild(mirror.LabyrinthIndex).GetChild(3).gameObject.SetActive(false);
            Labyrinth.GetChild(mirror.LabyrinthIndex).GetChild(4).gameObject.SetActive(false);
            Labyrinth.GetChild(mirror.LabyrinthIndex).gameObject.SetActive(false);
            // ���µ�ͼ
            mirror.LabyrinthIndex++;
            print("LabyrinthIndex Change: " + mirror.LabyrinthIndex);
            Labyrinth.GetChild(mirror.LabyrinthIndex).gameObject.SetActive(true);
            Labyrinth.GetChild(3).gameObject.SetActive(true);
            star = false;
        }
    }

    // ѡ��������¿�ʼ
    void SelectError()
    {
        // �رյ�ǰ��ͼ
        Labyrinth.GetChild(mirror.LabyrinthIndex).gameObject.SetActive(false);
        // �򿪳�ʼ��ͼ
        mirror.LabyrinthIndex = 0;
        Labyrinth.GetChild(mirror.LabyrinthIndex).gameObject.SetActive(true);
        Labyrinth.GetChild(3).gameObject.SetActive(true);
        star = false;
        // ��ѡ�������ʾ
        PopTip();
    }

    // ������ʾ
    void PopTip()
    {
        Labyrinth.GetChild(6).gameObject.SetActive(true);
    }

    // �ر���ʾ
    void CloseTip()
    {
        print("CloseTip");
        Labyrinth.GetChild(6).gameObject.SetActive(false);
        restar = false;
    }    
}
