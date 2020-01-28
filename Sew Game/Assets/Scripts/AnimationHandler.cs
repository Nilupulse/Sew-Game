using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Animator needleColorPanelAnim;
    bool needleColorPanelOpen;

    public static AnimationHandler Instance;
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
    public void NeedleColorPanelOpen() 
    {
        needleColorPanelAnim.SetTrigger("NeedlePanelOpen");
    }
    public void NeedleColorPanelClose()
    {
        needleColorPanelAnim.SetTrigger("NeedlePanelClose");
    }
}
