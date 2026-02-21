using System.Collections;

using UnityEngine;

namespace FlashEffect
{
    public class ColoredFlash : MonoBehaviour
    {
        #region Datamembers

        #region Editor Settings

     
        [SerializeField] private Material flashMaterial;

       
        [SerializeField] private float duration;

        #endregion
        #region Private Fields

       
        private SpriteRenderer spriteRenderer;

      
        private Material originalMaterial;

       
        private Coroutine flashRoutine;

        [SerializeField] private ColoredFlash flashEffect;

        
        private StatusEffectManager statusEffectManager;

        
        private bool wasBurning;
        private bool wasPoisoned;

        // Continuous flash coroutine handle
        private Coroutine continuousFlashRoutine;
        #endregion

        #endregion


        #region Methods

        #region Unity Callbacks
        void Start()
        {
         
            spriteRenderer = GetComponent<SpriteRenderer>();

            
            originalMaterial = spriteRenderer.material;

            
            flashMaterial = new Material(flashMaterial);

            
            statusEffectManager = GetComponent<StatusEffectManager>();
            wasBurning = false;
        
            wasPoisoned = false;
        }

        #endregion

        private void OnDisable()
        {
            StopAllCoroutines();
            continuousFlashRoutine = null;
            flashRoutine = null;
        }
        private void OnEnable()
        {
            // Reset flash state when enabled

            continuousFlashRoutine = null;
            flashRoutine = null;

            spriteRenderer.material = originalMaterial; 
            wasBurning = false;
            wasPoisoned = false;
        }
        private void Update()
        {
            
            if (statusEffectManager == null)
                statusEffectManager = GetComponent<StatusEffectManager>();

            bool isBurning = statusEffectManager != null
                             && statusEffectManager.burnTickTimers != null
                             && statusEffectManager.burnTickTimers.Count > 0;

            bool isPoisoned = statusEffectManager != null
                             && statusEffectManager.poisonTickTimers != null
                             && statusEffectManager.poisonTickTimers.Count > 0;

           
            if ((isBurning || isPoisoned) && continuousFlashRoutine == null)
            {
                continuousFlashRoutine = StartCoroutine(ContinuousFlashLoop());
            }

           
            if (!isBurning && !isPoisoned && continuousFlashRoutine != null)
            {
                StopCoroutine(continuousFlashRoutine);
                continuousFlashRoutine = null;
                
                spriteRenderer.material = originalMaterial;
            }

           
            wasBurning = isBurning;
            wasPoisoned = isPoisoned;
        }

        private IEnumerator ContinuousFlashLoop()
        {
           
            while (statusEffectManager != null
                   && ((statusEffectManager.burnTickTimers != null && statusEffectManager.burnTickTimers.Count > 0)
                       || (statusEffectManager.poisonTickTimers != null && statusEffectManager.poisonTickTimers.Count > 0)))
            {
               
                Color flashColor = Color.clear;
                if (statusEffectManager.burnTickTimers != null && statusEffectManager.burnTickTimers.Count > 0)
                    flashColor = Color.red;
                else if (statusEffectManager.poisonTickTimers != null && statusEffectManager.poisonTickTimers.Count > 0)
                    flashColor = Color.green;

                // Apply flash
                spriteRenderer.material = flashMaterial;
                flashMaterial.color = flashColor;

                // Keep flash visible for `duration`.
                yield return new WaitForSeconds(duration);

                // Revert to original for the off period so flashing is visible.
                spriteRenderer.material = originalMaterial;

                // Wait same duration (or adjust) before next flash to create a blink.
                yield return new WaitForSeconds(duration);
            }

            // Ensure restoration once loop exits.
            spriteRenderer.material = originalMaterial;
            continuousFlashRoutine = null;
        }

        public void Flash(Color color)
        {
           
            if (flashRoutine != null)
            {
                
                StopCoroutine(flashRoutine);
            }

           
            flashRoutine = StartCoroutine(FlashRoutine(color));
        }

        private IEnumerator FlashRoutine(Color color)
        {
            
            spriteRenderer.material = flashMaterial;

         
            flashMaterial.color = color;

            
            yield return new WaitForSeconds(duration);

            
            spriteRenderer.material = originalMaterial;

           
            flashRoutine = null;
        }

        #endregion
    }
}