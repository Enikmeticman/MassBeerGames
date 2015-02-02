using System;
using UnityEngine;
using System.Collections;

/// <summary>
/// Instantiate a deck as gameobject
/// </summary>
public class DeckInstatiator : MonoBehaviour
{

    /// <summary>
    /// The game object all the decks need to be assigned to.
    /// </summary>
    public Transform DeckHolder = null;

    #region Singleton
    public static DeckInstatiator _Instance = null;

    public static DeckInstatiator Instance
    {
        get { return _Instance ?? (FindObjectOfType<DeckInstatiator>()); }
    }
    #endregion

    /// <summary>
    /// Returns a new deck.
    /// </summary>
    /// <param name="pDeckType">The type of deck we need</param>
    /// <returns></returns>
    public Deck Instatiate(Type pDeckType , Vector3 pPosition)
    {
        //System.Diagnostics.Debug.Assert((pDeckType.GetType() == typeof(Deck)));
        var selHolder = new GameObject("SelectionHolder");
        var sel = new GameObject("Selection", new Type[] {typeof(MeshFilter), typeof(MeshRenderer) });
        var cards = new GameObject("Cards", new Type[] {});
        var obj = new GameObject("Deck", new Type[] { pDeckType, typeof(BoxCollider)});

        selHolder.transform.parent = obj.transform;
        sel.transform.parent = selHolder.transform;
        cards.transform.parent = obj.transform;

        obj.transform.position = pPosition;
        obj.transform.parent = DeckHolder;

        //Set the leyer of the decck.
        obj.gameObject.layer = Layers.SelectField;

        return (obj.GetComponent<Deck>());
    }
}
