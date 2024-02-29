using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobInInventory : MonoBehaviour, IMouseOption
{

    private void OnEnable()
    {
        GetMouse.MouseClicked += OnMouseInt;
    }
    private void OnDisable()
    {
        GetMouse.MouseClicked -= OnMouseInt;
    }

    private void OnMouseInt(string arg1, Vector3 arg2, GameObject arg3)
    {
        if(arg1=="Inv")
        {
            Debug.Log("Seleccionado!");
        }    
    }

    public string Check()
    {
        return "Inv";
    }

    public int Order()
    {
        return 2;
    }
}
