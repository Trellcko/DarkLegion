using UnityEngine;
using DG.Tweening;
using System;

namespace DarkLegion.Unit.AttackSystem.Visualization
{
    public class BuffAttachVisualization : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private BuffMaterialsData _buffMaterialsData;

        private const string BlendAttribute = "_Blend";

        private const float MaxBlend = 1f;
        private const float MinBlend = 0f;

        private readonly float BlendDuration = 2f;

        public void ShowPositiveEffect()
        {
            RunBlendAnimation(_buffMaterialsData.PositiveBuff);
        }

        public void ShowNegativeEffect()
        {
            RunBlendAnimation(_buffMaterialsData.NegativeBuff);
        }

        private void RunBlendAnimation(Material material)
        {
            _spriteRenderer.material = material;
            Blend(MinBlend, MaxBlend, () => { Blend(MaxBlend, MinBlend, null); });
        }

        private void Blend(float from, float to, Action Completed)
        {
            DOTween.To(
               () => from,
               (float value) => { _spriteRenderer.material.SetFloat(BlendAttribute, value); },
               to,
               BlendDuration).
               OnComplete(()=> { Completed?.Invoke(); });
        }
    }
}