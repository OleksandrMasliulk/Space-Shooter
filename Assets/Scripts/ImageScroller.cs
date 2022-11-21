using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageScroller : MonoBehaviour
{
    [SerializeField] private Vector2 _scrollSpeed;

    private Image _image;
    private Material _material;

    private void Awake() 
    {
        _image = GetComponent<Image>();
    }

    private void Start() 
    {
        _material = new Material(_image.material.shader);
        _image.material = _material;
    }

    private void Update() 
    {
        Scroll();
    }

    private void Scroll()
    {
        Vector2 offset = _scrollSpeed * Time.deltaTime;
        _material.mainTextureOffset += offset;
    }
}
