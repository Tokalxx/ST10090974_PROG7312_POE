using PROG7312_UI.DataTree;
using System;
using System.Collections.Generic;
using System.IO;

namespace PROG7312_UI.Core
{
    public class FindingCallNumber
    {
        private static readonly FindingCallNumber _instance = new FindingCallNumber();
        string filePath = @"DDS.txt";
        CallNumberTree cnt = new CallNumberTree(new CallNumberNode("0", ".", null));
        Random ran1 = new Random();


        private FindingCallNumber()
        {
            genTree(filePath, cnt);
        }

        /// <summary>
        /// Creates the instance for this class
        /// </summary>
        /// <returns></returns>
        public static FindingCallNumber GetInstance()
        {
            return _instance;
        }

        /// <summary>
        /// Returns the instance of this class
        /// </summary>
        /// <returns>CallNumberTree cnt</returns>
        public CallNumberTree GetTree()
        {
            return cnt;
        }

        /// <summary>
        /// Method generates the 1st question in the problem
        /// </summary>
        /// <param name="node"></param>
        /// <returns>List<CallNumberNode> tempList</returns>
        public List<CallNumberNode> genQuestion1(CallNumberNode node)
        {
            int level1 = Convert.ToInt32(node.Parent.Parent.Num.Substring(0, 1));
            CallNumberNode tempCallNum = cnt.Root.Children[level1];
            List<CallNumberNode> tempList = new List<CallNumberNode>();
            tempList.Add(tempCallNum);

            for (int i = 0; i < 3; ++i)
            {
                CallNumberNode tempAddValue = cnt.Root.Children[ran1.Next(0, 10)];
                if (tempAddValue != tempCallNum && !tempList.Contains(tempAddValue))
                {
                    tempList.Add(tempAddValue);
                }
                else
                {
                    --i;
                }
            }
            return tempList;
        }

        /// <summary>
        /// Method generates the 2nd question in the problem
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<CallNumberNode> genQuestion2(CallNumberNode node)
        {
            int level1 = Convert.ToInt32(node.Parent.Parent.Num.Substring(0, 1));
            int level2 = Convert.ToInt32(node.Parent.Num.Substring(1, 1));
            CallNumberNode tempCallNum = cnt.Root.Children[level1].Children[level2];
            List<CallNumberNode> tempList = new List<CallNumberNode>();
            tempList.Add(tempCallNum);

            for (int i = 0; i < 3; ++i)
            {
                CallNumberNode tempAddValue = cnt.Root.Children[level1].Children[ran1.Next(0, 9)];
                if (tempAddValue != tempCallNum && !tempList.Contains(tempAddValue))
                {
                    tempList.Add(tempAddValue);
                }
                else
                {
                    --i;
                }
            }
            return tempList;
        }


        /// <summary>
        /// Method reads the whole text file and then generates the tree data structure
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="tr"></param>
        public static void genTree(string filePath, CallNumberTree tr)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                string[] subline;
                while ((line = reader.ReadLine()) != null)
                {
                    int level1 = 0;
                    int level2 = 0;

                    if (line.Contains(" - "))
                    {
                        subline = line.Split(new[] { '-' }, 2);
                        tr.Root.addNode(subline[0], subline[1]);
                    }
                    else
                    {
                        subline = line.Split(new[] { ',' }, 2);
                        level1 = Convert.ToInt32(subline[0].Substring(0, 1));
                        int callNumber = Convert.ToInt32(subline[0]);

                        if (callNumber % 10 == 0)
                        {
                            tr.Root.Children[level1].addNode(subline[0], subline[1]);
                        }
                        else
                        {
                            level2 = Convert.ToInt32(subline[0].Substring(1, 1));

                            tr.Root.Children[level1].Children[level2].addNode(subline[0], subline[1]);
                        }
                    }
                }

            }
        }
    }
}
