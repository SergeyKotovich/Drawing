using JetBrains.Annotations;
using UnityEngine;

public class Chalk : MonoBehaviour
{
    [SerializeField] private DrawingController _drawingController;
    [SerializeField] private Color _color;
    
    [UsedImplicitly]
    public void OnClick()
    {
        _drawingController.SelectedColor(_color);
    }
}