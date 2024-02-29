using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLand : MonoBehaviour, IMouseOption
{
    public string Check()
    {
        return "Land";
    }

    public int Order()
    {
        return 1;
    }
}
