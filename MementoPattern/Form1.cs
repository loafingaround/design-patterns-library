using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

// N.B. The undo, CTRL + Z, and redo, CTRL + Y, shortcut implementations are a bit basic:
// CTRL must be held down *while* Z/Y is pressed.
// Also: if the text box is still focused its own undo/redo functionality with interfere a little

// In general this works but it doesn't seem to work smoothly - there may be the odd glitch

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

            this.panel1.Change += PanelChange;

            this.KeyPreview = true;
            this.KeyUp += Form1_KeyUp1;
        }
        
        private void Form1_KeyUp1(object sender, KeyEventArgs e)
        {
            if (e.Control)
                if(e.KeyCode == Keys.Z)
                    Undo();
                else if(e.KeyCode == Keys.Y)
                    Redo();
        }

        void Undo()
        {
            if (states.Count > 1)
            {
                states.Pop();
                var memento = states.Peek();
                panel1.SetMemento(memento);
            }
        }

        void Redo()
        {
            // TODO
        }

        void StoreState()
        {
            var memento = panel1.CreateMemento();
            states.Push(memento);
        }

        void PanelChange(object sender, object e)
        {
            StoreState();
        }
    }
}
