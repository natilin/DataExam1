using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExam1
{
    internal class DefenceStrategies
    {
        public DefenceStrategies(int minSeverity, int maxSeverity, List<string> defenses)
        {
            MinSeverity = minSeverity;
            MaxSeverity = maxSeverity;
            Defenses = defenses;
        }

        public int MinSeverity {  get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses {  get; set; }

        public static bool operator <(DefenceStrategies ds1, DefenceStrategies ds2)
        {
            return ds1.MaxSeverity < ds2.MinSeverity;
        }
        public static bool operator >(DefenceStrategies ds1, DefenceStrategies ds2)
        {
            return ds1.MinSeverity > ds2.MaxSeverity;
        }

        public static bool operator ==(DefenceStrategies? ds1, DefenceStrategies? ds2)
        {
            if (ReferenceEquals(ds1, null) && ReferenceEquals(ds2, null))
            {
                return true;
            }
            if (ReferenceEquals(ds1, null) || ReferenceEquals(ds2, null))
            {
                return false;
            }

            return ds1.MinSeverity == ds2.MinSeverity && ds1.MaxSeverity == ds2.MaxSeverity;
        }

        public static bool operator !=(DefenceStrategies ds1, DefenceStrategies ds2)
        {
            if (ReferenceEquals(ds1, null) && ReferenceEquals(ds2, null))
            {
                return false;
            }
            if (ReferenceEquals(ds1, null) || ReferenceEquals(ds2, null))
            {
                return true;
            }

            return !(ds1.MinSeverity == ds2.MinSeverity && ds1.MaxSeverity == ds2.MaxSeverity);
        }

        public override string ToString()
        {
            return $"[{MinSeverity}-{MaxSeverity}] Defenses:" + string.Join(", ", Defenses);
        }
    }

}
