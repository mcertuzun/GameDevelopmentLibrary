using UnityEngine;

namespace Assets.Library.Controls
{
    public class ThirdPersonMovement : MonoBehaviour
    {
        public float speed, targetAngle, currentAngle;
        public Assets.Library.Joystick.Joystick stick;
        float Input_X;
        float Input_Y;
        private void Update()
        {


            Input_X = stick.Horizontal;
            Input_Y = stick.Vertical;
            if (stick.Horizontal == 0 && stick.Vertical == 0)
                return;

            transform.position += new Vector3(Input_X, 0, Input_Y) * Time.deltaTime * speed;
            targetAngle = Mathf.Atan2(Input_X, Input_Y) * Mathf.Rad2Deg;
        
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
        }
        
        public float AngleAbs(float ang)
        {
            if (ang < 0)
                return ang + 360;
            else
                return ang;

        }

    }
}