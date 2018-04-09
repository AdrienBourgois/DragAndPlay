using System;
using UnityEngine;
using System.Collections.Generic;

namespace Song
{
    public class SongEvent
    {

    }

    [Serializable]
    [CreateAssetMenu(order = 0, fileName = "New Song", menuName = "Create New Song")]
    public class Song : ScriptableObject
    {
        public int Bpm;
        public string Name = "Song Name";
        public TextAsset File;

        private List<SongEvent> events;
        private int currentEvent = -1;

        public SongEvent NextEvent => events[++currentEvent];
    }
}
