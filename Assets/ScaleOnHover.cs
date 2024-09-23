using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnHover : MonoBehaviour
{

    private void OnMouseEnter()
    {
        IncreaseScale(true);
    }

    private void OnMouseExit()
    {
        IncreaseScale(false); 
    }

    private Vector3 initialScale;

    private void Awake()
    {
        initialScale = transform.localScale;
    }

    private void IncreaseScale(bool status)
    {
        Vector3 finalScale = initialScale;

        if (status)
        {
            finalScale = initialScale * 1.1f;
            transform.localScale = finalScale;
        }   
        else
        {
            transform.localScale = initialScale;
        }
    }
}
