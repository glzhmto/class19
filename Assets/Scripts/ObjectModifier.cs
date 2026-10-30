using UnityEngine;

public class ObjectModifier : MonoBehaviour
{
    [Header("Referencias a Mallas (Arrastra desde Unity)")]
    public Mesh cubeMesh;
    public Mesh sphereMesh;
    public Mesh cylinderMesh;

    public enum ShapeType { Cube, Sphere, Cylinder }
    public enum ColorType { Red, Green, Blue }
    public enum SizeType { Small, Medium, Large }

    [Header("Estado Actual")]
    public ShapeType currentShape = ShapeType.Cube;
    public ColorType currentColor = ColorType.Red;
    public SizeType currentSize = SizeType.Medium;

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    private ShapeType startShape;
    private ColorType startColor;
    private SizeType startSize;
    private Quaternion startRotation;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        SaveOriginalState();
    }

    void SaveOriginalState()
    {
        startShape = currentShape;
        startColor = currentColor;
        startSize = currentSize;
        startRotation = transform.rotation;
    }

    public void ResetObject()
    {
        SetShape((int)startShape);
        SetColor((int)startColor);
        SetSize((int)startSize);
        transform.rotation = startRotation;
    }

    public void SetShape(int shapeIndex)
    {
        currentShape = (ShapeType)shapeIndex;
        if (shapeIndex == 0) meshFilter.mesh = cubeMesh;
        else if (shapeIndex == 1) meshFilter.mesh = sphereMesh;
        else if (shapeIndex == 2) meshFilter.mesh = cylinderMesh;
    }

    public void SetColor(int colorIndex)
    {
        currentColor = (ColorType)colorIndex;
        if (colorIndex == 0) meshRenderer.material.color = Color.red;
        else if (colorIndex == 1) meshRenderer.material.color = Color.green;
        else if (colorIndex == 2) meshRenderer.material.color = Color.blue;
    }

    public void SetSize(int sizeIndex)
    {
        currentSize = (SizeType)sizeIndex;
        if (sizeIndex == 0) transform.localScale = Vector3.one * 0.2f;
        else if (sizeIndex == 1) transform.localScale = Vector3.one * 0.75f;
        else if (sizeIndex == 2) transform.localScale = Vector3.one * 1.2f;
    }


    public void RotateX() { transform.Rotate(45, 0, 0, Space.World); }
    public void RotateY() { transform.Rotate(0, 45, 0, Space.World); }
    public void RotateZ() { transform.Rotate(0, 0, 45, Space.World); }
}