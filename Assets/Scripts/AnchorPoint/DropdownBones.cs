using System;
using System.Collections;
using System.Collections.Generic;
using Avatar;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdownBones : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        foreach (EAvatarBones bone in (EAvatarBones[])Enum.GetValues(typeof(EAvatarBones)))
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(bone.ToString()));
        }
    }
}