/*
 * Author: Nikolay Dvurechensky
 * Site: https://www.dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 12 мая 2025 12:24:39
 * Version: 1.0.
 */

using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// РљРѕРЅС‚СЂРѕР»Р»РµСЂ СѓРїСЂР°РІР»РµРЅРёСЏ СЃС‚СЂРѕРёС‚РµР»СЊСЃС‚РІРѕРј РѕР±СЉРµРєС‚Р°
/// </summary>
public class BuildController : MonoBehaviour
{
    [SerializeField] private List<GameObject> details;
    
    private Coroutine _moveDetailsCoroutine;
    private Button _buildBtn;
    
    private void Awake()
    {
        _buildBtn = GetComponent<Button>();
        if(_buildBtn == null) return;
        
        _buildBtn.onClick.AddListener(MoveAction);
    }

    private void MoveAction()
    {
        _moveDetailsCoroutine ??= StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        for (int i = 0; i < details.Count; i++)
        {
            if(details[i].name == "Bolt")
                yield return MoveObject(details[i]);
            if (details[i].name == "Screw")
                yield return MoveObject(details[i]);
            if (details[i].name == "Detail_1")
                yield return MoveObject(details[i]);
            if (details[i].name == "Detail_2")
                yield return MoveObject(details[i]);
            if (details[i].name == "Washer")
                yield return MoveObject(details[i]);
            yield return null;
        }

        _moveDetailsCoroutine = null;
    }

    private IEnumerator MoveObject(GameObject bGameObject)
    {
        if(bGameObject == null) yield break;
        
        yield return bGameObject.GetComponent<MovePosition>().EnableMove = true;
        Debug.Log($"Move: {bGameObject.transform.name}");
    }
}
