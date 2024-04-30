using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine; 
using UnityEngine.UI;


public class OptionHandler : MonoBehaviour
{
    [SerializeField] Toggle Vsync, FScreen;
    [Header("Resolution")]
    [SerializeField] TMP_Dropdown resDropdown;
    Resolution[] resolutions;

    void Start(){
        FScreen.isOn = Screen.fullScreen;

        if ( QualitySettings.vSyncCount == 0){
            Vsync.isOn = false;
        }
        else{
            Vsync.isOn = true;
        }
        GetResolutionOptions();
    }
    public void BackButton(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void ApplyGraphics(){
        Screen.fullScreen = FScreen.isOn;

        if (Vsync.isOn){
            QualitySettings.vSyncCount = 1;
        }
        else{
            QualitySettings.vSyncCount = 0;
        }
    }

    void GetResolutionOptions(){
        resDropdown.ClearOptions();
        resolutions = Screen.resolutions;
        for( int i = 0; i < resolutions.Length; i++){
            TMP_Dropdown.OptionData newOption;
            newOption = new TMP_Dropdown.OptionData(resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString());
            resDropdown.options.Add(newOption);
        }
    }
    public void ChooseResolution(){
        Screen.SetResolution(resolutions[resDropdown.value].width, resolutions[resDropdown.value].height, FScreen.isOn);
    }
}
