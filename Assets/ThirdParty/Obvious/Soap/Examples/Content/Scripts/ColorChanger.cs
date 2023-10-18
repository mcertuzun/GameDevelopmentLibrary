using UnityEngine;

namespace Obvious.Soap.Example
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private ColorVariable _colorVariable = null;
      
        private Renderer _renderer = null;
        
        private void Start()
        {
            _renderer = GetComponentInChildren<Renderer>();
            _colorVariable.OnValueChanged += OnColorChanged;
            OnColorChanged(_colorVariable.Value);
        }
        
        private void OnDestroy()
        {
            _colorVariable.OnValueChanged -= OnColorChanged;
        }
        
        private void OnColorChanged(Color newColor)
        {
            _renderer.material.color = newColor;
        }

    }
}