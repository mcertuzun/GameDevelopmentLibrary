using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Library.Pooling
{
    [CreateAssetMenu(fileName = "PoolCreateInfo", menuName = "Scriptables/Pooling/PoolCreateInfo")]
    public class PoolCreateList : ScriptableObject
    {
        public List<PoolInfo> CreationList;
    }
}