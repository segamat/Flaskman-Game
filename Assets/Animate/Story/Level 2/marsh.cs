using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marsh : MonoBehaviour
{
    // Start is called before the first frame update
    static Transform mar;
    public itemCreate wood;
    void Start()
    {
        mar = GameObject.Find("Marsh").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 碰撞时，可以使用数量大于3的木材
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && wood.ItemNum >= 3)
        {
            wood.use = true;
        }
    }

    // 离开碰撞后不可使用木材
    private void OnCollisionExit2D(Collision2D collision)
    {
        wood.use = false;
    }

    // 改变沼泽状态，添加木桥
    public static void ChangeMarsh()
    {
        mar.GetChild(1).gameObject.SetActive(true);
        mar.GetChild(0).gameObject.SetActive(false);
    }
}
