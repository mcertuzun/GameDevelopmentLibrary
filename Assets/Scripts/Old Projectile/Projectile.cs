using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class Projectile : MonoBehaviour
{
    bool action = false;
    Vector3 StartPoint, TargetPoint,CurrentPoint;
    [SerializeField] float Speed;
    protected float progressPercentage {

        get {
            return (CurrentPoint - StartPoint).magnitude / (TargetPoint - StartPoint).magnitude;
        
        }
    }
    public void fire(Vector3 StartPoint , Vector3 TargetPoint)
    {
        this.StartPoint = StartPoint;
        this.CurrentPoint = StartPoint;
        this.TargetPoint = TargetPoint;
        transform.position = StartPoint;

        Onfire();
        action = true;
    }
    protected abstract void Onfire();
    protected abstract void AfterMove();
    protected abstract void OnReach();
    private void LateUpdate()
    {
        if (action)
        {
            CurrentPoint = Vector3.MoveTowards(CurrentPoint, TargetPoint, Speed * Time.deltaTime);
            transform.position = CurrentPoint;
            AfterMove();
            if (CurrentPoint == TargetPoint)
            { 
                action = false;
                OnReach();
            }
        }
    }
}
