using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tutorial
{
    [Tooltip("Must be uniq among the Tutorials.")]
    public string saveId;
    [SerializeField] bool isPlayed = false;
    [SerializeField] bool isStarted = false;
    [SerializeField] bool isEnded = false;
    public List<TutorialPointer> pointers = new List<TutorialPointer>();
    public TutorialPointer CurrentPointer
    {
        get
        {
            if (pointers.Count > 0)
                return pointers[Counter - 1];
            else
                return null;
        }
    }
    public bool IsPlayed
    {
        get => isPlayed;
        set
        {
            if (isPlayed != value)
            {
                isPlayed = value;
                PlayerPrefs.SetInt(saveId + "_IsPlayed", isPlayed ? 1 : 0);
            }
        }
    }

    public bool IsStarted
    {
        get => isStarted;
        set
        {
            if (isStarted != value)
            {
                isStarted = value;
                PlayerPrefs.SetInt(saveId + "_IsStarted", isStarted ? 1 : 0);
            }
        }
    }

    public int Counter
    {
        get => counter;
        set
        {
            if (counter != value)
            {
                counter = value;
                PlayerPrefs.SetInt(saveId + "_Counter", counter);
            }
        }
    }

    public bool IsEnded
    {
        get => isEnded;
        set
        {
            if (isEnded != value)
            {
                isEnded = value;
                PlayerPrefs.SetInt(saveId + "_IsEnded", isEnded ? 1 : 0);
            }
        }
    }

    [SerializeField] int counter = 0;

    /// <summary>
    /// It starts Tutorial.
    /// </summary>
    public void StartSequence()
    {
        if (IsPlayed)
            return;

        if (!IsStarted)
        {
            IsStarted = true;
            Counter = 0;

            if (TutorialManager.ins.UIArrowSimpleMove != null)
                TutorialManager.ins.UIArrowSimpleMove.OnReachDestinaton += OnDestinationReached;

            if (TutorialManager.ins.InGameArrowSimpleMove != null)
                TutorialManager.ins.InGameArrowSimpleMove.OnReachDestinaton += OnDestinationReached;

            TutorialManager.ins.SimpleMove(pointers[Counter]);
            Counter++;

        }
        else if (IsStarted && !IsEnded && Counter < pointers.Count)
        {
            Debug.Log("StartSequence 2 ");
            TutorialManager.ins.SimpleMove(pointers[Counter]);
            Counter++;
        }
        else
        {
            StopTutorial();
        }
    }

    public void NextPointer() => StartSequence();

    public void StopTutorial()
    {
        TutorialManager.ins.DisableAllArrows();

        if (IsEnded)
            IsPlayed = true;

        IsStarted = false;
        IsEnded = false;
        if (TutorialManager.ins.UIArrowSimpleMove != null)
            TutorialManager.ins.UIArrowSimpleMove.OnReachDestinaton -= OnDestinationReached;
        if (TutorialManager.ins.InGameArrowSimpleMove != null)
            TutorialManager.ins.InGameArrowSimpleMove.OnReachDestinaton -= OnDestinationReached;
    }
    private void OnDestinationReached()
    {
        if (IsStarted && !IsEnded)
        {
            //TutorialManager.ins.EnableArrow();

            if (Counter > pointers.Count)
                IsEnded = true;
        }
        else if (IsStarted && IsEnded)
        {

        }
    }

    public void Load()
    {
        isPlayed = PlayerPrefs.GetInt(saveId + "_IsPlayed", 0) == 1;
        isStarted = PlayerPrefs.GetInt(saveId + "_IsStarted", 0) == 1;
        counter = PlayerPrefs.GetInt(saveId + "_Counter", 0);
        if (counter > 0)
            counter -= 1;

        isEnded = PlayerPrefs.GetInt(saveId + "_IsEnded", 0) == 1;

        //Debug.Log("saveId : " + saveId + "isPlayed : " + isPlayed + " isStarted : " + isStarted + " isEnded : " + isEnded + " counter : " + counter);
    }


}
