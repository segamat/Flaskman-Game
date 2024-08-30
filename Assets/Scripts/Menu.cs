using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // 主菜单功能
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 开始游戏
    public void StartGame()
    {
        // 加载场景下标
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // 清空玩家背包
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
        int num = bagList.bagList.Count;
        for (int i = 0; i < num; i++)
        {
            bagList.bagList.Remove(bagList.bagList[0]);
        }
    }

    // 重新开始游戏
    public void RestarGame()
    {
        // 加载场景下标
        SceneManager.LoadScene(0);
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
        int num = bagList.bagList.Count;
        for (int i = 0;i < num;i++)
        {
            bagList.bagList.Remove(bagList.bagList[0]);
        }
    }

    // 游戏设置
    public void OpenGameSetting()
    {
        GameObject GameSettingUI = GameObject.FindGameObjectWithTag("gamesettingui").transform.gameObject;
        GameObject MainMenu = GameObject.FindGameObjectWithTag("mainmenu").transform.gameObject;

        GameSettingUI.transform.GetChild(0).gameObject.SetActive(true);
        MainMenu.transform.GetChild(0).gameObject.SetActive(false);

    }
    // 退出游戏
    public void ExitGame()
    {
        // 退出游戏
        Application.Quit();
    }
}