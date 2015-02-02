using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour
{

    public Selectable SelectedItem = null;

    #region Singleton

    public static Selector _Instance = null;

    public static Selector Instance
    {
        get { return _Instance ?? (FindObjectOfType<Selector>()); }
    }
    #endregion

    public Selectable Select(Selectable pSelect)
    {
        if (SelectedItem != null)
            SelectedItem.Unselect();

        SelectedItem = pSelect;
        return SelectedItem;
    }

    public void Unselect()
    {
        if (SelectedItem == null)
        {
            return;
        }

        SelectedItem.Unselect();
        SelectedItem = null;
    }
}
