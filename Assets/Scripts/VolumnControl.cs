using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumControl : MonoBehaviour
{
    //����������
    private AudioSource menuAduio;
    //������С������
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
        //����������С
        menuAduio.volume = audioSlider.value;
    }
 
}