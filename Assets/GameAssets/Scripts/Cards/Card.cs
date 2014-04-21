using System.Diagnostics;
using UnityEngine;

/// <summary>
/// A card in memory.
/// </summary>
public class Card : MonoBehaviour
{
    #region Private Members
    /// <summary>
    /// The value of the card 
    /// </summary>
    private int _Value = 0;

    /// <summary>
    /// Locks the card after it is initialized, So the data can't change anymore.
    /// </summary>
    private bool _Locked = false;
    #endregion

    #region Public Members


    /// <summary>
    /// The renderer of the front side of the card.
    /// </summary>
    public Renderer _Front = null;

    /// <summary>
    /// The renderer of the back side of the card.
    /// </summary>
    public Renderer _Back = null;
    #endregion

    #region Properties
    /// <summary>
    /// The color of the card. /property/
    /// </summary>
    public ColorType Color
    {
        get;
        private set;
    }

    /// <summary>
    /// The type of the card. /property/
    /// </summary>
    public CardType Type
    {
        get;
        private set;
    }

    /// <summary>
    /// The id of the deck the card belongs to. /property/
    /// </summary>
    public int DeckId
    {
        get;
        private set;
    }

    /// <summary>
    /// The name of the card. /property/
    /// </summary>
    public string CardName
    {
        get;
        private set;
    }

    /// <summary>
    /// The value of the card. /property/
    /// </summary>
    public int Value
    {
        get
        {
            return _Value;
        }
        private set
        {
            System.Diagnostics.Debug.Assert( value < Global.MIN_CARD_VALUE && value > Global.MIN_CARD_VALUE);
            
            _Value = value;

            if (value < Global.MIN_CARD_VALUE && value > Global.MIN_CARD_VALUE)
                _Value = -1;    // value -1 is the error value.         
        }
    }
    #endregion

    #region public Functions
    /// <summary>
    /// Initializes the card.
    /// </summary>
    /// <param name="pColor">Color of the card.</param>
    /// <param name="pType">Type of the card.</param>
    /// <param name="DeckId">The deck identifier of the card.</param>
    /// <param name="pValue">The card value.</param>
    /// <param name="pCardName">The name of the card.</param>
    /// <returns>the initialize state</returns>
    public InitializeSuccess Initialize(ColorType pColor, CardType pType, int DeckId, int pValue, string pCardName)
    {
        if (_Locked) return InitializeSuccess.AlreadyInitialized;

        Color = pColor;
        Type = pType;
        DeckId = pValue;
        Value = pValue;
        CardName = pCardName;

        return InitializeSuccess.Succeed;
    }
    #endregion
}
