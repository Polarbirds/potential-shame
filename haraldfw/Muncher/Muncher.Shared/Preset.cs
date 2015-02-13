using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muncher.Shared
{
    class Preset
    {
        public readonly Dictionary<string, double> steps = new Dictionary<string,double>();
        public readonly Dictionary<string, double> bottoms = new Dictionary<string, double>();
        public readonly Dictionary<string, double> tops = new Dictionary<string, double>();
        public readonly Dictionary<string, double> baseVals = new Dictionary<string, double>();

        public void AddStat(string statname, double step, double bottom, double baseVal, double top) {
            steps.Add(statname, step);
            bottoms.Add(statname, bottom);
            tops.Add(statname, top);
            baseVals.Add(statname, baseVal);
        }

        public void RemoveStat(string statName)
        {
            steps.Remove(statName);
            bottoms.Remove(statName);
            tops.Remove(statName);
            baseVals.Remove(statName);
        }
    }
}
