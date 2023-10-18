using Assets.Library.Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Library.Effect
{
    public class EffectPoolRelease : MonoBehaviour, IEffect
    {

        public string EffectTag = "default";
        public string _EffectTag => EffectTag;

        public void doEffect(GameObject target)
        {
            GetComponent<PoolObject>()?.Release();
        }

    }
}