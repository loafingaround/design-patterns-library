using System.Collections.Generic;
using System.Windows.Forms;

namespace MementoPattern
{
    // This is the caretaker
    public partial class Form1 : Form
    {
        readonly Stack<IMemento> states = new Stack<IMemento>();

        public Form1()
        {
            InitializeComponent();

            // initialise with empty state
            StoreState();
        }

        void Undo()
        {
            if (states.Count > 1)
            {
                states.Pop();
                // ...
            }
        }

        void StoreState()
        {
            var memento = panel1.CreateMemento();
            states.Push(memento);
        }
    }
}
