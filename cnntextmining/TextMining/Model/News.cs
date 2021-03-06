﻿using System;
using System.Collections.Generic;

namespace TextMining.Model
{
    [Serializable]
    public class News
    {
        public string topicUrl;
        public string url;
        public List<string> links = new List<string>();
        public List<string> words = new List<string>();
        public string rawData;
    }
}