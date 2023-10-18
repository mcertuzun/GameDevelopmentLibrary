using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Library.SimpleScripts
{
    public class SmoothBillboard : MonoBehaviour
    {
        public UnityEngine.Camera cam;
        public float TimePassed, rotateTime;
        public Vector3 smoothingVelocity;
        public Quaternion current, target;
        public bool started;

        void Start()
        {
            if (cam == null)
                cam = UnityEngine.Camera.main;

            current = transform.rotation;
            transform.LookAt(transform.position - cam.transform.forward);
            target = transform.rotation;
            transform.rotation = current;




        }

        private void LateUpdate()
        {
            if (started)
            {
                transform.rotation = Quaternion.Slerp(current, target, TimePassed / rotateTime);
                TimePassed += Time.deltaTime;

                started = TimePassed < rotateTime;

            }
        }
        public void start()
        {
            started = true;

        }
        // Update is called once per frame

    }
}