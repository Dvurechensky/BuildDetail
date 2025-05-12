/*
 * Author: Nikolay Dvurechensky
 * Site: https://www.dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 12 мая 2025 12:24:39
 * Version: 1.0.
 */

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    /// <summary>
    /// РљРѕРЅС‚СЂРѕР»Р»РµСЂ СѓРїСЂР°РІР»РµРЅРёСЏ РѕС‚РѕР±СЂР°Р¶РµРЅРёРµРј СЃС‚Р°С‚СѓСЃР° РєР°РјРµСЂС‹
    /// </summary>
    public class StateCameraViewController : MonoBehaviour
    {
        private Text _text;
        
        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Update()
        {
            if(_text == null) return;
            
            if (FlyCameraController.ActiveMove)
                _text.text = "Move: <color='green'>Active</color>";
            else
                _text.text = "Move: <color='red'>Inactive</color>";
        }
    }
}