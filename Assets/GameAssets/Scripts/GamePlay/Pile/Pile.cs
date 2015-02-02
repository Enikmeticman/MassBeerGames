using System;
using Assets.GameAssets.Scripts.GamePlay;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using System.Collections;

public abstract class Pile : Selectable 
{
    #region Properties
    /// <summary>
    /// Static deck instance
    /// </summary>
    protected static int PileInstances = 0;

    /// <summary>
    /// The id of the deck. /property/
    /// </summary>
    public int PileId { get; protected set; }

    /// <summary>
    /// The current deck size. /property/
    /// </summary>
    public int Size { get; protected set; }

    /// <summary>
    /// Determines how the cards are shown. /property/
    /// </summary>
    public VisableCardStyle VisableCardStyle { get; protected set; }

    /// <summary>
    /// Determines how the cards are picked. /property/
    /// </summary>
    public PickStyle PickStyle { get; protected set; }
    #endregion

    #region public Functions
    /// <summary>
    /// Initializes the pile
    /// </summary>
    public abstract void Initialize(VisableCardStyle pShowMode, PickStyle pPickMode);

    /// <summary>
    /// Gets a card from the pile.
    /// </summary>
    /// <param name="pCardName">Name of the card.</param>
    /// <returns>The card if found.</returns>
    public abstract Card GetCard(string pCardName);

    /// <summary>
    /// Add a card. 
    /// </summary>
    /// <param name="pCard">The card that needs to be added.</param>
    /// <param name="pIncex">The index where the new card needs to be.</param>
    /// <returns>true if succeeded.</returns>
    public abstract bool AddCard(Card pCard);

    /// <summary>
    /// Triggers when we click the card.
    /// </summary>
    public abstract void Klicked();

    /// <summary>
    /// Visualy select the pile
    /// </summary>
    protected void VisualSelect(bool pSelected)
    {
        transform.FindChild("SelectionHolder").FindChild("Selection").renderer.enabled = pSelected;
        StopCoroutine("GlowEffect");
        transform.FindChild("SelectionHolder").localScale = Vector3.one;
    }

    /// <summary>
    /// Visualy highlight the pile
    /// </summary>
    protected void VisualHighLight()
    {
        StartCoroutine("GlowEffect");
    }

    IEnumerator GlowEffect()
    {
        var select = transform.FindChild("SelectionHolder");
        bool expand = true;

        float expandValue;

        while (true)
        {
            expandValue = (expand) ? 1.08f : 1;

            var res = Vector3.Lerp(select.transform.localScale, new Vector3(expandValue, expandValue, expandValue), 0.15f);

            decimal x1 = Decimal.Round(new decimal(expandValue), 3); 
            decimal x2 = Decimal.Round(new decimal(res.x),3); 


            if (x1 == x2)
                expand = !expand;

            select.transform.localScale = res;

            yield return new WaitForEndOfFrame();
        }
    }

    #endregion
}
