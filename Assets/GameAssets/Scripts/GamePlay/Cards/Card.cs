using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// A card in memory.
/// </summary>
public class Card : Selectable
{
    #region Private Members
    /// <summary>
    /// Wheter the card is faced down.
    /// </summary>
    private bool _FaceDown = false;

    /// <summary>
    /// The value of the card 
    /// </summary>
    private int _Value = 0;

    /// <summary>
    /// Locks the card after it is initialized, So the data can't change anymore.
    /// </summary>
    private bool _Locked = false;

    /// <summary>
    /// Represents het colloder from the card.
    /// </summary>
    private BoxCollider _Collider = null;
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
    public CardType TypeOfCard
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
    /// Set the card visable. /property/
    /// </summary>
    private bool _Visable = true;
    public bool Visable
    {
        get { return _Visable; }
        set
        {
            _Visable = value;

            _Front.renderer.enabled = _Visable;
            _Back.renderer.enabled = _Visable;

        }
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
    public InitializeSuccess Initialize(ColorType pColor, CardType pType, int pDeckId, int pValue)
    {
        if (_Locked) return InitializeSuccess.AlreadyInitialized;

        Color = pColor;
        TypeOfCard = pType;
        DeckId = pDeckId;
        Value = pValue;
        CardName = RenameCard();

        LoadImages();

        return InitializeSuccess.Succeed;
    }

    public void Flip()
    {
        _Front.transform.Rotate(new Vector3(180, 0, 0));
        _Back.transform.Rotate(new Vector3(180, 0, 0));
        _FaceDown = !_FaceDown;
    }

    public void FastFlip()
    {
        transform.Rotate(new Vector3(180,0,0));
        _FaceDown = !_FaceDown;
    }
    #endregion

    #region private functions
    //Constructor
    private void Start()
    {
        _Collider = GetComponent<BoxCollider>();
        _Collider.enabled = false;
    }

    /// <summary>
    /// Load the image from the resources
    /// </summary>
    private void LoadImages()
    {
        var folder = CardName.Substring(0, CardName.IndexOf('_'));

        Texture textureFront = null;
        
        if(!CardName.Contains("W"))
            textureFront = Resources.Load(string.Format("Textures/Cards/{0}/{1}", folder, CardName)) as Texture;
        else
            textureFront = Resources.Load(string.Format("Textures/Cards/WildCard")) as Texture;

        var textureBack = Resources.Load(string.Format("Textures/Cards/Back")) as Texture;

        _Front.material.mainTexture = textureFront;
        _Back.material.mainTexture = textureBack;
    }

    /// <summary>
    /// Helper to name the card.
    /// </summary>
    /// <returns>The new card name</returns>
    private string RenameCard()
    {
        string val = string.Empty;

        switch (Value)
        {
            case 11:
                val = "J";
                break;
            case 12:
                val = "Q";
                break;
            case 13:
                val = "K";
                break;
            case 14:
                val = "A";
                break;
            case 15:
                val = "W";
                break;
            default:
                val = Value.ToString();
                break;

        }

        name = String.Format("{0}_{1}", TypeOfCard.ToString(), val);
        return name;
    }
    #endregion
}
