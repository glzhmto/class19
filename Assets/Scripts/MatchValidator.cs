using UnityEngine;
using TMPro; 

public class MatchValidator : MonoBehaviour
{
    public ObjectModifier playerObject;
    
    [Header("Configuración del Objetivo Correcto")]
    public ObjectModifier.ShapeType targetShape;
    public ObjectModifier.ColorType targetColor;
    public ObjectModifier.SizeType targetSize;
    public Transform targetTransform; 

    [Header("UI Feedback")]
    public TextMeshProUGUI feedbackText;

    public void CheckMatch()
    {
        bool isShapeCorrect = playerObject.currentShape == targetShape;
        bool isColorCorrect = playerObject.currentColor == targetColor;
        bool isSizeCorrect = playerObject.currentSize == targetSize;

        float rotationDifference = Quaternion.Angle(playerObject.transform.rotation, targetTransform.rotation);
        
        bool isRotationCorrect = (rotationDifference < 30f) || (playerObject.currentShape == ObjectModifier.ShapeType.Sphere);

        if (isShapeCorrect && isColorCorrect && isSizeCorrect && isRotationCorrect)
        {
            feedbackText.text = "¡Correcto! Has igualado el objeto.";
            feedbackText.color = Color.green;
        }
        else
        {
            feedbackText.text = "Algo es incorrecto. Sigue intentándolo...";
            feedbackText.color = Color.yellow;
        }
    }
}