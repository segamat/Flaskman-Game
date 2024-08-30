using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthTime : MonoBehaviour
{
    // Start is called before the first frame update
    // 选择错误后提示时间
    public float totaltime = 0;
    public int index = 0;
    // 是否可以开始进入路口动画
    public bool star = false;
    // 是否需要重新开始迷宫游戏
    public bool restar = false;

    // 获取父物体
    Transform Labyrinth; // 迷宫
    Transform Player; // 玩家

    // 获取镜子控制脚本
    Mirror mirror;

    void Start()
    {
        // 关闭对话
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Player.GetChild(0).gameObject.SetActive(false);
        // 打开迷宫地图和镜子图片
        Labyrinth = GameObject.FindGameObjectWithTag("Labyrinth").transform;
        Labyrinth.GetChild(3).gameObject.SetActive(true);
        Labyrinth.GetChild(4).gameObject.SetActive(true);
        // 获取镜子控制脚本
        mirror = Labyrinth.GetChild(3).gameObject.GetComponent<Mirror>();
    }

    // Update is called once per frame
    void Update()
    {
        // 关闭进入路口动画
        if (star)
        {
            totaltime += Time.deltaTime;
            if (totaltime >= 1)
            {
                print(index);
                index++;
                totaltime = 0;
                if (index == 2) CloseAnim();
            }
        }

        // 重新开始闯迷宫，并关闭重新开始提示
        if (restar)
        {
            if (index == -1)
            {
                SelectError();
                index++;
            }
            else
            {
                totaltime += Time.deltaTime;
                if (totaltime >= 1)
                {
                    index++;
                    totaltime = 0;
                    if (index == 1) CloseTip();
                }
            }
        }
    }

    // 关闭动画
    void CloseAnim()
    {
        // 闯关后，进入结束剧情动画
        if (mirror.LabyrinthIndex == 2)
        {
            // 关闭当前地图
            Labyrinth.GetChild(3).gameObject.SetActive(true);
            Labyrinth.GetChild(4).gameObject.SetActive(true);
            Labyrinth.GetChild(mirror.LabyrinthIndex).gameObject.SetActive(false);
            // 开启结束剧情
            GameObject time = GameObject.FindGameObjectWithTag("Time").gameObject;
            time.transform.GetChild(2).gameObject.SetActive(true);
        }
        // 选择正确路口后，关闭进入路口动画，切换迷宫地图
        else
        {
            // 关闭当前地图
            Labyrinth.GetChild(mirror.LabyrinthIndex).GetChild(3).gameObject.SetActive(false);
            Labyrinth.GetChild(mirror.LabyrinthIndex).GetChild(4).gameObject.SetActive(false);
            Labyrinth.GetChild(mirror.LabyrinthIndex).gameObject.SetActive(false);
            // 打开新地图
            mirror.LabyrinthIndex++;
            print("LabyrinthIndex Change: " + mirror.LabyrinthIndex);
            Labyrinth.GetChild(mirror.LabyrinthIndex).gameObject.SetActive(true);
            Labyrinth.GetChild(3).gameObject.SetActive(true);
            star = false;
        }
    }

    // 选择错误重新开始
    void SelectError()
    {
        // 关闭当前地图
        Labyrinth.GetChild(mirror.LabyrinthIndex).gameObject.SetActive(false);
        // 打开初始地图
        mirror.LabyrinthIndex = 0;
        Labyrinth.GetChild(mirror.LabyrinthIndex).gameObject.SetActive(true);
        Labyrinth.GetChild(3).gameObject.SetActive(true);
        star = false;
        // 打开选择错误提示
        PopTip();
    }

    // 弹出提示
    void PopTip()
    {
        Labyrinth.GetChild(6).gameObject.SetActive(true);
    }

    // 关闭提示
    void CloseTip()
    {
        print("CloseTip");
        Labyrinth.GetChild(6).gameObject.SetActive(false);
        restar = false;
    }    
}
