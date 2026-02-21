using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStatusEffectManager : MonoBehaviour
{
    private ObjectHealth healthScript;
    public List<int> poisonTickTimers = new List<int>();
    public List<int> burnTickTimers = new List<int>();

    // Prefab to attach when burn is active (set in Inspector)
    [SerializeField] private GameObject ouchieBurnPrefab;
    [SerializeField] private GameObject ouchiePoisonPrefab;
    // Runtime instance of the ouchie burn effect
    private GameObject activeOuchieBurnInstance;
    private GameObject activeOuchiePoisonInstance;
    // Track running coroutines so we don't start duplicates
    private Coroutine burnCoroutine;
    private Coroutine poisonCoroutine;

    private void Start()
    {
        healthScript = GetComponent<ObjectHealth>();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        burnCoroutine = null;
        poisonCoroutine = null;

        poisonTickTimers.Clear();
        burnTickTimers.Clear();

        Destroy(activeOuchiePoisonInstance);
        Destroy(activeOuchieBurnInstance);
    }

    public void ApplyPoison(int ticks)
    {
        Debug.Log("Poison");
        if (poisonTickTimers == null) poisonTickTimers = new List<int>();
        poisonTickTimers.Add(ticks);

        if (activeOuchiePoisonInstance == null && ouchiePoisonPrefab != null)
        {
            activeOuchiePoisonInstance = Instantiate(ouchiePoisonPrefab, transform);
            activeOuchiePoisonInstance.transform.localPosition = Vector3.zero;
        }

        if (poisonCoroutine == null)
            poisonCoroutine = StartCoroutine(Poison());
    }

    public void ApplyBurn(int ticks)
    {
        Debug.Log("Burn");
        if (burnTickTimers == null) burnTickTimers = new List<int>();
        burnTickTimers.Add(ticks);


        if (activeOuchieBurnInstance == null && ouchieBurnPrefab != null)
        {
            activeOuchieBurnInstance = Instantiate(ouchieBurnPrefab, transform);
            activeOuchieBurnInstance.transform.localPosition = Vector3.zero;
        }

        if (burnCoroutine == null)
            burnCoroutine = StartCoroutine(Burn());
    }

    private IEnumerator Poison()
    {
        while (poisonTickTimers.Count > 0)
        {
            // Process one tick (example: deal damage)
            // healthScript?.TakeDamage(1);
            for (int i = 0; i < poisonTickTimers.Count; i++)
                poisonTickTimers[i]--;

            healthScript.health -= 5;
            poisonTickTimers.RemoveAll(x => x <= 0);

            yield return new WaitForSeconds(1f); // tick interval
        }

        if (activeOuchiePoisonInstance != null)
        {
            Destroy(activeOuchiePoisonInstance);
            activeOuchieBurnInstance = null;
        }



        poisonCoroutine = null;
    }

    private IEnumerator Burn()
    {
        while (burnTickTimers.Count > 0)
        {
            // Process one tick (example: deal damage)
            // healthScript?.TakeDamage(1);
            for (int i = 0; i < burnTickTimers.Count; i++)
                burnTickTimers[i]--;

            healthScript.health -= 5;
            burnTickTimers.RemoveAll(x => x <= 0);

            yield return new WaitForSeconds(1f); // tick interval
        }

        // All burn ticks finished -> remove visual effect
        if (activeOuchieBurnInstance != null)
        {
            Destroy(activeOuchieBurnInstance);
            activeOuchieBurnInstance = null;
        }



        burnCoroutine = null;
    }
}