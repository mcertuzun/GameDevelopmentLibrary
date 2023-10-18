using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using Assets.Library.SimpleInput;
using Obvious.Soap;

namespace Assets.Library.DreamteckSplineControllers
{
    public class HorizontalSplineFollowController : MonoBehaviour
    {

        [SerializeField] FloatReference HorizontalMovementLerp;
        [SerializeField] FloatReference HorizontalMovementSpeed;
        ISplineFollower followerModel;
        SplineFollower follower;

        float MovementLerp => HorizontalMovementLerp.Value;
        float MovementSpeed => HorizontalMovementSpeed.Value;

        IinputBridge _input;
        float _LerpTargetX;
        Vector2 _TempV2;

        void Start()
        {
            _input = GetComponent<IinputBridge>();
            followerModel = GetComponent<ISplineFollower>();
            follower = GetComponent<SplineFollower>();
            _LerpTargetX = follower.motion.offset.x;
        }

        void Update()
        {

            if (!followerModel.isStopped)
            {
                _TempV2 = follower.motion.offset;
                _LerpTargetX += _input.moveInput.x * Time.deltaTime * MovementSpeed;
                _LerpTargetX = Mathf.Clamp(_LerpTargetX, -followerModel.horizontalDistance, followerModel.horizontalDistance);
                _TempV2.x = Mathf.Lerp(_TempV2.x, _LerpTargetX, MovementLerp);
                // _TempV2.x = Mathf.Lerp(_TempV2.x, _LerpTargetX, 1);
                follower.motion.offset = _TempV2;
            }
        }
    }
}