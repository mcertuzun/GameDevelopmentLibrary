using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Library.LevelDesign.LevelScriptableCreator
{
    public interface ISpecialBlock
    {
        void getSpecialParameters(ref List<specialData> specials);
        void setSpecialParameters(List<specialData> specials);

    }
}