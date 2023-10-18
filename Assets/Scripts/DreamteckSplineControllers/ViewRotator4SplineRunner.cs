using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using Assets.Library.SimpleInput;
using Obvious.Soap;

namespace Assets.Library.DreamteckSplineControllers
{
    public class ViewRotator4SplineRunner : MonoBehaviour
    {
        IinputBridge input;
        [SerializeField] FloatReference ForwardSpeed;
        [SerializeField] FloatReference MaxRotation;
        [SerializeField] FloatReference RotationLerp;
        [SerializeField] bool RotateWhenIdle;

        // ISplineFollower followerModel;
        SplineFollower follower;
        float _LerpTarget;
        Vector3 _TempV3 = Vector3.zero;
        void Start()
        {
            input = GetComponent<IinputBridge>();
            follower = GetComponent<SplineFollower>();

        }
        void Update()
        {
            if (ForwardSpeed.Value != 0 && !RotateWhenIdle)
            {
                _TempV3 = follower.motion.rotationOffset;
                _LerpTarget = input.moveInput.x * MaxRotation.Value;
                _LerpTarget = Mathf.Clamp(_LerpTarget, -MaxRotation.Value, MaxRotation.Value);
                _TempV3.y = Mathf.Lerp(_TempV3.y, _LerpTarget, RotationLerp.Value * Time.deltaTime);
                follower.motion.rotationOffset = _TempV3;
            }
        }
    }
}