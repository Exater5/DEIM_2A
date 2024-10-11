using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCreator : MonoBehaviour
{
    [SerializeField] private GameObject _spritePrefab;
    [SerializeField] private float _hDist, _vDist;
    [SerializeField] private int _raws, _columns;
    [SerializeField] private Vector2 _offset, _size;
    [SerializeField] private Color _startColor, _endColor;
    void Start()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        Vector2 startPoint = new Vector2(-width, -height)/2f;

        for (int i = 0; i < _columns; i++)
        {
            for (int j = 0; j < _raws; j++)
            {
                SpriteRenderer sr = Instantiate(_spritePrefab, new Vector2(_offset.x + startPoint.x + _hDist * i, _offset.y + startPoint.y + _vDist * j), Quaternion.identity).GetComponent<SpriteRenderer>();
                sr.color = Color.Lerp(_startColor, _endColor, (float)j/_raws);
                sr.transform.localScale = _size;
                sr.sortingOrder = j;
                if (i%2 == 0)
                {
                    sr.transform.position += Vector3.up * (_vDist / 2f);
                }
            }
        }
    }
}
