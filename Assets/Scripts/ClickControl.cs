using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenGrocery();
    }

    // 点击打开小卖部
    public static void OpenGrocery()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask mask = ~(2);
            if(Physics.Raycast(ray, out hit,1000,mask))
            {
                if (hit.collider.gameObject.name == "grocer")
                {
                    UIcontrol.Opengrocery();
                }
            }
        }
    }
}
