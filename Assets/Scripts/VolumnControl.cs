using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumControl : MonoBehaviour
{
    //主界面音乐
    private AudioSource menuAduio;
    //声音大小滑动条
    private Slider audioSlider;
    void Start()
    {
        menuAduio = GameObject.FindGameObjectWithTag("mainmenu").transform.GetComponent<AudioSource>();
        audioSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        VolumeControl();
    }

    public void VolumeControl()
    {
        //控制声音大小
        menuAduio.volume = audioSlider.value;
    }
 
}