using Assets.Library.Pooling;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFlyingMoneyManager : MonoBehaviour
{
    public static UIFlyingMoneyManager ins;
    public Action spawnMoney;
    [SerializeField] PoolInfo moneyPoolInfo;
    [SerializeField] PoolInfo specialMoneyPoolInfo;
    [SerializeField] Transform inGameCanvasTransform;
    [SerializeField] GameObject target;
    [SerializeField] GameObject specialMoneyTarget;
    [SerializeField] AnimationCurve aCurve;
    [SerializeField] float UnitSphereRadiusMultiplier;
    GameObject player;
    float lastSpawnTime = 0;
    int counter = 0;
    Vector3 tempVec3;

    public string FlyingMoneyName
    {
        get
        {
            if (moneyPoolInfo != null)
                return moneyPoolInfo.PoolName;
            else
            {
                Debug.LogError("PoolInfo for FlyingMoney Object is missing");
                return null;
            }
        }
    }

    public string FlyingSpecialMoneyName
    {
        get
        {
            if (specialMoneyPoolInfo != null)
                return specialMoneyPoolInfo.PoolName;
            else
            {
                Debug.LogError("PoolInfo for FlyingMoney Object is missing");
                return null;
            }
        }
    }

    private void Awake()
    {
        if (ins == null)
            ins = this;
    }

    private void Start()
    {
        ins.spawnMoney += OnMoneyIncrease;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnDestroy()
    {
        ins.spawnMoney -= OnMoneyIncrease;
    }

    // Empty Function 
    private void IncreaseMoneyOnUI()
    {

    }
    private Vector3 RandomLocationInCircle()
    {
        tempVec3 = UnityEngine.Random.insideUnitSphere * UnitSphereRadiusMultiplier;

        return tempVec3;
    }

    // To prevent over instantiation. It's limited to 30 in 0.1 seconds
    public void OnMoneyIncrease()
    {
        if (Time.time - lastSpawnTime < 0.1f)
            counter++;
        else
            counter = 0;

        if (counter <= 30)
        {
            FlyMoneyWithWorlPosition(player.transform.position + RandomLocationInCircle(), 1f, aCurve, (GameObject) => IncreaseMoneyOnUI());
            lastSpawnTime = Time.time;
        }
    }

    /// <summary>
    /// FlyMoney static function will run a flying money tween animation on UI from given position to default Money visual position.
    /// This function only works during GameState "==" Play case , will call the CallBack delegate when the fly animation is
    /// completed
    /// </summary>
    /// <param name="StartPositionUI">StartPositionUI is the UI start position of the money(point) visual , 
    /// If youy dont have this, use the alternative call for worldposition</param>
    /// <param name="speed">Speed parameter determines the duration of the animation. 0.5f will set the animation to complete in 2 secconds </param>
    /// <param name="flyMoneyCallBack">CallBack delegate is the reference to the callback function to be invoked when the tweenAnimation is completed.
    /// Importan parameter If you want to syncronize the increment of your points with the UI animation. 
    /// Unless you can make the increment before or after calling FlyMoney </param>
    public void FlyMoney(Vector3 StartPositionUI, float speed, AnimationCurve curve, SimpleTranslate.CallBack flyMoneyCallBack)
    {
        GameObject FlyingMoney = PoolManager.Fetch(FlyingMoneyName);
        SimpleTranslate st = FlyingMoney.GetComponent<SimpleTranslate>();

        if (st == null)
            st = FlyingMoney.AddComponent<SimpleTranslate>();

        FlyingMoney.SetActive(true);
        st.Translate(.3f, target.transform.position, true, flyMoneyCallBack);
        FlyingMoney.transform.SetParent(inGameCanvasTransform);
        FlyingMoney.transform.position = StartPositionUI;
        SimpleSizeTween sst = FlyingMoney.GetComponent<SimpleSizeTween>();
        if (sst == null)
            sst = FlyingMoney.AddComponent<SimpleSizeTween>();

        sst.StartAnimation(.3f, 0.3f, curve, null);

    }


    /// <summary>
    /// FlySpecialMoney static function will run a flying money tween animation on UI from given position to default SpecialMoney visual position.
    /// This function only works during GameState "==" Play case , will call the CallBack delegate when the fly animation is
    /// completed
    /// </summary>
    /// <param name="StartPositionUI">StartPositionUI is the UI start position of the money(point) visual , 
    /// If youy dont have this, use the alternative call for worldposition</param>
    /// <param name="speed">Speed parameter determines the duration of the animation. 0.5f will set the animation to complete in 2 secconds </param>
    /// <param name="flyMoneyCallBack">CallBack delegate is the reference to the callback function to be invoked when the tweenAnimation is completed.
    /// Importan parameter If you want to syncronize the increment of your points with the UI animation. 
    /// Unless you can make the increment before or after calling FlyMoney </param>
    public void FlySpecialMoney(Vector3 StartPositionUI, float speed, AnimationCurve curve, SimpleTranslate.CallBack flyMoneyCallBack)
    {
        GameObject FlyingMoney = PoolManager.Fetch(FlyingSpecialMoneyName);


        SimpleTranslate st = FlyingMoney.GetComponent<SimpleTranslate>();
        if (st == null)
            st = FlyingMoney.AddComponent<SimpleTranslate>();
        st.Translate(.3f, specialMoneyTarget.transform.position, true, flyMoneyCallBack);
        FlyingMoney.transform.SetParent(inGameCanvasTransform);
        FlyingMoney.transform.position = StartPositionUI;
        SimpleSizeTween sst = FlyingMoney.GetComponent<SimpleSizeTween>();
        if (sst == null)
            sst = FlyingMoney.AddComponent<SimpleSizeTween>();

        sst.StartAnimation(.3f, 0.3f, curve, null);

    }


    /// <summary>
    /// FlyMoney static function will run a flying money tween animation on UI from given position to default Money visual position.
    /// This function only works during GameState "==" Play case , will call the CallBack delegate when the fly animation is
    /// completed
    /// </summary>
    /// <param name="WorldObjectForPositioning">Is the position reference object where the flyingMoney will be originated from</param>
    /// <param name="speed">Speed parameter determines the duration of the animation. 0.5f will set the animation to complete in 2 secconds </param>
    /// <param name="flyMoneyCallBack">CallBack delegate is the reference to the callback function to be invoked when the tweenAnimation is completed.
    /// Importan parameter If you want to syncronize the increment of your points with the UI animation. 
    /// Unless you can make the increment before or after calling FlyMoney </param>
    public void FlyMoneyWithWorlPosition(Vector3 WorldObjectForPosition, float speed, AnimationCurve curve, SimpleTranslate.CallBack flyMoneyCallBack)
    {
        FlyMoney(Camera.main.WorldToScreenPoint(WorldObjectForPosition), speed, curve, flyMoneyCallBack);
    }

    /// <summary>
    /// FlySpecialMoney static function will run a flying money tween animation on UI from given position to default Money visual position.
    /// This function only works during GameState "==" Play case , will call the CallBack delegate when the fly animation is
    /// completed
    /// </summary>
    /// <param name="WorldObjectForPositioning">Is the position reference object where the flyingMoney will be originated from</param>
    /// <param name="speed">Speed parameter determines the duration of the animation. 0.5f will set the animation to complete in 2 secconds </param>
    /// <param name="flyMoneyCallBack">CallBack delegate is the reference to the callback function to be invoked when the tweenAnimation is completed.
    /// Importan parameter If you want to syncronize the increment of your points with the UI animation. 
    /// Unless you can make the increment before or after calling FlyMoney </param>
    public void FlySpecialMoneyWithWorlPosition(Vector3 WorldObjectForPosition, float speed, AnimationCurve curve, SimpleTranslate.CallBack flyMoneyCallBack)
    {
        FlySpecialMoney(Camera.main.WorldToScreenPoint(WorldObjectForPosition), speed, curve, flyMoneyCallBack);
    }
}
