using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
    public RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void pointerDown()
    {
        rectTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
    public void pointerUp()
    {
        rectTransform.localScale = new Vector3(1, 1, 1);
    }
}
