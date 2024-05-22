using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WhiteBoardMarkerScript : MonoBehaviour
{
    [SerializeField] private Transform _tip;
    [SerializeField] private int _penSize = 10;

    private Renderer _renderer;
    private Color[] _colors;
    private float _tipHeight;
    private RaycastHit _touch;
    private WhiteBoardScript _whiteboard;
    private Vector2 _touchPos, _lastTouchPos;
    private bool _touchedLastFrame;
    private Quaternion _lastTouchRot;
    private Color _initialWhiteboardColor;
    private bool _firstFrame = true;

    void Start()
    {
        _renderer = _tip.GetComponent<Renderer>();
        _renderer.material.color = Color.blue;
        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
        _tipHeight = _tip.localScale.y;

        // Get the whiteboard script and store its initial color
        _whiteboard = FindObjectOfType<WhiteBoardScript>();
        if (_whiteboard != null)
        {
            // Get the material attached to the whiteboard GameObject
            Renderer renderer = _whiteboard.GetComponent<Renderer>();
            if (renderer != null)
            {
                _initialWhiteboardColor = renderer.material.color;
                
            }
        }
        
        _whiteboard = null;
    }

    void Update()
    {
        Draw();
        if (_firstFrame)
        {
            ResetWhiteBoard();
        }
    }

    
 

    private void Draw()
    {
        if(Physics.Raycast(_tip.position, transform.up, out _touch))
        {
            Debug.Log("hit");
            if (_touch.transform.CompareTag("WhiteBoard"))
            {
                if (_whiteboard == null)
                {
                    _whiteboard = _touch.transform.GetComponent<WhiteBoardScript>();
                }

                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

                var x = (int)(_touchPos.x * _whiteboard.textureSize.x - (_penSize / 2));
                var y = (int)(_touchPos.y * _whiteboard.textureSize.y - (_penSize / 2));

                if (y < 0 || y > _whiteboard.textureSize.y || x < 0 || x > _whiteboard.textureSize.x)
                {
                    return;
                }

                if (_touchedLastFrame)
                {
                    _whiteboard.texture.SetPixels(x, y, _penSize, _penSize, _colors);

                    for(float f = 0.01f; f < 1.00f; f += 0.05f)
                    {
                        var lerpX = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                        var lerpY = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                        _whiteboard.texture.SetPixels(lerpX, lerpY, _penSize, _penSize, _colors);
                    }

                    transform.rotation = _lastTouchRot;

                    _whiteboard.texture.Apply();
                }

                _lastTouchPos = new Vector2(x, y);
                _lastTouchRot = transform.rotation;
                _touchedLastFrame = true;
                return;
            }
        }

        _whiteboard = null;
        _touchedLastFrame = false;
    }

    public void SetPenSize(float size)
    {
        // Ensure that _renderer and _colors are properly initialized
        if (_renderer == null || _colors == null)
        {
            Start();
        }

        
        _penSize = Mathf.RoundToInt((size * 30)+5);  // Scale slider value to pen size

        if (_initialWhiteboardColor != null)
        {
            if (_renderer.material.color == _initialWhiteboardColor)
            {
                _penSize = Mathf.RoundToInt((size * 100) + 50);  // Scale slider value to pen size
            }
        }
        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();  // Update color array
    }

    [ContextMenu("pensizezero")]
    public void SetPenSizeZero()
    {
        SetPenSize(0);
    }

    [ContextMenu("pensizehalf")]
    public void SetPenSizeHalf()
    {
        SetPenSize((float)0.5);
    }

    [ContextMenu("pensizeone")]
    public void SetPenSizeOne()
    {
        SetPenSize(1);
    }

    [ContextMenu("redcolor")]
    public void RedColor()
    {
        // Ensure that _renderer is properly initialized
        if (_renderer == null)
        {
            _renderer = _tip.GetComponent<Renderer>();
        }

        // Change the color of the renderer to red
        _renderer.material.color = Color.red;
        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
    }

    [ContextMenu("bluecolor")]
    public void BlueColor()
    {
        // Ensure that _renderer is properly initialized
        if (_renderer == null)
        {
            _renderer = _tip.GetComponent<Renderer>();
        }

        // Change the color of the renderer to blue
        _renderer.material.color = Color.blue;
        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
    }

    [ContextMenu("blackcolor")]
    public void BlackColor()
    {
        // Ensure that _renderer is properly initialized
        if (_renderer == null)
        {
            _renderer = _tip.GetComponent<Renderer>();
        }

        // Change the color of the renderer to black
        _renderer.material.color = Color.black;
        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
    }

    [ContextMenu("eraser")]
    public void eraser()
    {
        // Ensure that _renderer is properly initialized
        if (_renderer == null)
        {
            _renderer = _tip.GetComponent<Renderer>();
        }

        // Change the color of the renderer to the whiteboardcolor
        if(_initialWhiteboardColor != null)
        {
            _renderer.material.color = _initialWhiteboardColor;
        }


        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
    }

    [ContextMenu("resetwhiteboard")]
    public void ResetWhiteBoard()
    {
        _whiteboard = FindObjectOfType<WhiteBoardScript>();
        if (_whiteboard != null)
        {
            // Create an array of colors with each pixel set to _initialWhiteboardColor
            Color[] blankColors = Enumerable.Repeat(_initialWhiteboardColor, _whiteboard.texture.width * _whiteboard.texture.height).ToArray();

            // Set the pixels of the texture to the array of blank colors
            _whiteboard.texture.SetPixels(blankColors);

            // Apply the changes to the texture
            _whiteboard.texture.Apply();
        }
        _whiteboard = null;
        _firstFrame = false;
    }
}
