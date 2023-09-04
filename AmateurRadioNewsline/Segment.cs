using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmateurRadioNewsline
{
    public struct Segment
    {
        public TimeSpan start;
        public TimeSpan duration;
        public TimeSpan end { get { return start + duration; } }

        public override String ToString()
        {
            return $"{start:h\\:mm\\:ss\\.f} / {duration:mm\\:ss\\.fff}";
        }
    }
}
