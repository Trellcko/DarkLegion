using System.Collections.Generic;
using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    [SerializeField] private GameObject _dot;

    private List<GameObject> _dots = new List<GameObject>();
    private List<SpriteRenderer> _dotsSpritesCashed = new List<SpriteRenderer>();

    public void Draw(Vector3[] positions)
    {
        HideDots();
        for(int i = 0; i < positions.Length; i++)
        {
            if(_dots.Count <= i )
            {
                _dots.Add(Instantiate(_dot, transform));
                _dotsSpritesCashed.Add(_dots[i].GetComponent<SpriteRenderer>());
            }
            _dotsSpritesCashed[i].enabled = true;
            _dots[i].transform.position = positions[i];
        }
    }

    private void HideDots()
    {
        foreach(var spriteRender in _dotsSpritesCashed)
        {
            spriteRender.enabled = false;
        }
    }

}
