using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBlock : MonoBehaviour
{
    MeshRenderer meshRenderer;
    [SerializeField]
    int tileHeight;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetTexture(string _fieldName, int _height)
    {
        switch (_height)
        {
            case 0:
            case 1:
            case 2:
                _height = Random.Range(1, 3);
                break;

            case 3:
            case 4:
                _height = Random.Range(2, 5);
                break;

            case 5:
            case 6:
            case 7:
                _height = Random.Range(4, 8);
                break;

        }
        Material material = Resources.Load<Material>("Material/Tile/" + _fieldName + "/" + _fieldName + "_" + _height);
        meshRenderer.material = material;

    }

}
