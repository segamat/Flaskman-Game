using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationControl : MonoBehaviour
{
    // ��ȡ��Ҹ�����
    static Transform Player;
    // ��ȡNPC������
    static Transform NPC;

    public static bool npc = false;
    // ����ʱ��
    private static bool star = false;
    private static float totalTime = 0;

    // ��ȡ��ǰ�����±�
    public static int scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        print(scene);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    // ����̽�ռҵĶ���
    public static void Give(int give,int index)
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        NPC = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(index).transform;
        
        // �ƶ�������Ի�λ��
        Player.position = NPC.GetChild(3).transform.position;
        NPC.GetChild(0).gameObject.SetActive(true);
        // NPC��
        if (give == 1)
        {
            print("��");
            NPC.GetChild(2).gameObject.SetActive(true);
        }
        // ��
        else
        {
            print("��");
            NPC.GetChild(1).gameObject.SetActive(true);
        }
    }
}
