using System;
using System.Collections.Generic;

namespace SystemReport
{
    [Serializable]
    public class BodyCoordinates : Dictionary<int, float[]>
    {
        [Serializable]
        public class KeyValue
        {
            public int id;
            public float[] floats;

            public KeyValue(int id, float[] floats)
            {
                this.id = id;
                this.floats = floats;
            }
        }

        private const int BodyCoordinatesNumber = 16;

        public BodyCoordinates()
        {
            for (int i = 0; i <= BodyCoordinatesNumber; i += 1)
            {
                Add(new KeyValue(i, new float[] { 0, 0, 0 }));
            }
        }

        public void UpdateBodyCoordinates(KeyValue keyValue)
        {
            this[keyValue.id] = keyValue.floats;
        }

        public void Add(KeyValue keyValue)
        {
            Add(keyValue.id, keyValue.floats);
        }
    }
}