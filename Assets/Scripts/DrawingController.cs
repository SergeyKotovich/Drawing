using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class DrawingController : MonoBehaviour
{
   [SerializeField] private LineRenderer _lineRendererPrefab;
   
   private Color? _color;
   private LineRenderer _line;
   private bool _isDrawing;
   private List<LineRenderer> _lines = new();
   
   [UsedImplicitly]
   public void SelectedColor(Color color)
   {
      _color = color;
   }
   [UsedImplicitly]
   public void ClearBoard()
   {
      foreach (var lineRenderer in _lines)
      {
         Destroy(lineRenderer.gameObject);
      }
   }
   private void Update()
   {
      if (_color == null)
      {
         return;
      }
      if (!_isDrawing && Input.GetMouseButtonDown(0))
      {
         StartDrawing();
      }
      if (_isDrawing)
      {
         Drawing() ;
      }

      if (_isDrawing && Input.GetMouseButtonUp(0))
      {
         FinishDrawing();
      }
   }

   private void Drawing()
   {
      var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      if (!Physics.Raycast(ray, out var hitInfo))
      {
         return;
      }
      if (_line.positionCount > 0)
      {
         var lastPosition = _line.GetPosition(_line.positionCount - 1);
         if (Vector3.Distance(lastPosition, hitInfo.point) < 0.1)
         {
            return;
         }
      }

      _line.positionCount++;
      _line.SetPosition(_line.positionCount - 1, hitInfo.point);
   }


   private void StartDrawing()
   {
      _line = Instantiate(_lineRendererPrefab);
      _line.material.color = _color.Value;
      _line.sortingOrder = _lines.Count;
      _lines.Add(_line);
      _isDrawing = true;

   }

   private void FinishDrawing()
   {
      _isDrawing = false;
   }
   

   

    
}
