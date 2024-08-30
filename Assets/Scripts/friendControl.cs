using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendControl : MonoBehaviour
{

    public Transform player; //烧瓶人
    public float offent = -2f; //与烧瓶人的位置偏移 
    public float speed = 5f; //移动速度
    private SpriteRenderer fr;
  
    Rigidbody2D fbody;//刚体组件

    // Start is called before the first frame update
    void Start()
    {
        fbody = GetComponent<Rigidbody2D>();
        fr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        FriendSmothFlow();
    }

    // 跟随玩家移动
    void FriendSmothFlow()
    {
        if(Vector3.Distance(player.position,transform.position) > 2f)
        {
            float dis_x = Input.GetAxisRaw("Horizontal");
            float dis_y = Input.GetAxisRaw("Vertical");

            //玩家的左右翻转
            if (dis_x < 0) //左
            {
                fr.flipX = true;
                offent = 1;
            }
            if (dis_x > 0) //右
            {
                fr.flipX = false;
                offent = -1;
            }
            if (dis_y != 0)
            {
                offent = 0;
            }
            float movex = player.transform.position.x - fbody.position.x;
            float movey = player.transform.position.y - fbody.position.y;

            //移动
            Vector2 position = fbody.position;
            position.x += (movex + offent) * speed * Time.deltaTime;
            position.y += movey * speed * Time.deltaTime;
            fbody.MovePosition(position);
        }
    }
}
