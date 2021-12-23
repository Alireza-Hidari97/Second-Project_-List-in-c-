using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MedalApp
{

    enum MedalColor
    {
        Bronze,
        Silver,
        Gold
    }
    [Serializable]
    class Medal
    {   [JsonInclude]
        public string Name { get; }
        [JsonInclude]
        public string TheEvent { get; }
        [JsonInclude]
        public MedalColor Color { get; }
        [JsonInclude]
        public int Year { get; }
        [JsonInclude]
        public bool IsRecord { get; }
        

        //constructor
        public Medal(string name, 
            string theEvent, 
            MedalColor color, 
            int year, 
            bool isRecord)
        {
            Name = name;
            TheEvent = theEvent;
            Color = color;
            Year = year;
            IsRecord = isRecord;
        }

        public override string ToString()
        {
            return $"{Year} - {TheEvent}{(IsRecord ? "(R)" : "")} {Name}({Color})";
        }
        public Medal()
        { 
        }
    }
}
