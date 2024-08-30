using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCar : MonoBehaviour
{
    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;

    public float speed; 
    public float nextspeed;

    // 是否可以左右、上下移动
    public bool Xaspect;
    public bool Yaspect;

    public Vector2 position;
    Vector3 filxp;
    // true为右、上
    public bool xaspect;
    public bool yaspect;

    private Transform Car;

    // 获取图像渲染器
    private SpriteRenderer image;

    // 是否可以获取汽车尾气
    public static bool get = false;
    public static bool TailGas = false;
    public static bool have = true;

    // Start is called before the first frame update
    void Start()
    {
        Car = GetComponent<Transform>();
        image = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAspect();
        if (get) GetTailGas();
    }

    // 改变小车运动方向
    void ChangeAspect()
    {
        position = new Vector2(Car.position.x, Car.position.y);
        filxp = new Vector3(0.0f, 180.0f, 0.0f); // 转身
        if(Xaspect)
        {
            if (Car.position.x >= xMax)
            {
                xaspect = false;
                position.x -= speed * Time.deltaTime;
                Car.Rotate(filxp);
            }
            else if (Car.position.x <= xMin)
            {
                xaspect = true;
                position.x += speed * Time.deltaTime;
                Car.Rotate(filxp);
            }
            else
            {
                if (xaspect) position.x += speed * Time.deltaTime;
                else position.x -= speed * Time.deltaTime;
            }
        }
        if(Yaspect)
        {
            if (Car.position.y >= yMax)
            {
                yaspect = false;
                position.y -= speed * Time.deltaTime;
            }
            else if (Car.position.y <= yMin)
            {
                yaspect = true;
                position.y += speed * Time.deltaTime;
            }
            else
            {
                if (yaspect) position.y += speed * Time.deltaTime;
                else position.y -= speed * Time.deltaTime;
            }
        }
        Car.position = position;
    }

    // 碰撞后停车
    private void OnCollisionEnter2D(Collision2D collision)
    {
        nextspeed = speed;
        TailGas = true;
        speed = 0;
    }

    // 离开碰撞范围后继续运动
    private void OnCollisionExit2D(Collision2D collision)
    {
        speed = nextspeed;
        TailGas = false;
    }

    // 获取汽车尾气
    private void GetTailGas()
    {
        // 获取玩家背包
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
        for (int i = 0; i < bagList.bagList.Count; i++)
        {
            if (bagList.bagList[i].name == "汽车尾气") get = false;
        }

        if (get)
        {
            addtocomposeui.additem("汽车尾气");
            have = false;
        }
    }
}
