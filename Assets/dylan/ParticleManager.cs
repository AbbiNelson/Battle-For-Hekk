using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

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
            continuousObjects[i] = Instantiate(continuousEffects[i].gameObject, transform);
            continuousObjects[i].transform.localPosition = continuousEffectOffsets[i];
            StopParticleEffect(i);
        }
    }

    public void OnMoveStart()
    {
        PlayParticleEffect(0); // start running particle effect
    }

    public void OnMoveEnd()
    {
        StopParticleEffect(0); // stop running particle effect
    }

    public void OnJump()
    {
        PlayOneOffEffect(0, 1.5f * Vector2.down);
    }

    public void OnLand()
    {
        PlayOneOffEffect(1, 1.5f * Vector2.down);
    }

    // ------------ Helper Methods ------------

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
