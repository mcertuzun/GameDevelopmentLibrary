using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Library.SimpleScripts
{
    public class Billboard : MonoBehaviour
    {
        public UnityEngine.Camera cam;
        void Start()
        {
            if (cam == null)
                cam = UnityEngine.Camera.main;
        }

        private void LateUpdate()
        {
            transform.LookAt(transform.position + cam.transform.forward);
        }
        // Update is called once per frame

    }
}