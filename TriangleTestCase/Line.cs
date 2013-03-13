using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriangleTestCase
{
    class Line
    {
        Random rand = new Random();

        public Line(int min, int max)
        {
            this.Min = min;
            this.Max = max;
            this.MinLess = GenerateMinLess(Min);
            this.MinGreater = GenerateMinGreater(Min);
            this.Middle = GenerateMiddle(Min, Max);
            this.MaxLess = GenerateMaxLess(Max);
            this.MaxGreater = GenerateMaxGreater(Max);
        }

        public int MinLess
        {
            get;
            set;
        }

        public int Min
        {
            get;
            set;
        }

        public int MinGreater
        {
            get;
            set;
        }

        public int Middle
        {
            get;
            set;
        }

        public int MaxLess
        {
            get;
            set;
        }

        public int Max
        {
            get;
            set;
        }

        public int MaxGreater
        {
            get;
            set;
        }

        private int GenerateMinLess(int min)
        {
            return min - 1;
        }

        private int GenerateMinGreater(int min)
        {
            return min + 1;
        }

        private int GenerateMiddle(int min, int max)
        {
            return min + rand.Next(1, max - min + 1);
        }

        private int GenerateMaxLess(int max)
        {
            return max - 1;
        }

        private int GenerateMaxGreater(int max)
        {
            return max + 1;
        }
    }

    
}
