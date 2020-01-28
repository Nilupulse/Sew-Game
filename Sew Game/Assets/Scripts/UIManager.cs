using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Material lineMat;
    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NeedleColorSelect() 
    {
        AnimationHandler.Instance.NeedleColorPanelOpen();
    }
    public void SetNeedle(int colorID) 
    {
        AnimationHandler.Instance.NeedleColorPanelClose();
        DrawLine.Instance.SetColor(colorID);
        DrawLine.Instance.canDraw = true;

    }
}
