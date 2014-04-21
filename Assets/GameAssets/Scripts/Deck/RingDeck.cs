using System;
using System.Collections.Generic;

public class RingDeck : IDeck
{
    #region privates
    /// <summary>
    /// Locks the deck after it is initialized, So that some data can't change anymore.
    /// </summary>
    private bool _Locked = false;

    /// <summary>
    /// A List containing all the cards in the deck.
    /// </summary>
    private Queue<Card> _Cards = new Queue<Card>();
    #endregion

    #region Properties
    /// <summary>
    /// The id of the deck. /property/
    /// </summary>
    public int DeckId
    {
        get;
        private set;
    }

    /// <summary>
    /// The current deck size. /property/
    /// </summary>
    public int Size
    {
        get
        {
            return _Cards.Count;
        }
    }
    #endregion

    #region public Functions

    /// <summary>
    /// Initializes the specified deck.
    /// </summary>
    /// <param name="pCards">The p cards.</param>
    /// <returns></returns>
    public InitializeSuccess Initialize(Card[] pCards)
    {
        if (_Locked) return InitializeSuccess.AlreadyInitialized;

        foreach (Card card in pCards)
        {
            _Cards.Enqueue(card);
        }

        return InitializeSuccess.Succeed;
    }


    /// <summary>
    /// Gets the next card from the deck.
    /// </summary>
    /// <param name="pCardName">Not used int a ring deck.</param>
    /// <returns>A Card null if no cards are left</returns>
    public Card GetCard(string pCardName)
    {
        if (_Cards.Count > 0)
            return _Cards.Dequeue();
        return null;
    }


    /// <summary>
    /// Adds a new card to the end of the deck.
    /// </summary>
    /// <param name="pCard">The card that needs to be added.</param>
    /// <param name="pIncex">Not used in a ring decj.</param>
    /// <returns>true if succeeded.</returns>
    public bool AddCard(Card pCard, int pIncex)
    {
        if (pCard != null && pCard.DeckId == DeckId)
            return false;

        _Cards.Enqueue(pCard);
        return true;
    }

    public void Shuffle()
    {

        Card[] cardArr = _Cards.ToArray();
        _Cards.Clear();

        Random rand = new Random();
        for (int i = cardArr.Length - 1; i > 0; i--)
        {
            int n = rand.Next(i + 1);
            Card temp = cardArr[i];
            cardArr[i] = cardArr[n];
            cardArr[n] = temp;

        }

        foreach (Card card in cardArr)
        {
            _Cards.Enqueue(card);
        }

        throw new System.NotImplementedException();
    }

    #endregion
}
