using Assets.Library.Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Library.Effect
{
    public class EffectSinglePooledParticle : MonoBehaviour, IEffect
    {

        [SerializeField] Vector3 StartPositionOffset;
        [SerializeField] string ParticlePoolName;
        GameObject ParticleObject;
        ParticleSystem Particle;
        [SerializeField] string EffectTag = "default";
        public string _EffectTag => EffectTag;
        private void Start()
        {

        }
        public void doEffect(GameObject target)
        {

            ParticleObject = PoolManager.Fetch(ParticlePoolName);
            ParticleObject.SetActive(true);
            Particle = ParticleObject.GetComponent<ParticleSystem>();

            ParticleObject.transform.position = transform.position + StartPositionOffset;
            Particle?.Play();
        }
    }
}