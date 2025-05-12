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
    /// РџРµСЂРµРјРµС‰РµРЅРёРµ РѕР±СЉРµРєС‚Р° РІ РїРѕР·РёС†РёСЋ X, Y, Z
    /// </summary>
    public class MovePosition : MonoBehaviour
    {
        [SerializeField] private float x;
        [SerializeField] private float y;
        [SerializeField] private float z;
        [Space(10)]
        [SerializeField] private float speedMove;
        public bool EnableMove { get; set; }

        private void Update()
        {
            if(EnableMove)
                transform.position = Vector3.Lerp(transform.position, new Vector3(x, y, z), Time.deltaTime * speedMove);
        }

        private void OnMouseDown()
        {
            EnableMove = !EnableMove;
        }
    }
}
