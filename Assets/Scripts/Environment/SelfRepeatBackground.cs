using UnityEngine;

namespace Questronaut.Environment
{
    public class SelfRepeatBackground : MonoBehaviour
    {
        [SerializeField] private Vector2 _moveSpeed;

        private Transform _cameraTransform;
        private Vector3 _lastCameraPosition;

        private float _spriteUnitSizeX;
        private float _spriteUnitSizeY;

        private void Start()
        {
            _cameraTransform = Camera.main.transform;
            _lastCameraPosition = _cameraTransform.position;
            Sprite sprite = GetComponent<SpriteRenderer>().sprite;
            Texture2D texture = sprite.texture;
            _spriteUnitSizeX = texture.width / sprite.pixelsPerUnit;
            _spriteUnitSizeY = texture.height / sprite.pixelsPerUnit;

            transform.position = (Vector2)_cameraTransform.position;
        }


        //Update after cinemachine has finished executing
        private void Update()
        {
            transform.position += (Vector3)_moveSpeed * Time.deltaTime;
        }

        private void LateUpdate()
        {
            Vector3 moveDelta = _cameraTransform.position - _lastCameraPosition;
            _lastCameraPosition = _cameraTransform.position;

            if (Mathf.Abs(_cameraTransform.position.x - transform.position.x) >= _spriteUnitSizeX)
            {
                float positionXOffset = (_cameraTransform.position.x - transform.position.x) % _spriteUnitSizeX;
                Vector2 newPositionX = new Vector2(_cameraTransform.position.x + positionXOffset, transform.position.y);

                transform.position = newPositionX;
            }

            if (Mathf.Abs(_cameraTransform.position.y - transform.position.y) >= _spriteUnitSizeY)
            {
                float positionYOffset = (_cameraTransform.position.y - transform.position.y) % _spriteUnitSizeY;
                Vector2 newPositionY = new Vector2(transform.position.x, _cameraTransform.position.y + positionYOffset);
                transform.position = newPositionY;
            }
        }
    }
}
