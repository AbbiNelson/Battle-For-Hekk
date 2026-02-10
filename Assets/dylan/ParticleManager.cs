using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] oneOffEffects = new ParticleSystem[1];
    [SerializeField] private ParticleSystem[] continuousEffects = new ParticleSystem[1];
    private GameObject[] continuousObjects;
    [SerializeField] private Vector2[] continuousEffectOffsets = new Vector2[1];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        continuousObjects = new GameObject[continuousEffects.Length];

        for (int i = 0; i < continuousEffects.Length; i++)
        {
            continuousObjects[i] = Instantiate(continuousEffects[i].gameObject, transform.position - (Vector3)continuousEffectOffsets[i]);
            continuousObjects[i].GetComponent<ParticleSystem>().Play(); // Start with continuous effects stopped

            //if (continuousEffects[i] != null)
            //{
            //    continuousEffects[i].Play();
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayOneOffEffect(0, 1.5f * Vector2.down); // Example: Play the first one-off effect
    }

    void PlayParticleEffect(int index)
    {
        if (index >= 0 && index < continuousObjects.Length)
        {
            continuousObjects[index].GetComponent<ParticleSystem>().Play();
        }
    }

    void StopParticleEffect(int index)
    {
        if (index >= 0 && index < continuousObjects.Length)
        {
            continuousObjects[index].GetComponent<ParticleSystem>().Stop();
        }
    }

    void PlayOneOffEffect(int index, Vector2 offset)
    {
        if (index >= 0 && index < oneOffEffects.Length)
        {
            Instantiate(oneOffEffects[index], transform.position + (Vector3)offset, Quaternion.identity);
        }
    }
}
