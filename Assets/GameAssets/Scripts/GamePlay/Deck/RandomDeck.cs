using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class RandomDeck : Deck
{
    #region privates
    /// <summary>
    /// Locks the deck after it is initialized, So that some data can't change anymore.
    /// </summary>
    private bool _Locked = false;

    /// <summary>
    /// A List containing all the cards in the deck.
    /// </summary>
    private List<Card> _Cards = new List<Card>();
    #endregion

    #region Properties
    /// <summary>
    /// The current deck size. /property/
    /// </summary>
    public override int Size
    {
        get
        {
            return _Cards.Count;
        }
    }
    #endregion
    /// <summary>
    /// Constructor
    /// </summary>
    public RandomDeck()
    {
        DeckId = Deck.DeckInstances;
        ++Deck.DeckInstances;

        SelectedChanged = OnSelectedChanged; 
        HighLighted += OnHighLighted;
    }

    #region public Functions
    /// <summary>
    /// Initializes the specified deck.
    /// </summary>
    /// <param name="pCards">The p cards.</param>
    /// <returns></returns>
    public override InitializeSuccess Initialize(Card[] pCards)
    {
        if (_Locked) return InitializeSuccess.AlreadyInitialized;

        foreach (Card card in pCards)
        {
            _Cards.Add(card);
        }

        return InitializeSuccess.Succeed;
    }

    /// <summary>
    /// Gets a card from the deck.
    /// </summary>
    /// <param name="pCardName">Name of the card.</param>
    /// <returns>The card if found.</returns>
    public override Card GetCard(string pCardName)
    {

        Card card = _Cards.FirstOrDefault(cardIndexed => cardIndexed.CardName == pCardName);

        if (card != null)
            _Cards.Remove(card);

        return card;

    }

    /// <summary>
    /// Add a card. 
    /// </summary>
    /// <param name="pCard">The card that needs to be added.</param>
    /// <param name="pIncex">The index where the new card needs to be.</param>
    /// <returns>true if succeeded.</returns>
    public override bool AddCard(Card pCard, int pIncex)
    {

       if(pIncex > _Cards.Count -1 )
           _Cards.Add(pCard);

       else 
           _Cards.Insert(pIncex, pCard);


        return true;
    }

    public override void Shuffle()
    {
        if (_Cards.Count < 2) return;

        _Cards[0].Visable = false;

        Random rand = new Random();
        for (int i = _Cards.Count - 1; i > 0; i--)
        {
            int n = rand.Next(i + 1);
            Card temp = _Cards[i];
            _Cards[i] = _Cards[n];
            _Cards[n] = temp;

        }

        _Cards[0].Visable = true;
    }

    public override void Klicked()
    {

    }
    #endregion

    #region private Functions
    private void OnSelectedChanged(bool pSelected)
    {
        VisualSelect(pSelected);
    }

    private void OnHighLighted()
    {
        VisualHighLight();
    }
    #endregion
}

