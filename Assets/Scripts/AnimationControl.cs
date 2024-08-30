using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationControl : MonoBehaviour
{
    // 获取玩家父物体
    static Transform Player;
    // 获取NPC父物体
    static Transform NPC;

    public static bool npc = false;
    // 动画时间
    private static bool star = false;
    private static float totalTime = 0;

    // 获取当前场景下标
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
    
    // 调用探险家的动画
    public static void Give(int give,int index)
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        NPC = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(index).transform;
        
        // 移动玩家至对话位置
        Player.position = NPC.GetChild(3).transform.position;
        NPC.GetChild(0).gameObject.SetActive(true);
        // NPC收
        if (give == 1)
        {
            print("收");
            NPC.GetChild(2).gameObject.SetActive(true);
        }
        // 给
        else
        {
            print("给");
            NPC.GetChild(1).gameObject.SetActive(true);
        }
    }
}
