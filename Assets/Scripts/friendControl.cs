using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendControl : MonoBehaviour
{

    public Transform player; //��ƿ��
    public float offent = -2f; //����ƿ�˵�λ��ƫ�� 
    public float speed = 5f; //�ƶ��ٶ�
    private SpriteRenderer fr;
  
    Rigidbody2D fbody;//�������

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

    // ��������ƶ�
    void FriendSmothFlow()
    {
        if(Vector3.Distance(player.position,transform.position) > 2f)
        {
            float dis_x = Input.GetAxisRaw("Horizontal");
            float dis_y = Input.GetAxisRaw("Vertical");

            //��ҵ����ҷ�ת
            if (dis_x < 0) //��
            {
                fr.flipX = true;
                offent = 1;
            }
            if (dis_x > 0) //��
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

            //�ƶ�
            Vector2 position = fbody.position;
            position.x += (movex + offent) * speed * Time.deltaTime;
            position.y += movey * speed * Time.deltaTime;
            fbody.MovePosition(position);
        }
    }
}
