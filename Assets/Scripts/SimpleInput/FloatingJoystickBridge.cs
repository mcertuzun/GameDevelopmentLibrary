using UnityEngine;

namespace Assets.Library.SimpleInput
{
    public class FloatingJoystickBridge : MonoBehaviour, IinputBridge
    {

        Assets.Library.Joystick.FloatingJoystick FJ;
        public Vector3 moveInput => FJ.Direction;

        public void setMinThreshhold(float value)
        {
            //throw new System.NotImplementedException();
        }

        // Start is called before the first frame update
        void Start()
        {
            FJ = FindObjectOfType<Assets.Library.Joystick.FloatingJoystick>();
        }

    }
}