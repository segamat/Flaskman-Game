using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class ForeGrond : MonoBehaviour
{
    // 获取天花板控制组件
    Tilemap tile;

    // 获取父物体
    Transform door;
    Transform Player;

    // 是否有使用灯
    public bool lightuse = false;
    // 获取场景下标
    int scene;
    // 提示内容
    string dia = "好黑呀，没有灯进不去的。";
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
        // 识别使用灯的状态
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

    // 碰撞时使用灯，使室内可见
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

    // 处于碰撞状态时使用灯，使室内可见
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

    // 离开碰撞状态时，使室内不可见
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
