using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class ButtonSounds : MonoBehaviour, IPointerDownHandler
{
    [Serializable]
    public struct Rule
    {
        public string match;
        public SoundType sound;
        [Range(0f, 1f)] public float volume; // 0 = silent, 1 = loud
    }

    public List<Rule> rules = new List<Rule>();
    public bool caseInsensitive = true;
    public bool playFallbackIfNoRule = false;
    public SoundType fallbackSound;
    [Range(0f, 1f)] public float defaultVolume = 0.5f;

    Text label;
    string cachedLabel;

    [SerializeField, HideInInspector] private int _lastRuleCount = 0;

    void Awake()
    {
        label = GetComponentInChildren<Text>(true);

        for (int i = 0; i < rules.Count; i++)
        {
            if (rules[i].volume == 0f)
            {
                var r = rules[i];
                r.volume = defaultVolume;
                rules[i] = r;
            }
        }
    }

    void OnValidate()
    {
        if (defaultVolume == 0f) defaultVolume = 0.5f;

        if (rules != null)
        {
            if (rules.Count > _lastRuleCount)
            {
                for (int i = _lastRuleCount; i < rules.Count; i++)
                {
                    var r = rules[i];
                    if (r.volume == 0f) r.volume = defaultVolume;
                    rules[i] = r;
                }
            }
            _lastRuleCount = rules.Count;
        }
        else
        {
            _lastRuleCount = 0;
        }
    }

    public void OnPointerDown(PointerEventData e)
    {
        cachedLabel = label ? label.text : null;
    }

    public void PlayNow()
    {
        string text = string.IsNullOrEmpty(cachedLabel) ? (label ? label.text : null) : cachedLabel;
        var rule = Resolve(text);

        if (rule.HasValue)
            SoundManager.PlaySound(rule.Value.sound, rule.Value.volume);
        else if (playFallbackIfNoRule)
            SoundManager.PlaySound(fallbackSound, defaultVolume);

        cachedLabel = null;
    }

    Rule? Resolve(string text)
    {
        if (string.IsNullOrEmpty(text)) return null;
        var cmp = caseInsensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        text = text.Trim();
        foreach (var r in rules)
            if (!string.IsNullOrEmpty(r.match) && text.IndexOf(r.match.Trim(), cmp) >= 0)
                return r;
        return null;
    }
}