using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExam1
{
    internal class Node
    {
        public Node(DefenceStrategies value)
        {
            Value = value;
        }

        public DefenceStrategies Value { get; set; }
        public Node? Left  { get; set; }
        public Node? Right { get; set; }
    }
}
