using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anagrammes
{
    public class TreeNode
    {
        private  Anagramme  _value;
        private Dictionary<char, TreeNode> _children = new Dictionary<char, TreeNode>();

        public TreeNode(Anagramme value)
        {
            _value = value;
        }

        public TreeNode this[char c]
        {
            get 
            {
                if(_children.ContainsKey(c))
                {
                    return _children[c]; 
                }
                else
                {
                    return null;
                }                
            }
        }

        public TreeNode Parent { get; private set; }

        public Anagramme Value { get { return _value; } }

        public Dictionary<char, TreeNode> Children
        {
            get { return _children; }
        }

        public TreeNode AddChild(Anagramme value)
        {
            var node = new TreeNode(value) { Parent = this };
            _children.Add(value.letter, node);
            return node;
        }

        public TreeNode[] AddChildren(params Anagramme[] values)
        {
            return values.Select(AddChild).ToArray();
        }

        public bool RemoveChild(char c)
        {
            return _children.Remove(c);
        }

        public void Traverse(Action<Anagramme> action)
        {
            action(Value);
            foreach (var child in _children)
                child.Value.Traverse(action);
        }

        public IEnumerable<Anagramme> Flatten()
        {
            return new[] { Value }.Union(_children.Values.SelectMany(x => x.Flatten()));
        }
    }
}
