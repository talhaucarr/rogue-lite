using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.StatSystem;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


[Serializable]
public class StatToFloatDictionary : SerializableDictionary<StatKey, float> { }


#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(StatToFloatDictionary))]
public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer {}



public class AnySerializableDictionaryStoragePropertyDrawer: SerializableDictionaryStoragePropertyDrawer {}

#endif 
