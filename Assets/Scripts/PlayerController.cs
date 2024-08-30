using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // 获取父物体
    public Transform Player; // 玩家
    public Transform target; // 搅拌棒跟随对象
    public float speed = 5f; // 玩家移动速度

    public int fund = 10; // 玩家资金
    int scene;  // 场景下标

    private float time = 0;  // 对话时间
    private bool star = false;  // 是否可以开始对话

    //获取加载后的预制体
    private GameObject UItest;
    // 控制UI显示
    private bool uicontrol = true;
    // 动画组件
    private Animator animator;
    private bool animsapect = true;

    // 获取摄像头
    private Camera mainCamera;

    Rigidbody2D pbody;//刚体组件

    // 碰撞物品名称
    string[] ItemName = {
        // 关卡1： 0 1
        "喷水的花", "果子",
        // 关卡2： 2 3 4 5 6
        "marsh", "lake", "yinshi", "wood", "lingjian",
        // 关卡3：7 8 9 10 11 12 13
        "pack", "车前草", "lin", "quaze", "tan", "hui", "tie",
        // 关卡4： 14 15 16 17 18 19 20
        "镜子", "feiliao", "铃兰", "望鹤兰", "尸香魔芋", "xiao", "甘蔗", "玉米", "向日葵", "百合1", "玫瑰1", "兰花" };

    // 碰撞提示内容
    string[] playdialogue = { 
        // 关卡1: 0 1
        "好漂亮的花！啊！怎么会喷水。",
        "好臭！这果子怎么踩坏了有臭味",
        // 关卡2: 2 3 4 5 6
        "这沼泽过不去，得找个东西垫一下。" ,
        "这好像是盐湖。呀，好咸！",
        "这就是萤石好漂亮呀",
        "一些木材，应该有一些用处", 
        "找到了一些钟表的零件，快收起来！", 
        // 关卡3: 7 8 9 10 11 12  
        "一个小包裹，应该是旅行家的",
        "宽叶，长柄，这就是我要找的车前草",
        "一点矿石，好像是磷矿石",
        "一点石英砂，应该是有用的",
        "黑乎乎的，好像是焦炭", 
        "嘿咻嘿咻，找到了一些生石灰",
        "红红的，应该是赤铁矿，不知道有没有用",
        // 关卡4： 14 15 16 17 18 19 20
        "一个空的玻璃盘，也许会有用的",
        "咦，一些花田肥料，也许会有用的",
        "花朵像一些坩埚，不知道是不是奇特的花",
        "花朵像一只仙鹤，不知道是不是奇特的花",
        "好奇特的香味，怎么有点晕，不知道是不是奇特的花",
        "消炎药！也许会有用的",
        "甜甜的甘蔗，真好吃，好像有糖在里面",
        "香甜的玉米，含有好多糖分",
        "好香的花，不知道是不是奇特的花" };

    // Start is called before the first frame update
    void Start()
    {
        pbody = GetComponent<Rigidbody2D>();
        Player = GetComponent<Transform>();
        animator = Player.GetChild(1).GetComponent<Animator>();
        scene = SceneManager.GetActiveScene().buildIndex;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAnim();
        Move();
        UIControl();

        // 对话
        if (star) time += Time.deltaTime;
        if (time >= 1)
        {
            CloseDialogue();
        }

        // 识别是否处于开灯状态
        if (scene == 3) OpenLight();
    }

    // 激活UI控制界面脚本
    public static void WakeUI()
    {
        //获取预制体
        GameObject UItestPrefab;
        //获取UI预制体
        UItestPrefab = Resources.Load<GameObject>("UI-preform/interfaceUI");
        // 添加UI预制体
        Instantiate(UItestPrefab);
        addtobag.RefreshItem();  // 刷新物品栏
    }

    // 角色移动
    void Move()
    {
        float movex = Input.GetAxisRaw("Horizontal");//控制水平移动方向  A：-1 D：1 0
        float movey = Input.GetAxisRaw("Vertical");//控制垂直移动方向  W：1  S：-1 0

        //键盘控制移动
        Vector2 position = pbody.position;
        position.x += movex * speed * Time.deltaTime;
        position.y += movey * speed * Time.deltaTime;
        pbody.MovePosition(position);
    }
 
    // 走路动画控制
    void ChangeAnim()
    {
        Vector3 Right = new Vector3(0, 0, 0); // 左转
        Vector3 Left = new Vector3(0, 180, 0); // 右转
        // 获得键盘输入, 更新动画
        // 上 或 下
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (animsapect)
            {
                animator.SetBool("righting", true);
                animator.SetBool("lefting", false);
                animator.SetBool("right", false);
                animator.SetBool("left", false);
                Player.localEulerAngles = Right;
            }
            else
            {
                animator.SetBool("righting", false);
                animator.SetBool("lefting", true);
                animator.SetBool("right", false);
                animator.SetBool("left", false);
                Player.localEulerAngles = Left;
            }
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (animsapect)
            {
                animator.SetBool("righting", false);
                animator.SetBool("lefting", false);
                animator.SetBool("right", true);
                animator.SetBool("left", false);
                Player.localEulerAngles = Right;
            }
            else
            {
                animator.SetBool("righting", false);
                animator.SetBool("lefting", false);
                animator.SetBool("right", false);
                animator.SetBool("left", true);
                Player.localEulerAngles = Left;
            }
        }
        // 左
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animsapect = false;
            animator.SetBool("right", false);
            animator.SetBool("left", false);
            animator.SetBool("lefting", true);
            animator.SetBool("righting", false);
            Player.localEulerAngles = Left;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) )
        {
            animator.SetBool("right", false);
            animator.SetBool("left", true);
            animator.SetBool("lefting", false);
            animator.SetBool("righting", false);
            Player.localEulerAngles = Left;
        }
        // 右
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) )
        {
            animsapect = true;
            animator.SetBool("right", false);
            animator.SetBool("left", false);
            animator.SetBool("lefting", false);
            animator.SetBool("righting", true);
            Player.localEulerAngles = Right;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow) )
        {
            animator.SetBool("right", true);
            animator.SetBool("left", false);
            animator.SetBool("lefting", false);
            animator.SetBool("righting", false);
            Player.localEulerAngles = Right;
        }
    }

    // 开灯
    void OpenLight()
    {
        // 获取天花板控制脚本
        ForeGrond fore = GameObject.Find("Grid").transform.GetChild(2).gameObject.GetComponent<ForeGrond>();
        // 开灯
        if (fore.lightuse)
        {
            Player.GetChild(1).GetChild(8).GetChild(1).GetChild(0).gameObject.SetActive(true);
        }
        // 关灯
        else
        {
            Player.GetChild(1).GetChild(8).GetChild(1).GetChild(0).gameObject.SetActive(false);
        }
    }

    // 控制UI系统的关闭
    void UIControl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uicontrol = false;
            UItest.transform.GetChild(0).GetChild(0).gameObject.SetActive(uicontrol);
            UItest.transform.GetChild(0).GetChild(1).gameObject.SetActive(uicontrol);
            UItest.transform.GetChild(0).GetChild(2).gameObject.SetActive(uicontrol);
        }
    }

    // 识别碰撞对象
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        for(int i = 0; i < ItemName.Length; i++)
        {
            // 匹配配置对象和提示话语
            if (collision.gameObject.name == ItemName[i] && i <= 21) dialogue(i);
            // 在第四关拾取普通的花
            else if (collision.gameObject.name == ItemName[i]) dialogue(22);
        }
    }

    // 弹出对话框
    void dialogue(int index)
    {
        print("弹出提示");
        Player.GetChild(0).gameObject.SetActive(true);
        Player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = playdialogue[index];
        star = true;
    }

    // 关闭对话框
    void CloseDialogue()
    {
        print("关闭提示");
        Player.GetChild(0).gameObject.SetActive(false);
        time = 0;
        star = false;
    }
}
