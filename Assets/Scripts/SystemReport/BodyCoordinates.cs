using System;
using System.Collections.Generic;
using Avatar;
using UnityEngine;

namespace SystemReport
{
    [Serializable]
    public class BodyCoordinates : Dictionary<EAvatarBones, Vector3>
    {
        private static BodyCoordinates instance = null;

        [Serializable]
        public class KeyValue
        {
            public EAvatarBones boneId;
            public Vector3 position;

            public KeyValue(EAvatarBones boneId, Vector3 position)
            {
                this.boneId = boneId;
                this.position = position;
            }
        }

        private readonly Vector3 _defaultCoordinates = new(0, 0, 0);

        private BodyCoordinates()
        {
            foreach (EAvatarBones bone in (EAvatarBones[])Enum.GetValues(typeof(EAvatarBones)))
            {
                Add(new KeyValue(bone, _defaultCoordinates));
            } //end-foreach
        }

        public static BodyCoordinates getInstance()
        {
            if (instance == null)
                instance = new BodyCoordinates();

            return instance;
        }

        public void UpdateBodyCoordinates(KeyValue keyValue)
        {
            this[keyValue.boneId] = keyValue.position;
        }

        public Vector3 GetBodyCoordinates(EAvatarBones boneId)
        {
            return this[boneId];
        }

        public void Add(KeyValue keyValue)
        {
            Add(keyValue.boneId, keyValue.position);
        }
    }
}