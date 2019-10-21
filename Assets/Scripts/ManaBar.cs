using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour {
    
    private RawImage barRawImage;

    // Bool variable responsible for checking if mana is empty. (Checking if we can use shield/crouch, same thing)
    bool isEmptyMana = false; 

    public Mana mana;

    public Image imageMana;

    private void Awake()
    {
        
        barRawImage = transform.Find("barMaskMana").Find("barMana").GetComponent<RawImage>();

        mana = new Mana();
    }

    private void FixedUpdate()
    {
        mana.Update();

        // Animation and stabilization of the mana bar.
        ManaBarStabilization();
    }

    // Function responsible for turning on shield, depending on mana.
    public void ShieldWhenS()
    {
        // If isManaEmpty = false - possibility to crouch / spend mana.
        if (isEmptyMana == false)
        {
            mana.TrySpendMana(2);
        }
        
        // If isManaEmpty = true - a signal for mana regeneration.
        if (mana.manaAmount <= 2)
        {
            isEmptyMana = true;
        }

        else if (mana.manaAmount >= 0)
        {
            isEmptyMana = false;
        }
    }

    // Function responsible for the mana bar stabilization and animation.
    public void ManaBarStabilization()
    {
        Rect uvRect = barRawImage.uvRect;
        uvRect.x += .1f * Time.fixedDeltaTime;
        barRawImage.uvRect = uvRect;
        imageMana.fillAmount = mana.GetNormalized();
    }
}

public class Mana
{
    public const int Mana_Max = 100;

    public float manaAmount = 100;

    private float manaRegenAmount = 10;


    // Main function responsible for mana regulation.
    public void Update()
    {
        // If the current mana state is greater than the maximum value to obtain, current state sets on maximum.
        if (manaAmount > Mana_Max)
        {
            manaAmount = Mana_Max;
        }
        else
        // Mana regeneration - adding to the current state, value of manaRegenAmount in time (Time.deltaTime).
        {
            manaAmount += manaRegenAmount * Time.deltaTime;
        }
    }

    // Function responsible for spending mana.
    public void TrySpendMana(int amount)
    {
        // If the current mana state is greater than or equal to the value of spent mana, system subtracts this value from the current amount in time
        if (manaAmount >= amount)
        {
            manaAmount -= amount;
        }
    }

    // Function that returns the current state of mana.
    public float GetNormalized()
    {
        return manaAmount / Mana_Max;
    }
}
