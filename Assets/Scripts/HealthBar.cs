using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public void ChangeHP(int currHealth, int maxHealth)
    {
        fillBar.fillAmount = (float)currHealth / (float)maxHealth;
    }
}
