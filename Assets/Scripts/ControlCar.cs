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

    // �Ƿ�������ҡ������ƶ�
    public bool Xaspect;
    public bool Yaspect;

    public Vector2 position;
    Vector3 filxp;
    // trueΪ�ҡ���
    public bool xaspect;
    public bool yaspect;

    private Transform Car;

    // ��ȡͼ����Ⱦ��
    private SpriteRenderer image;

    // �Ƿ���Ի�ȡ����β��
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

    // �ı�С���˶�����
    void ChangeAspect()
    {
        position = new Vector2(Car.position.x, Car.position.y);
        filxp = new Vector3(0.0f, 180.0f, 0.0f); // ת��
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

    // ��ײ��ͣ��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        nextspeed = speed;
        TailGas = true;
        speed = 0;
    }

    // �뿪��ײ��Χ������˶�
    private void OnCollisionExit2D(Collision2D collision)
    {
        speed = nextspeed;
        TailGas = false;
    }

    // ��ȡ����β��
    private void GetTailGas()
    {
        // ��ȡ��ұ���
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
        for (int i = 0; i < bagList.bagList.Count; i++)
        {
            if (bagList.bagList[i].name == "����β��") get = false;
        }

        if (get)
        {
            addtocomposeui.additem("����β��");
            have = false;
        }
    }
}
