using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class RandomPile : Pile
{
    #region privates
    /// <summary>
    /// A List containing all the cards in the deck.
    /// </summary>
    private List<Card> _Cards = new List<Card>();
    #endregion

    #region Properties
    /// <summary>
    /// The id of the deck. /property/
    /// </summary>
    public new int PileId
    {
        get;
        private set;
    }

    /// <summary>
    /// The current deck size. /property/
    /// </summary>
    public new int Size
    {
        get
        {
            return _Cards.Count;
        }
    }
    #endregion

    #region public Functions

    public RandomPile()
    {
        PileId = Pile.PileInstances;
        ++Pile.PileInstances;

        SelectedChanged = OnSelectedChanged;
        HighLighted += OnHighLighted;
    }

    public override void Initialize(VisableCardStyle pShowMode, PickStyle pPickMode)
    {
        VisableCardStyle = pShowMode;
        PickStyle = pPickMode;
    }

    public override Card GetCard(string pCardName)
    {
        Card card = _Cards.FirstOrDefault(cardIndexed => cardIndexed.CardName == pCardName);

        if (card != null)
            _Cards.Remove(card);

        return card;
    }

    public override bool AddCard(Card pCard, int pIncex)
    {
        if (pIncex == 0)
        {
            if (_Cards.Count > 0)
                _Cards[0].Visable = false;

            pCard.Visable = true;
        }

        pCard.transform.position = this.transform.position;

        if (pIncex > _Cards.Count - 1)
            _Cards.Add(pCard);

        else
            _Cards.Insert(pIncex, pCard);


        return true;
    }

    public override void Klicked()
    {
        throw new System.NotImplementedException();
    }

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
    #endregion
}
