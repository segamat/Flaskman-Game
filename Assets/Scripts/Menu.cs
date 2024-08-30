using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // ���˵�����
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // ��ʼ��Ϸ
    public void StartGame()
    {
        // ���س����±�
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // �����ұ���
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
        int num = bagList.bagList.Count;
        for (int i = 0; i < num; i++)
        {
            bagList.bagList.Remove(bagList.bagList[0]);
        }
    }

    // ���¿�ʼ��Ϸ
    public void RestarGame()
    {
        // ���س����±�
        SceneManager.LoadScene(0);
        bagCreate bagList = Resources.Load<bagCreate>("bag/bagData/playerbag");
        int num = bagList.bagList.Count;
        for (int i = 0;i < num;i++)
        {
            bagList.bagList.Remove(bagList.bagList[0]);
        }
    }

    // ��Ϸ����
    public void OpenGameSetting()
    {
        GameObject GameSettingUI = GameObject.FindGameObjectWithTag("gamesettingui").transform.gameObject;
        GameObject MainMenu = GameObject.FindGameObjectWithTag("mainmenu").transform.gameObject;

        GameSettingUI.transform.GetChild(0).gameObject.SetActive(true);
        MainMenu.transform.GetChild(0).gameObject.SetActive(false);

    }
    // �˳���Ϸ
    public void ExitGame()
    {
        // �˳���Ϸ
        Application.Quit();
    }
}