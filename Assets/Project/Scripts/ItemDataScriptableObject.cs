using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "NewItem")]
public class ItemDataScriptableObject : ScriptableObject
{
    public ItemData Data;
    public Sprite Sprite;
}