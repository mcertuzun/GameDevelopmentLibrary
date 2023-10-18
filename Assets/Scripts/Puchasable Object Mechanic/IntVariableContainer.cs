using Obvious.Soap;
public class IntVariableContainer : VariableContainerBase<int, string>
{
    ScriptableVariable<int> tempVariable;
    private ScriptableVariable<int> GetVariableSC(string id)
    {
        return GetVariable(id).Variable;
    }

    public int GetCurrencyValue(string id)
    {
        if (!Contains(id))
            return -1;
        else
            return GetVariableSC(id).Value;
    }
    public bool Contains(string id)
    {
        return GetVariable(id) != null;
    }
    public bool IncreaseCurrency(string id, int amount)
    {
        tempVariable = GetVariableSC(id);
        if (tempVariable != null)
        {
            tempVariable.Value += amount;
            return true;
        }
        else
            return false;

    }

    public bool DecreaseCurrency(string id, int amount)
    {
        tempVariable = GetVariableSC(id);
        if (GetVariableSC(id) != null)
        {
            if (tempVariable.Value >= amount)
            {
                tempVariable.Value -= amount;
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }
}
