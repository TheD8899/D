using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manabar1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMaxMana(int mana)
    {
        slider.maxValue = 50;
        slider.value = mana;
    }
    public void SetMana(int mana)
    {
        slider.value = mana;
    }
}
