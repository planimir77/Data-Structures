namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;

            this.Value = int.Parse(this.Key.ToString());

            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                this.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public int Value { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this.children.AsReadOnly();

        private List<Tree<T>> LeafKeysCollection;

        private List<T> MiddleKeysCollection;


        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {

            return this.GetAsString(0);
        }

        private string GetAsString(int indentation)
        {
            var result = new string(' ', indentation) + this.Key;

            foreach (var child in this.Children)
            {
                result += Environment.NewLine + child.GetAsString(indentation + 2);
            }
            return result;
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            int biggestDepth = 0;
            Tree<T> deepestNode = null;
            FindDeepestNode(this, 0, ref biggestDepth, ref deepestNode);
            return deepestNode;
        }

        private void FindDeepestNode(Tree<T> currentNode, int currentDepth, ref int biggestDepth, ref Tree<T> deepestNode)
        {
            if (biggestDepth < currentDepth)
            {
                biggestDepth = currentDepth;
                deepestNode = currentNode;
            }

            foreach (var child in currentNode.Children)
            {
                FindDeepestNode(child, currentDepth + 1, ref biggestDepth, ref deepestNode);
            }
        }

        public List<T> GetLeafKeys()
        {
            return GetLeafNodes().Select(x => x.Key).ToList();
        }

        public List<Tree<T>> GetLeafNodes()
        {
            if (this.LeafKeysCollection == null)
            {
                this.LeafKeysCollection = new List<Tree<T>>();
            }

            GetLeafKey(this);

            return this.LeafKeysCollection;
        }

        public void GetLeafKey(Tree<T> tree)
        {
            foreach (var child in tree.Children)
            {
                GetLeafKey(child);
            }

            if (tree.Children.Count == 0)
            {
                this.LeafKeysCollection.Add(tree);
            }
        }

        public List<T> GetMiddleKeys()
        {
            this.MiddleKeysCollection = new List<T>();

            GetMiddleKeys(this);

            return this.MiddleKeysCollection;
        }

        private void GetMiddleKeys(Tree<T> tree)
        {
            foreach (var child in tree.Children)
            {
                GetMiddleKeys(child);
                if (child.Children.Count > 0 && child.Parent != null)
                {
                    this.MiddleKeysCollection.Add(child.Key);
                }
            }
        }

        public List<T> GetLongestPath()
        {
            var leafNodes = GetLeafNodes();
            var nodes = new List<T>();

            foreach (var node in leafNodes)
            {
                var currentNodes = new List<T>();
                var currentNode = node;
                var count = 1;
                currentNodes.Add(currentNode.Key);
                while (currentNode.Parent != null)
                {
                    currentNode = currentNode.Parent;
                    currentNodes.Add(currentNode.Key);
                    count++;
                }
                if (currentNodes.Count > nodes.Count)
                {
                    nodes = currentNodes;
                }
            }

            return nodes.ToArray().Reverse().ToList(); ;
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var paths = new List<List<T>>();

            var leafNodes = GetLeafNodes();

            foreach (var leafNode in leafNodes)
            {
                var currentPath = Parents(leafNode, new List<T>());
                var currentPathToInt = currentPath.Select(x => int.Parse(x.ToString()));

                if (currentPathToInt.Sum() == sum)
                {
                    List<T> currentReversedPath = Reverse(currentPath).ToList();
                    paths.Add(currentReversedPath);
                }
            }

            return paths;
        }

        private IEnumerable<T> Reverse(List<T> currentPath)
        {
            for (int i = currentPath.Count - 1; i >= 0; i--)
            {
                yield return currentPath[i];
            }
        }

        private List<T> Parents(Tree<T> tree, List<T> nodes)
        {
            nodes.Add(tree.Key);

            if (tree.Parent != null)
            {

                return Parents(tree.Parent, nodes);
            }

            return nodes;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            List<Tree<T>> subNodes = new List<Tree<T>>();

            FindSubTreesWithGivenSum(this, ref subNodes, sum);

            return subNodes;
        }

        private int FindSubTreesWithGivenSum(Tree<T> node, ref List<Tree<T>> subNodes, int targetSum)
        {
            var currentSum = node.Value;


            foreach (var child in node.Children)
            {
                currentSum += FindSubTreesWithGivenSum(child, ref subNodes, targetSum);

            }

            if (currentSum == targetSum)
            {
                subNodes.Add(node);
            }

            return currentSum;
        }

        private int SumOfChild(IReadOnlyCollection<Tree<T>> children)
        {
            var result = 0;
            foreach (var child in children)
            {
                result += child.Value;
            }
            return result;
        }
    }
}
