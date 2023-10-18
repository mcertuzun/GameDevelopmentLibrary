using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using Obvious.Soap;
using System;

namespace Assets.Library.DreamteckSplineControllers
{
    public class SplineFollowSpeedHandler : MonoBehaviour
    {
        [SerializeField] FloatReference speed;
        SplineFollower follower;
        ISplineFollower splineFollower;
        
        void Start()
        {
            speed.Variable.OnValueChanged += UpdateSpeed;
            splineFollower = GetComponent<ISplineFollower>();
            follower = GetComponent<SplineFollower>();
            UpdateSpeed(speed);
        }
        void UpdateSpeed(float newValue)
        {
            if (newValue < 0)
                follower.direction = Spline.Direction.Backward;
            else
                follower.direction = Spline.Direction.Forward;
            
            follower.followSpeed = Mathf.Abs(newValue);
        }
        private void OnDestroy()
        {
            speed.Variable.OnValueChanged -= UpdateSpeed;
        }


    }
}