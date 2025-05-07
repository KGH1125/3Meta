using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiniBaseUI : MonoBehaviour
{
    protected MiniUIManager miniUIManager;
    public virtual void Init(MiniUIManager uiManager)
    {
        this.miniUIManager = uiManager;
    }
    protected abstract UIState GetUIState();
    public void SetActive(UIState state)
    {
        gameObject.SetActive(GetUIState() == state);
    }
}
