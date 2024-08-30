using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCamera : MonoBehaviour
{
    // Start is called before the first frame update
    // 获取跟随摄像机
    private CinemachineVirtualCamera cine;
    // 切换follow时间
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
        // 拿到cinemachine
        cine = GameObject.FindGameObjectWithTag("cinema").GetComponent<CinemachineVirtualCamera>();
        // 拿到变更镜头的物体
        GameObject Changfollow = GameObject.Find("ChangFollow").gameObject;
        cine.Follow = Changfollow.GetComponent<Transform>();
        star = true;
    }

    // 恢复镜头
    public void ChangeBack()
    {
        // 拿到cinemachine
        cine = GameObject.FindGameObjectWithTag("cinema").GetComponent<CinemachineVirtualCamera>();
        // 角色
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        cine.Follow = player.transform;
        star = false;
        totalTime = 0;
    }
}
