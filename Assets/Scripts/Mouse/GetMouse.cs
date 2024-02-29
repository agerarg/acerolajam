using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GetMouse : MonoBehaviour
{
    public static Action<string, Vector3, GameObject> MouseClicked;

    public void Get()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, 100.0F);
        IMouseOption mo;

        List<MouseAndOptions> options = new();
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            mo = hit.transform.gameObject.GetComponent<IMouseOption>();
            if(mo!=null)
            {
                MouseAndOptions newOp = new();
                newOp.mouseOption = mo;
                newOp.gameObject = hit.transform.gameObject;
                newOp.position = hit.point;
                options.Add(newOp);
            }
        }

        if(options.Count==1)
        {
            MouseClicked?.Invoke(options[0].mouseOption.Check(), options[0].position, options[0].gameObject);
        }
        if (options.Count > 1)
        {
            int order = 0;
            MouseAndOptions selected = null;
            foreach (MouseAndOptions mao in options)
            {
                if(mao.mouseOption.Order()> order)
                {
                    order = mao.mouseOption.Order();
                    selected = mao;
                }
            }
            if(selected != null)
                MouseClicked?.Invoke(selected.mouseOption.Check(), selected.position, selected.gameObject);
        }

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Get();
        }
    }
}


