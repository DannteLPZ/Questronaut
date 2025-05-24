using TMPro;
using Unity.Cinemachine;
using UnityEngine;

namespace Questronaut.Environment
{
    public class ParallaxBackground : MonoBehaviour
    {
        [SerializeField] private Vector2 _parallaxMultipliers;
        [SerializeField] private float _smoothing = 1;

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

            CinemachineCore.CameraUpdatedEvent.AddListener(MoveBackground);
        }

        private void OnDestroy()
        {
            CinemachineCore.CameraUpdatedEvent.RemoveListener(MoveBackground);
        }

        //Update after cinemachine has finished executing
        private void MoveBackground(CinemachineBrain cinemachineBrain)
        {
            Vector3 moveDelta = _cameraTransform.position - _lastCameraPosition;
            transform.position += new Vector3(moveDelta.x * _parallaxMultipliers.x, moveDelta.y * _parallaxMultipliers.y);
            _lastCameraPosition = _cameraTransform.position;

            if(Mathf.Abs(_cameraTransform.position.x - transform.position.x) >= _spriteUnitSizeX)
            {
                float positionXOffset = (_cameraTransform.position.x - transform.position.x) % _spriteUnitSizeX;
                Vector2 newPositionX = new Vector2(_cameraTransform.position.x + positionXOffset, transform.position.y);
                
                transform.position = Vector2.Lerp(transform.position, newPositionX, _smoothing * Time.deltaTime);
            }

            if (Mathf.Abs(_cameraTransform.position.y - transform.position.y) >= _spriteUnitSizeY)
            {
                float positionYOffset = (_cameraTransform.position.y - transform.position.y) % _spriteUnitSizeY;
                Vector2 newPositionY = new Vector2(transform.position.x, _cameraTransform.position.y + positionYOffset);
                transform.position = Vector2.Lerp(transform.position, newPositionY, _smoothing * Time.deltaTime);
            }
        }
    }
}
