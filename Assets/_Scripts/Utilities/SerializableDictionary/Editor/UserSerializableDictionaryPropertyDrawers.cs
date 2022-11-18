using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(IntFloatDictionary))]
[CustomPropertyDrawer(typeof(StringIntDictionary))]
[CustomPropertyDrawer(typeof(StringStringDictionary))]
[CustomPropertyDrawer(typeof(ObjectColorDictionary))]
[CustomPropertyDrawer(typeof(StringColorArrayDictionary))]
[CustomPropertyDrawer(typeof(StringAnimationClipDictionary))]
[CustomPropertyDrawer(typeof(StringAnimationClipArrayDictionary))]
[CustomPropertyDrawer(typeof(Vector2IntToIntDictionary))]
[CustomPropertyDrawer(typeof(Vector2IntToGameObject))]
[CustomPropertyDrawer(typeof(IntSpriteDictionary))]
[CustomPropertyDrawer(typeof(StatToFloatDictionary))]
public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer {}

[CustomPropertyDrawer(typeof(ColorArrayStorage))]
[CustomPropertyDrawer(typeof(AnimationClipStorage))]
public class AnySerializableDictionaryStoragePropertyDrawer: SerializableDictionaryStoragePropertyDrawer {}