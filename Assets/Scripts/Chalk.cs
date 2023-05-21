using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Chalk : MonoBehaviour
{
    [SerializeField] private DrawingController _drawingController;

    [UsedImplicitly]
    public void OnClick()
    {
        var color = GetComponent<Image>().color;
        _drawingController.SelectedColor(color);
    }
}