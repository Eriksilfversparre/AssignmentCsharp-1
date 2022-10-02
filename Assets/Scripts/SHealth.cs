using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SHealth : MonoBehaviour
{
    [SerializeField] private float maxHP;
    [SerializeField] private Image HPBar;

    private float currentHP;

    private void Start()
    {
        currentHP = maxHP;

        HPBar.fillAmount = 1f;
    }

    public void TakeDmg(float dmg)
    {
        currentHP -= dmg;
        HPBar.fillAmount = currentHP / maxHP;

        if(currentHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
