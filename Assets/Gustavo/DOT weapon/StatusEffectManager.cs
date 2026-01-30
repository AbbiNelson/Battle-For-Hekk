using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    private Health healthScript;

    public List<int> poisonTickTimers = new List<int>();
    public List<int> burnTickTimers = new List<int>();
    private void Start()
    {
        healthScript = GetComponent<Health>();
    }

    public void ApplyPoison(int ticks)
    {
        if(poisonTickTimers.Count <= 0)
        {
            poisonTickTimers.Add(ticks);
            StartCoroutine(Poison());
        }
        else
        {
            poisonTickTimers.Add(ticks);
        }

    
    }

    IEnumerator Poison()
    {
        while(poisonTickTimers.Count > 0)
        {
            for(int i = 0; i < poisonTickTimers.Count; i++)
            {
                poisonTickTimers[i]--;
                
            }
            healthScript.health -= 5;
            poisonTickTimers.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
        }
    }

    public void ApplyBurn(int ticks)
    {
        if(burnTickTimers.Count <= 0)
        {
            burnTickTimers.Add(ticks);
            StartCoroutine(Burn());
        }
        else
        {
            burnTickTimers.Add(ticks);
        }
    }


    IEnumerator Burn()
    {
        while (burnTickTimers.Count > 0)
        {
            for (int i = 0; i < burnTickTimers.Count; i++)
            {
                burnTickTimers[i]--;

            }
            healthScript.health -= 5;
            burnTickTimers.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
        }
    }
}
