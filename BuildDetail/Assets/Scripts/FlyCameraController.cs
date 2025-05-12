/*
 * Author: Nikolay Dvurechensky
 * Site: https://www.dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 12 мая 2025 12:24:39
 * Version: 1.0.
 */

using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// РљРѕРЅС‚СЂРѕР»Р»РµСЂ СѓРїСЂР°РІР»РµРЅРёСЏ РєР°РјРµСЂРѕР№
    /// </summary>
    public class FlyCameraController : MonoBehaviour
    {
        [SerializeField] private float mouseSensitivity = 3.0f;
        [SerializeField] private float speed = 2.0f;
        [SerializeField] private float minimumX = -360F;
        [SerializeField] private float maximumX = 360F;
        [SerializeField] private float minimumY = -60F;
        [SerializeField] private float maximumY = 60F;
        
        private Vector3 _transfer;
        private float _rotationX = 0F; 
        private float _rotationY = 0F;
        private Quaternion _originalRotation;
        private Camera _camera;
        
        public static bool ActiveMove { get; private set; }

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            if(_camera == null) return;
            
            _camera.orthographic = false;
        }

        private void Start()
        {
            _originalRotation = transform.rotation;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                ActiveMove = !ActiveMove;

            if (ActiveMove)
            {
                _rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
                _rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
                
                _rotationX = ClampAngle(_rotationX, minimumX, maximumX);
                _rotationY = ClampAngle(_rotationY, minimumY, maximumY);
                
                Quaternion xQuaternion = Quaternion.AngleAxis(_rotationX, Vector3.up);
                Quaternion yQuaternion = Quaternion.AngleAxis(_rotationY, Vector3.left);
                
                transform.rotation = _originalRotation * xQuaternion * yQuaternion;
                
                _transfer = transform.forward * Input.GetAxis("Vertical");
                _transfer += transform.right * Input.GetAxis("Horizontal");
                
                transform.position += _transfer * (speed * Time.deltaTime);
            }
        }

        /// <summary>
        /// РџСЂРѕСЃС‡РµС‚ СѓРіР»Р°
        /// </summary>
        /// <param name="value">РћРіСЂР°РЅРёС‡РёРІР°РµРјРѕРµ Р·РЅР°С‡РµРЅРёРµ.</param>
        /// <param name="min">РќРёР¶РЅСЏСЏ РіСЂР°РЅРёС†Р° СЂРµР·СѓР»СЊС‚Р°С‚Р°.</param>
        /// <param name="max">Р’РµСЂС…РЅСЏСЏ РіСЂР°РЅРёС†Р° СЂРµР·СѓР»СЊС‚Р°С‚Р°.</param>
        /// <returns>value, РѕРіСЂР°РЅРёС‡РµРЅРЅРѕРµ РґРёР°РїР°Р·РѕРЅРѕРј РѕС‚ min РґРѕ max</returns>
        private float ClampAngle(float value, float min, float max)
        {
            if (value < -360F) value += 360F;
            if (value > 360F) value -= 360F;
            return Mathf.Clamp(value, min, max);
        }
    }
}
