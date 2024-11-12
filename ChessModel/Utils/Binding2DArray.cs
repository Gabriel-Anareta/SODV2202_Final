using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    public sealed class Binding2DArray<T> where T : class
    {
        public BindingSource[,] Bindings { get; private set; }
        private readonly T[,] _elements;

        public T this[int x, int y]
        {
            get { return _elements[x, y]; }
            set 
            { 
                _elements[x, y] = value;
                Bindings[x, y].DataSource = value;
            }
        }

        public Binding2DArray(int xSize, int ySize, T defaultValue) 
        {
            if (defaultValue == null)
                throw new ArgumentNullException("Default value cannot be null");
            
            Bindings = new BindingSource[xSize, ySize];
            _elements = new T[xSize, ySize];

            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    Bindings[x, y] = new BindingSource { DataSource = defaultValue };
                    this[x, y] = defaultValue;
                }
            }      
        }
    }
}
