using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level5Dialogue2 : MonoBehaviour
{
    // Start is called before the first frame update
    Animator playeranim;

    // ��ȡ��Ҹ�����
    private Transform Player;
    private Transform time;

    // �೤ʱ�䣬�任һ���ı�
    private float dialogueChangeTime = 0;

    // ��ҶԻ�������
    private string[] Dialogue = { "�Ҵ����Թ�����"
            , "ʥ�����������������Ҳ�����"
            , "������ˣ��Ҵ������뿪���������ѣ����ڼ������ˣ����������˷ܲ��ѣ�"
            , "�ܵ�����˵������һ��������С��ƿ��Ϊʲô���������أ�"
            , "�ҳ羴������ˣ������Ϊ�����µ�����������ѧ֪ʶ��"
            , "������ѧ֪ʶ�ɲ����ɣ��Ǹ���"
            , "�Ҳ��£���һ������ѧ��ȥ�ģ�"
            , "�����ɼε�С���ѣ��Ǳ������Կ��ɣ��߰ɡ�"};

    // �±�
    private int index = 0;
    private int pindex = 1;

    // Start is called before the first frame update
    void Start()
    {
        // ʧ���ɫ�ű�
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();
        playerController.enabled = false;

        // �л���ͷ
        time = GameObject.FindGameObjectWithTag("Time").transform;
        ChangeCamera.ChangeFollow();

        // 
        time.GetChild(0).gameObject.SetActive(true);
        time.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = Dialogue[0];

        //
        LabyrinthTime labt = GameObject.FindGameObjectWithTag("Labyrinth").gameObject.GetComponent<LabyrinthTime>();
        labt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        dialogueChangeTime += Time.deltaTime;
        if (dialogueChangeTime >= 1)
        {
            dialogueChangeTime = 0;
            index++;
            select(index);
        }
    }

    // 
    void select(int index)
    {
        print(index);
        if (index >= 2 && index <= 8)
        {
            ChangDialogue();
        }
        if (index == 10)
        {
            Close();
        }
    }

    // ���ƶԻ���
    void ChangDialogue()
    {
        print(index + "  " + pindex);
        time.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = Dialogue[pindex];
        pindex++;
    }

    // �رնԻ���
    void Close()
    {
        // ���س����±�
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
