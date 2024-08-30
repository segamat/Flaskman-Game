using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // ��ȡ������
    public Transform Player; // ���
    public Transform target; // ������������
    public float speed = 5f; // ����ƶ��ٶ�

    public int fund = 10; // ����ʽ�
    int scene;  // �����±�

    private float time = 0;  // �Ի�ʱ��
    private bool star = false;  // �Ƿ���Կ�ʼ�Ի�

    //��ȡ���غ��Ԥ����
    private GameObject UItest;
    // ����UI��ʾ
    private bool uicontrol = true;
    // �������
    private Animator animator;
    private bool animsapect = true;

    // ��ȡ����ͷ
    private Camera mainCamera;

    Rigidbody2D pbody;//�������

    // ��ײ��Ʒ����
    string[] ItemName = {
        // �ؿ�1�� 0 1
        "��ˮ�Ļ�", "����",
        // �ؿ�2�� 2 3 4 5 6
        "marsh", "lake", "yinshi", "wood", "lingjian",
        // �ؿ�3��7 8 9 10 11 12 13
        "pack", "��ǰ��", "lin", "quaze", "tan", "hui", "tie",
        // �ؿ�4�� 14 15 16 17 18 19 20
        "����", "feiliao", "����", "������", "ʬ��ħ��", "xiao", "����", "����", "���տ�", "�ٺ�1", "õ��1", "����" };

    // ��ײ��ʾ����
    string[] playdialogue = { 
        // �ؿ�1: 0 1
        "��Ư���Ļ���������ô����ˮ��",
        "�ó����������ô�Ȼ����г�ζ",
        // �ؿ�2: 2 3 4 5 6
        "���������ȥ�����Ҹ�������һ�¡�" ,
        "��������κ���ѽ�����̣�",
        "�����өʯ��Ư��ѽ",
        "һЩľ�ģ�Ӧ����һЩ�ô�", 
        "�ҵ���һЩ�ӱ�����������������", 
        // �ؿ�3: 7 8 9 10 11 12  
        "һ��С������Ӧ�������мҵ�",
        "��Ҷ���������������Ҫ�ҵĳ�ǰ��",
        "һ���ʯ���������׿�ʯ",
        "һ��ʯӢɰ��Ӧ�������õ�",
        "�ں����ģ������ǽ�̿", 
        "���ݺ��ݣ��ҵ���һЩ��ʯ��",
        "���ģ�Ӧ���ǳ����󣬲�֪����û����",
        // �ؿ�4�� 14 15 16 17 18 19 20
        "һ���յĲ����̣�Ҳ������õ�",
        "�ף�һЩ������ϣ�Ҳ������õ�",
        "������һЩ��������֪���ǲ������صĻ�",
        "������һֻ�ɺף���֪���ǲ������صĻ�",
        "�����ص���ζ����ô�е��Σ���֪���ǲ������صĻ�",
        "����ҩ��Ҳ������õ�",
        "����ĸ��ᣬ��óԣ���������������",
        "��������ף����кö��Ƿ�",
        "����Ļ�����֪���ǲ������صĻ�" };

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

        // �Ի�
        if (star) time += Time.deltaTime;
        if (time >= 1)
        {
            CloseDialogue();
        }

        // ʶ���Ƿ��ڿ���״̬
        if (scene == 3) OpenLight();
    }

    // ����UI���ƽ���ű�
    public static void WakeUI()
    {
        //��ȡԤ����
        GameObject UItestPrefab;
        //��ȡUIԤ����
        UItestPrefab = Resources.Load<GameObject>("UI-preform/interfaceUI");
        // ���UIԤ����
        Instantiate(UItestPrefab);
        addtobag.RefreshItem();  // ˢ����Ʒ��
    }

    // ��ɫ�ƶ�
    void Move()
    {
        float movex = Input.GetAxisRaw("Horizontal");//����ˮƽ�ƶ�����  A��-1 D��1 0
        float movey = Input.GetAxisRaw("Vertical");//���ƴ�ֱ�ƶ�����  W��1  S��-1 0

        //���̿����ƶ�
        Vector2 position = pbody.position;
        position.x += movex * speed * Time.deltaTime;
        position.y += movey * speed * Time.deltaTime;
        pbody.MovePosition(position);
    }
 
    // ��·��������
    void ChangeAnim()
    {
        Vector3 Right = new Vector3(0, 0, 0); // ��ת
        Vector3 Left = new Vector3(0, 180, 0); // ��ת
        // ��ü�������, ���¶���
        // �� �� ��
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
        // ��
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
        // ��
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

    // ����
    void OpenLight()
    {
        // ��ȡ�컨����ƽű�
        ForeGrond fore = GameObject.Find("Grid").transform.GetChild(2).gameObject.GetComponent<ForeGrond>();
        // ����
        if (fore.lightuse)
        {
            Player.GetChild(1).GetChild(8).GetChild(1).GetChild(0).gameObject.SetActive(true);
        }
        // �ص�
        else
        {
            Player.GetChild(1).GetChild(8).GetChild(1).GetChild(0).gameObject.SetActive(false);
        }
    }

    // ����UIϵͳ�Ĺر�
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

    // ʶ����ײ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        for(int i = 0; i < ItemName.Length; i++)
        {
            // ƥ�����ö������ʾ����
            if (collision.gameObject.name == ItemName[i] && i <= 21) dialogue(i);
            // �ڵ��Ĺ�ʰȡ��ͨ�Ļ�
            else if (collision.gameObject.name == ItemName[i]) dialogue(22);
        }
    }

    // �����Ի���
    void dialogue(int index)
    {
        print("������ʾ");
        Player.GetChild(0).gameObject.SetActive(true);
        Player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = playdialogue[index];
        star = true;
    }

    // �رնԻ���
    void CloseDialogue()
    {
        print("�ر���ʾ");
        Player.GetChild(0).gameObject.SetActive(false);
        time = 0;
        star = false;
    }
}
