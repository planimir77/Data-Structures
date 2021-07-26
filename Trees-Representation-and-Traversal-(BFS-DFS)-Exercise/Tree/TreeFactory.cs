namespace Tree
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var row in input)
            {
                var nodes = row.Split()
                               .Select(int.Parse)
                               .ToArray();

                var parent = nodes[0];
                var child = nodes[1];

                if (!this.nodesBykeys.ContainsKey(parent))
                {
                    var node = CreateNodeByKey(parent);
                    this.nodesBykeys.Add(parent, node);
                }

                if (!this.nodesBykeys.ContainsKey(child))
                {
                    var node = CreateNodeByKey(child);
                    this.nodesBykeys.Add(child, node);
                }

                this.AddEdge(parent, child);
            }
            return this.GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            return new Tree<int>(key);
        }

        public void AddEdge(int parent, int child)
        {
            this.nodesBykeys[parent].AddChild(this.nodesBykeys[child]);
            this.nodesBykeys[child].AddParent(this.nodesBykeys[parent]);
        }

        private Tree<int> GetRoot()
        {
            var root = this.nodesBykeys.FirstOrDefault(x => x.Value.Parent == null).Value;
            return root;
        }
    }
}
