using UnityEngine;
public class TextureArray : MonoBehaviour
{
    [SerializeField] private Texture2D[] textures;
    public Texture2D[] Textures { get => textures; set => textures = value; }
}