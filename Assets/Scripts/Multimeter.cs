using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mathf = UnityEngine.Mathf;

public class Multimeter : MonoBehaviour
{
    [SerializeField] private float[] rotationAngles = { 0f, 53f, 133f, 228f, 307f }; // Углы положений регулятора
    
    [Header("Напряжение")]
    [SerializeField] private float resistance;
    
    [Header("Мощность")]
    [SerializeField] private float power;
    
    private int _currentPosition; // Текущее положение регулятора
    private bool _isHovered; // Флаг показывающий находится ли курсор на регуляторе
    private float _targetRotation; // Целевое положение регулятора
    private Material _originalMaterial; // Обычный материал регулятора
    
    public Material highlightMaterial; // Материал регулятора, когда на нём находится курсор
    
    private void Update()
    {
        if (_isHovered && Input.mouseScrollDelta.y != 0)
        {
            var direction = (int)Mathf.Sign(Input.mouseScrollDelta.y);
            SetPosition(direction);
        }
    }

    private void SetPosition(int direction)
    {
        _currentPosition += direction;
        
        if (_currentPosition >= rotationAngles.Length) _currentPosition = 0;
        else if (_currentPosition < 0) _currentPosition = rotationAngles.Length - 1;
        
        transform.localEulerAngles = new Vector3(0, rotationAngles[_currentPosition], 0);
        Debug.Log(_currentPosition);
    }

    public int GetPosition()
    {
        return _currentPosition;
    }

    public float GetResistance()
    {
        return resistance;
    }

    public float GetPower()
    {
        return power;
    }
    
    private void OnMouseEnter()
    {
        _isHovered = true;
        _originalMaterial = GetComponent<Renderer>().material;
        GetComponent<Renderer>().material = highlightMaterial;
    }

    private void OnMouseExit()
    {
        _isHovered = false;
        GetComponent<Renderer>().material = _originalMaterial;
    }
}