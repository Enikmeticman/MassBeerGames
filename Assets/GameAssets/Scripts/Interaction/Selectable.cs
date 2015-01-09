using System;
using UnityEngine;

/// <summary>
/// A card in memory.
/// </summary>
public abstract class Selectable : MonoBehaviour
{
    public bool IsSelected { get; private set; }
    public bool IsHighLighted { get; private set; }
    
    public delegate void SeletionChangedHandler (bool pSelected);
    public delegate void HighLightedHandler();

    public SeletionChangedHandler SelectedChanged = null;
    public HighLightedHandler HighLighted = null;

    public void Select()
    {
        if (Selector.Instance.SelectedItem != this)
        {
            Selector.Instance.Select(this);

            IsSelected = true;
            SeletionChangedHandler ev = SelectedChanged;
            if (ev != null)
                ev(IsSelected);
        }
    }

    public void Unselect()
    {
        IsSelected = false;
        IsHighLighted = false;

        SeletionChangedHandler ev = SelectedChanged;
        if (ev != null)
            ev(IsSelected);
    }

    public void HighLight()
    {
        if (IsSelected && !IsHighLighted)
        {
            IsHighLighted = true;
            HighLightedHandler ev = HighLighted;
            if (ev != null)
                ev();
        }

    }
}