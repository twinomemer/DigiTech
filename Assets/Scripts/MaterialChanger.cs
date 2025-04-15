using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] private Multimeter multimeter; // Основная часть регулятора
    
    void Update() // Делаем материал дополнительной части регулятора таким же, как у основной
    {
        GetComponent<Renderer>().material = multimeter.GetComponent<Renderer>().material;
    }
}
