using UnityEngine;
using System.Collections;

/// <summary>
/// Instantiate a card as gameobject
/// </summary>
public class CardInstatiator : MonoBehaviour 
{
    /// <summary>
    /// The card prefab used for instantiating
    /// </summary>
    public Card PrefabCard = null;

    #region Singleton

    public static CardInstatiator _Instance = null;

    public static CardInstatiator Instance 
    {
        get { return _Instance ?? (FindObjectOfType<CardInstatiator>()); }
    }
    #endregion

    /// <summary>
    /// Returns a new card.
    ///  </summary>
    /// <returns></returns>
    public Card Instatiate(Vector3 pPosition)
    {
        var card = (Card)Instantiate(PrefabCard, pPosition, Quaternion.identity);
        System.Diagnostics.Debug.Assert(card != null);

        return card;
    }
}
