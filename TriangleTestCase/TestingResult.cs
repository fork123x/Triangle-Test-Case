using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriangleTestCase
{
    public class TestingResult
    {
        public TestingResult(int count, string line1, string line2, string line3, string result, string info)
        {
            this.Count = count;
            this.Line1 = line1;
            this.Line2 = line2;
            this.Line3 = line3;
            this.Result = result;
            this.Info = info;
        }

        public int Count
        {
            get;
            set;
        }

        public string Line1
        {
            get;
            set;
        }
        public string Line2
        {
            get;
            set;
        }
        public string Line3
        {
            get;
            set;
        }

        public string Result
        {
            get;
            set;
        }

        public string Info
        {
            get;
            set;
        }
    }
}
