using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HealthCounterText;
    [SerializeField] private TextMeshProUGUI AmmoCounterText;
    [SerializeField] private MainCharacter Mc;


    void Start(){
        HealthCounterText.text = "Health:" + Mc.GetHealth();
        AmmoCounterText.text = "Ammo: " + Mc.GetAmmo();
    }
    // Update is called once per frame
    void Update()
    {
        HealthCounterText.text = "Health:" + Mc.GetHealth();
        AmmoCounterText.text = "Ammo: " + Mc.GetAmmo();
    }
}
