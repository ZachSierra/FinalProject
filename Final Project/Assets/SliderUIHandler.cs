using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderUIHandler : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider musicSlider;

    void Awake(){
        masterSlider.value = GetMixerVolume("Master");
        sfxSlider.value = GetMixerVolume("SFX");
        musicSlider.value = GetMixerVolume("Music");
    }

    // Update is called once per frame
    void Update()
    {
        SetMixerVolume("Master", masterSlider.value);
        SetMixerVolume("SFX", sfxSlider.value);
        SetMixerVolume("Music", musicSlider.value);
    }
    private float GetMixerVolume(string mixerName){
        float value;
		bool result =  mixer.GetFloat(mixerName, out value);
		if(result){
			return -value;
		}else{
            Debug.Log(result);
			return 0f;
		}
    }
    private void SetMixerVolume(string mixerName, float value){
        value = -value;
		mixer.SetFloat(mixerName, value);
    }
}
