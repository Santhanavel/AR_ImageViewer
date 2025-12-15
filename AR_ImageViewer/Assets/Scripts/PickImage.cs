using UnityEngine;
using UnityEngine.UI;

public class PickImage : MonoBehaviour
{
    [Header("UI Target")]
    public RawImage previewImage;   // OR Renderer for 3D object

    public void SelectImage()
    {
        // Request image from gallery
        NativeGallery.GetImageFromGallery((path) =>
        {
            if (string.IsNullOrEmpty(path))
            {
                Debug.Log("Image selection cancelled");
                return;
            }

            Debug.Log("Selected image path: " + path);

            // Load image as texture
            Texture2D texture = NativeGallery.LoadImageAtPath(path, 1024);

            if (texture == null)
            {
                Debug.LogError("Failed to load image");
                return;
            }

            // Show image in UI
            previewImage.texture = texture;
        },
        "Select an image",
        "image/*");
    }
}