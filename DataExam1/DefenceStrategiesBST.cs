using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExam1
{
    internal class DefenceStrategiesBST
    {
        public Node? root;

        public void Insert(DefenceStrategies value)
        {
            root = RecursiveInsert(root, value);
        }
        private Node RecursiveInsert(Node? current, DefenceStrategies newValue)
        {
            if (current == null)
                return new Node(newValue);

            if (newValue == current.Value)
                return current;

            if (newValue < current.Value)
                current.Left = RecursiveInsert(current.Left, newValue);

            else if (newValue > current.Value)
                current.Right = RecursiveInsert(current.Right, newValue);

            return current;

        }
        public void InsertList(List<DefenceStrategies> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                Insert(list[i]);
            }
        }

        public void PreOrder() => PreOrderRecursive(root, "Root", 0);

        private void PreOrderRecursive(Node? current, string location, int depth)
        {
            if (current == null)
                return;

            Console.WriteLine(new string('-', depth) + location + current.Value.ToString());

            PreOrderRecursive(current.Left, "Left child", depth +1);
            PreOrderRecursive(current.Right, "Right child", depth + 1);
        }

        public DefenceStrategies SearchBySeverity(int severity) => SearchBySeverityRecursive(root, severity);

        private DefenceStrategies? SearchBySeverityRecursive(Node? current, int severity)
        {
            if (current == null)
                return null;
            if (severity >= current.Value.MinSeverity && severity <= current.Value.MaxSeverity)
                return current.Value;
  
            DefenceStrategies? leftResult = SearchBySeverityRecursive(current.Left, severity);
            if(leftResult != null)
                return leftResult;

            return SearchBySeverityRecursive(current.Right, severity);
        }
        public DefenceStrategies? FindMin() => FindMinRecursive(root);

        private DefenceStrategies? FindMinRecursive(Node? currrent)
        {
            if(currrent == null)
                return null;
            if(currrent.Left ==  null)
                return currrent.Value;

            return FindMinRecursive(currrent.Left);
        }

        public DefenceStrategies? FindMax() => FindMaxRecursive(root);

        private DefenceStrategies? FindMaxRecursive(Node? currrent)
        {
            if (currrent == null)
                return null;
            if (currrent.Right == null)
                return currrent.Value;

            return FindMaxRecursive(currrent.Right);
        }
    }
    
}
