using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class ForeGrond : MonoBehaviour
{
    // ��ȡ�컨��������
    Tilemap tile;

    // ��ȡ������
    Transform door;
    Transform Player;

    // �Ƿ���ʹ�õ�
    public bool lightuse = false;
    // ��ȡ�����±�
    int scene;
    // ��ʾ����
    string dia = "�ú�ѽ��û�еƽ���ȥ�ġ�";
    // Start is called before the first frame update
    void Start()
    {
        tile = GetComponent<Tilemap>();
        scene = SceneManager.GetActiveScene().buildIndex;
        door = GameObject.Find("Grid").transform.GetChild(2).transform;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // ʶ��ʹ�õƵ�״̬
        if(scene == 3)
        {
            if (lightuse)
            {
                door.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                door.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    // ��ײʱʹ�õƣ�ʹ���ڿɼ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (scene == 3)
        {
            if (lightuse && collision.gameObject.name == "Player")
            {
                tile.color = new Color(tile.color.r, tile.color.g, tile.color.b, 0.1f);
            }
            else
            {
                tile.color = new Color(tile.color.r, tile.color.g, tile.color.b, 1f);
                Player.GetChild(0).gameObject.SetActive(true);
                Player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = dia;
            }
        }
        else if (collision.gameObject.name == "Player")
        {
            tile.color = new Color(tile.color.r, tile.color.g, tile.color.b, 0.1f);
        }
    }

    // ������ײ״̬ʱʹ�õƣ�ʹ���ڿɼ�
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (scene == 3)
        {
            if (lightuse && collision.gameObject.name == "Player")
            {
                tile.color = new Color(tile.color.r, tile.color.g, tile.color.b, 0.1f);
            }
            else
            {
                tile.color = new Color(tile.color.r, tile.color.g, tile.color.b, 1f);
                Player.GetChild(0).gameObject.SetActive(true);
                Player.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = dia;
            }
        }
    }

    // �뿪��ײ״̬ʱ��ʹ���ڲ��ɼ�
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            tile.color = new Color(tile.color.r, tile.color.g, tile.color.b, 1f);
            Player.GetChild(0).gameObject.SetActive(false);
            lightuse = false;
        }
    }
}
