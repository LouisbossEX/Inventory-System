using System.Collections.Generic;
using UnityEngine;

public class ItemSpriteFactory
{
    private readonly Dictionary<int, Sprite> sprites;
    
    public ItemSpriteFactory(Dictionary<int, Sprite> sprites)
    {
        this.sprites = sprites;
    }

    public Sprite GetSprite(int ID)
    {
        return sprites[ID];
    }
}