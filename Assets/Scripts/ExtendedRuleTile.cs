using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class ExtendedRuleTile : RuleTile
{
    public List<TileBase> siblings = new List<TileBase>();

    public override bool RuleMatch(int neighbor, TileBase tile)
    {
        if (siblings.Contains(tile))
        {
            return base.RuleMatch(neighbor, this);
        }
        return base.RuleMatch(neighbor, tile);
    }
}
