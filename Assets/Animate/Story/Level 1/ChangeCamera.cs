using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCamera : MonoBehaviour
{
    // Start is called before the first frame update
    // ��ȡ���������
    private CinemachineVirtualCamera cine;
    // �л�followʱ��
    public float totalTime = 0;
    public static bool star = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (star)
        {
            if (star && totalTime >= 4)
            {
                ChangeBack();
            }
            else totalTime += Time.deltaTime;
        }
    }

    //
    public static void ChangeFollow()
    {
        CinemachineVirtualCamera cine;
        // �õ�cinemachine
        cine = GameObject.FindGameObjectWithTag("cinema").GetComponent<CinemachineVirtualCamera>();
        // �õ������ͷ������
        GameObject Changfollow = GameObject.Find("ChangFollow").gameObject;
        cine.Follow = Changfollow.GetComponent<Transform>();
        star = true;
    }

    // �ָ���ͷ
    public void ChangeBack()
    {
        // �õ�cinemachine
        cine = GameObject.FindGameObjectWithTag("cinema").GetComponent<CinemachineVirtualCamera>();
        // ��ɫ
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        cine.Follow = player.transform;
        star = false;
        totalTime = 0;
    }
}
