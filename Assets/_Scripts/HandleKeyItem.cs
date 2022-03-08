using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HandleKeyItem : MonoBehaviour
{
    public enum Key_item_expected {estrela, quadrado, circulo, triangulo};
    public bool has_key = false;

    public Key_item_expected key_item; 
}