using System.Collections.Generic;

namespace PROG7312_UI.DataTree
{
    public class CallNumberNode
    {
        public string Num { get; set; }
        public string Des { get; set; }
        public CallNumberNode Parent { get; set; }
        public List<CallNumberNode> Children { get; set; }

        public CallNumberNode(string num, string des, CallNumberNode parent)
        {
            Num = num;
            Des = des;
            Children = new List<CallNumberNode>();
            Parent = parent;
        }

        public void addNode(string data1, string data2)
        {
            CallNumberNode newNode = new CallNumberNode(data1, data2, this);
            this.Children.Add(newNode);
        }
        public CallNumberNode()
        {

        }

        //public override string ToString()
        //{
        //    return $"Data: ({Num + Des}), Parent: ({Parent.Num})";
        //}
    }
}
