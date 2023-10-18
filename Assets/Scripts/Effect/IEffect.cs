using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Library.Effect
{
    public interface IEffect
    {
        string _EffectTag { get; }
        void doEffect(GameObject target);
    }


    public enum EffectTarget
    {
        self,
        other,
        bought
    }
}