using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mirror : MonoBehaviour
{
    // Start is called before the first frame update
    // ��ȡ��Ҹ�����
    private Transform Player;
    Animator playeranim;

    // ��ȡ����������
    Transform NPC;

    // ��ȡUI����
    private Transform UIinfer;

    // ��ȡ�Թ�������
    private Transform Labyrinth;

    // ����
    private Transform mirror;
    Sprite image;
    string[] mirrorname = { "����1", "����2" };
    public float speed = 5f;//�ƶ��ٶ�

    // �л��Թ���ͼ
    public int LabyrinthIndex = 0;

    // ��˸ʱ��
    bool star = false;
    bool shine = true;
    float shinetime = 0;

    void Start()
    {
        image = Resources.Load<Sprite>("mirror/" + mirrorname[0]);

        //
        mirror = GameObject.FindGameObjectWithTag("Labyrinth").transform;
        mirror.GetChild(3).gameObject.GetComponent<Image>().sprite = image;

        // ʧ���ɫ�ű�
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerController playerController = Player.transform.GetComponent<PlayerController>();
        playerController.enabled = false;

        // ʧ�������ű�
        NPC = GameObject.FindGameObjectWithTag("NPC").transform;
        NPC.GetChild(0).gameObject.SetActive(false);
        NPC.GetChild(1).gameObject.SetActive(false);

        // ��ʧUI����
        //UIinfer = GameObject.FindGameObjectWithTag("UIsystem").transform;
        //Destroy(UIinfer);

        // ��ʾ�Թ�
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

    // ��ײ·��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Labyrinth: " + LabyrinthIndex + " " + collision.gameObject.name);
        ChangeImage(1);
        mirror.GetChild(LabyrinthIndex).GetChild(3).gameObject.SetActive(true);
        if (!star) star = true;
    }

    // �뿪·��
    private void OnTriggerExit2D(Collider2D collision)
    {
        ChangeImage(0);
    }

    // �ƶ�����
    void MoveMirror()
    {
        float movex = Input.GetAxisRaw("Horizontal");//����ˮƽ�ƶ�����  A��-1 D��1 0

        //���̿����ƶ�
        Vector2 position = mirror.GetChild(3).transform.position;
        position.x += movex * speed * Time.deltaTime;
        mirror.GetChild(3).transform.position = position;
    }

    // �л�����ͼƬ
    void ChangeImage(int change)
    {
        image = Resources.Load<Sprite>("mirror/" + mirrorname[change]);
        mirror.GetChild(3).GetComponent<Image>().sprite = image;
    }

    // ��ʾָʾ����
    void ClueAnim()
    {
        GameObject clue = mirror.GetChild(LabyrinthIndex).GetChild(3).gameObject;
        Image image = clue.GetComponent<Image>();
        if (shine) image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
        else image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);

        shine = !shine;
    }
}
