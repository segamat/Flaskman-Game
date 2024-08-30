using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlBagPosition : MonoBehaviour
{
    private Transform player;
    private RectTransform rectTransfrom;
    public bool IsInventoryBagPositionButton = true;

    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        rectTransfrom = GetComponent<RectTransform>();
        mainCamera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchinventoryBagPosition();
    }

    private void SwitchinventoryBagPosition()
    {
        Vector3 transposition = rectTransfrom.position;
        Vector3 playerViewportPosition = player.transform.position;
        if (playerViewportPosition.y > -38.0f && IsInventoryBagPositionButton == false)
        {
            transposition.y = 51.5f;
            rectTransfrom.position = transposition;
            print(rectTransfrom.position);
            IsInventoryBagPositionButton = true;
        }
        else if(playerViewportPosition.y <= -40.0f && IsInventoryBagPositionButton == true)
        {
            transposition.y = 560.0f;
            rectTransfrom.position = transposition;
            print(rectTransfrom.position);
            IsInventoryBagPositionButton = false;
        }
    }
}
