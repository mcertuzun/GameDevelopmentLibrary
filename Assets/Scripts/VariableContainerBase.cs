using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;

public abstract class VariableContainerBase<T, T2> : MonoBehaviour 
{
    [SerializeField] protected List<VariableReference<ScriptableVariable<T>, T>> VariableList = new();
    protected VariableReference<ScriptableVariable<T>, T> GetVariable(T2 id)
    {
        for (int i = 0; i < VariableList.Count; i++)
        {
            if (VariableList[i].Variable.Id.Equals(id))
                return VariableList[i];

        }
        return null;
    }
}
