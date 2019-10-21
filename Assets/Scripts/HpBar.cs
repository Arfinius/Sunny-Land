﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{

    private RawImage barRawImage;

    public Image imageHp;

    public ShieldController SH;
    
    public Hp hp;

    private void Awake()
    {
        
        //barImage = transform.Find("bar").GetComponent<Image>();
        barRawImage = transform.Find("barMaskHp").Find("barHp").GetComponent<RawImage>();

        hp = new Hp();
    }

    private void FixedUpdate()
    {
        hp.Update();

        // Animation and stabilization of the hp bar.
        HpBarStabilization();
    }

    // Function needed to inflict damage to the player.
    public void HpSubstractionWhenK()
    {
        if(SH.shield.isPlaying == true)
        {
            hp.TrySpendHp(0);
        }
        else
        {
            hp.TrySpendHp(5);
        }
    }

    // Function responsible for additing hp To the player.
    public void HpAddition()
    {
        hp.hpAmount += 25;
    }

    // Function responsible for the hp bar stabilization and animation.
    public void HpBarStabilization()
    {
        Rect uvRect = barRawImage.uvRect;
        uvRect.x -= .1f * Time.fixedDeltaTime;
        barRawImage.uvRect = uvRect;
        imageHp.fillAmount = hp.GetNormalized();
    }
}

public class Hp
{
    public const int Hp_Max = 100;

    public float hpAmount = 100;

    public void Update()
    {
        // If the current hp state is greater than the maximum value to obtain, current state sets on maximum.
        if (hpAmount > Hp_Max)
        {
            hpAmount = Hp_Max;
        }
        
    }

    // Function responsible for spending mana.
    public void TrySpendHp(int amount)
    {
        // If the current hp state is greater than or equal to the value of spent hp, system subtracts this value from the current amount in time.
        if (hpAmount >= amount)
        {
            hpAmount -= amount;
        }
    }

    // Function that returns the current state of hp.
    public float GetNormalized()
    {
        return hpAmount / Hp_Max;
    }
}
