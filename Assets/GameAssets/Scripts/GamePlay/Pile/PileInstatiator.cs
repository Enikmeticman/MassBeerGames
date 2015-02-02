using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

/// <summary>
/// Instantiate a pile as gameobject
/// </summary>
public class PileInstatiator : MonoBehaviour 
{
    /// <summary>
    /// The game object all the piles need to be assigned to.
    /// </summary>
    public Transform PileHolder = null;

    #region Singleton
    public static PileInstatiator _Instance = null;

    public static PileInstatiator Instance
    {
        get { return _Instance ?? (FindObjectOfType<PileInstatiator>()); }
    }
    #endregion

    /// <summary>
    /// Returns a new deck.
    /// </summary>
    /// <param name="pDeckType">The type of deck we need</param>
    /// <returns></returns>
    public Pile Instatiate(PileType pPile, Vector3 pPosition)
    {
        var obj = (GameObject)Instantiate(PrefabContainer.Instance.GetPrefab(PrefabContainer.Prefabs.Pile), pPosition, Quaternion.identity);
        System.Diagnostics.Debug.Assert(obj != null);

        Pile pile = null;

        switch (pPile)
        {
            case PileType.Random:
                pile = obj.AddComponent<RandomPile>();
                break;
            case PileType.Stack:
                pile = obj.AddComponent<StackPile>();
                break;
        }

        if (pile != null)
        {
           pile.transform.parent = PileHolder;
            return pile; 
        }

        System.Diagnostics.Debug.Assert(false);
        return null;
    }
}
