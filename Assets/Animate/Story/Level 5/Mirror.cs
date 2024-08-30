using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mirror : MonoBehaviour
{
    // Start is called before the first frame update
    // 获取玩家父物体
    private Transform Player;
    Animator playeranim;

    // 获取守卫父物体
    Transform NPC;

    // 获取UI界面
    private Transform UIinfer;

    // 获取迷宫父物体
    private Transform Labyrinth;

    // 镜子
    private Transform mirror;
    Sprite image;
    string[] mirrorname = { "镜子1", "镜子2" };
    public float speed = 5f;//移动速度

    // 切换迷宫地图
    public int LabyrinthIndex = 0;

    // 闪烁时间
    bool star = false;
    bool shine = true;
    float shinetime = 0;

    void Start()
    {
        image = Resources.Load<Sprite>("mirror/" + mirrorname[0]);

        //
        mirror = GameObject.FindGameObjectWithTag("Labyrinth").transform;
        mirror.GetChild(3).gameObject.GetComponent<Image>().sprite = image;

        // 失活角色脚本
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerController playerController = Player.transform.GetComponent<PlayerController>();
        playerController.enabled = false;

        // 失活守卫脚本
        NPC = GameObject.FindGameObjectWithTag("NPC").transform;
        NPC.GetChild(0).gameObject.SetActive(false);
        NPC.GetChild(1).gameObject.SetActive(false);

        // 消失UI界面
        //UIinfer = GameObject.FindGameObjectWithTag("UIsystem").transform;
        //Destroy(UIinfer);

        // 显示迷宫
        Labyrinth = GameObject.FindGameObjectWithTag("Labyrinth").transform;
        Labyrinth.GetChild(LabyrinthIndex).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        MoveMirror();
        if (star)
        {
            shinetime += Time.deltaTime;
            if (shinetime >= 1)
            {
                shinetime = 0;
                ClueAnim();
            }
        }
    }

    // 碰撞路口
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Labyrinth: " + LabyrinthIndex + " " + collision.gameObject.name);
        ChangeImage(1);
        mirror.GetChild(LabyrinthIndex).GetChild(3).gameObject.SetActive(true);
        if (!star) star = true;
    }

    // 离开路口
    private void OnTriggerExit2D(Collider2D collision)
    {
        ChangeImage(0);
    }

    // 移动镜子
    void MoveMirror()
    {
        float movex = Input.GetAxisRaw("Horizontal");//控制水平移动方向  A：-1 D：1 0

        //键盘控制移动
        Vector2 position = mirror.GetChild(3).transform.position;
        position.x += movex * speed * Time.deltaTime;
        mirror.GetChild(3).transform.position = position;
    }

    // 切换镜子图片
    void ChangeImage(int change)
    {
        image = Resources.Load<Sprite>("mirror/" + mirrorname[change]);
        mirror.GetChild(3).GetComponent<Image>().sprite = image;
    }

    // 显示指示动画
    void ClueAnim()
    {
        GameObject clue = mirror.GetChild(LabyrinthIndex).GetChild(3).gameObject;
        Image image = clue.GetComponent<Image>();
        if (shine) image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
        else image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);

        shine = !shine;
    }
}
