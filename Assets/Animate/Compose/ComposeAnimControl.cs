using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComposeAnimControl : MonoBehaviour
{
    // Start is called before the first frame update
    Animator compose;
    float totaltime = 0;
    Transform timeline;
    public Transform item;
    public itemCreate Image;
    Transform UI;

    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("uisystem").transform.GetChild(0).transform;
        timeline = GameObject.FindGameObjectWithTag("Player").transform;
        compose = GameObject.Find("ComposeAnim").transform.GetChild(0).gameObject.GetComponent<Animator>();
        CloseUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (totaltime == 0) CloseUI();
        totaltime += Time.deltaTime;
        if(totaltime >= 2)
        {
            totaltime = 0;
            UI.GetChild(0).gameObject.SetActive(true);
            timeline.GetChild(2).gameObject.SetActive(false);
        }
    }

    // 下载合成的物品图片
    public void LoadImage(string name)
    {
        Image = Resources.Load<itemCreate>("bag/itemData/" + name);
        print(Image.name);
    }

    // 关闭UI界面
    public void CloseUI()
    {
        UI.GetChild(0).gameObject.SetActive(false);
        item.GetComponent<Image>().sprite = Image.ItemImage;
        compose.SetBool("star", true);
    }
}
