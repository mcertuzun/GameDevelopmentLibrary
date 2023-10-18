using Obvious.Soap;
using UnityEngine;
using UnityEngine.Events;

public class IsPaid : MonoBehaviour, IFlyingTransactionBrigde
{
    [SerializeField] UnityEvent CanPayEvent;
    [SerializeField] UnityEvent CantPayEvent;
    [SerializeField] UnityEvent PaidEvent;
    [SerializeField] UnityEvent NotPaidEvent;
    [Tooltip("If It leaves null, It gets ICanBeBought interface from parent.")]
    [SerializeField] BuyProperty buyProperty;
    [SerializeField] IntReference RelatedCurrency;
    
    IntVariableContainer targetVariableContainer;
    ICanBeBought canBought;
    bool isPaid;
    bool canPay;

    public int RemainingCost { get => canBought.RemainingCost; set => canBought.RemainingCost = value; }

    public int TotalCost => canBought.Cost;

    public IntReference Currency => canBought.RelatedCurrency;

    private void Start()
    {
        targetVariableContainer = GameObject.FindGameObjectWithTag("Player").GetComponent<IntVariableContainer>();

        if (canBought == null)
            canBought = GetComponentInParent<ICanBeBought>();

        if (canBought == null)
            Debug.Log("There is no ICanBought in parent.");
    }

    public void HasMoney()
    {
        canPay = targetVariableContainer.GetCurrencyValue(canBought.RelatedCurrency.Variable.Id) >= canBought.Cost;

        if (canPay)
            CanPayEvent?.Invoke();
        else
            CantPayEvent?.Invoke();
    }

    public void Pay()
    {
        if (TotalCost == -1)
            isPaid = false;
        else
            isPaid = targetVariableContainer.DecreaseCurrency(Currency.Variable.Id, TotalCost);

        if (isPaid)
            PaidEvent?.Invoke();
        else
            NotPaidEvent?.Invoke();

    }
}

public interface ICanBeBought
{
    int RemainingCost { get; set; }
    int Cost { get; }
    IntReference RelatedCurrency { get; }
}
