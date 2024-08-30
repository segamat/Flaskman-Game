using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumnControl2 : MonoBehaviour
{
    //音乐
    private AudioSource menuAduio;
    private AudioSource Aduio1;
    private AudioSource Aduio2;
    //声音大小滑动条
    private Slider audioSlider;
    private int index;
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        print(index);
        if (index == 2 | index == 3)
        {
            var Aduio = GameObject.FindGameObjectWithTag("Player").transform.GetComponents(typeof(AudioSource));
            Aduio1 = (AudioSource)Aduio[0];
            Aduio2 = (AudioSource)Aduio[1];
            
        }
        if (index == 1 | index == 4)
        {
            menuAduio = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<AudioSource>();
        }
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
        if (index == 2|index==3)
        {
            Aduio1.volume = audioSlider.value;
            Aduio2.volume = audioSlider.value;
        }
        if (index == 1|index==4)
        {
            menuAduio.volume = audioSlider.value;
        }
    }


}