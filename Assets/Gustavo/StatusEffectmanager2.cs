using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager2 : MonoBehaviour
{
    private Health healthScript;

    public List<int> poisonTickTimers = new List<int>();
    public List<int> burnTickTimers = new List<int>();

    // Prefab to attach when burn is active (set in Inspector)
    [SerializeField] private GameObject ouchieBurnPrefab;

    // Runtime instance of the ouchie burn effect
    private GameObject activeOuchieBurnInstance;

    // Track running coroutines so we don't start duplicates
    private Coroutine burnCoroutine;
    private Coroutine poisonCoroutine;



    private void Start()
    {
        healthScript = GetComponent<Health>();
    }

    public void ApplyPoison(int ticks)
    {
        if (poisonTickTimers.Count <= 0)
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
        while (poisonTickTimers.Count > 0)
        {
            for (int i = 0; i < poisonTickTimers.Count; i++)
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
        if (burnTickTimers.Count <= 0)
        {
            burnTickTimers.Add(ticks);
            StartCoroutine(Burn());
        }
        else
        {
            burnTickTimers.Add(ticks);
        }

        if (activeOuchieBurnInstance == null && ouchieBurnPrefab != null)
        {
            activeOuchieBurnInstance = Instantiate(ouchieBurnPrefab, transform);
            activeOuchieBurnInstance.transform.localPosition = Vector3.zero;
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

        if (activeOuchieBurnInstance != null)
        {
            Destroy(activeOuchieBurnInstance);
            activeOuchieBurnInstance = null;
        }

        burnCoroutine = null;


    }
}