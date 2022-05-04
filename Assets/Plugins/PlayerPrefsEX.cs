using System;
using UnityEngine;

public class PlayerPrefsEX : PlayerPrefs
{
    #region BOOL
    static public bool GetBool(string key, bool defaultValue)
    {
        int def = 0;
        if (defaultValue)
            def = 1;
        return 1 == GetInt(key, def);
    }
    static public bool GetBool(string key)
    {
        return 1 == GetInt(key);
    }
    static public void SetBool(string key, bool value)
    {
        SetInt(key, Convert.ToInt32(value));
    }
    #endregion

    #region COLOR
    static public Color GetColor(string key, Color defaultValue)
    {
        Color color = defaultValue;
        ColorUtility.TryParseHtmlString(GetString(key, ColorUtility.ToHtmlStringRGBA(defaultValue)), out color);
        return  color;
    }
    static public Color GetColor(string key)
    {
        Color color;
        ColorUtility.TryParseHtmlString(GetString(key), out color);
        return color;
    }
    static public void SetColor(string key, Color value)
    {
        SetString(key, ColorUtility.ToHtmlStringRGBA(value));
    }
    #endregion
}
