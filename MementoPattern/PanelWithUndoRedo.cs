using System.Windows.Forms;

namespace MementoPattern
{
    // This is the originator
    public class PanelWithUndoRedo: Panel
    {
        TextBox textBox;
        TrackBar trackBar1;
        CheckBox checkBox1;
        ColorDialog colorDialog1;
        ListBox listBox1;
        DateTimePicker dateTimePicker1;

        public IMemento CreateMemento()
        {
            return new Memento();
        }

        public void SetMemento(IMemento memento)
        {

        }

        public PanelWithUndoRedo()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.textBox = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();

            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();

            this.textBox.Location = new System.Drawing.Point(16, 195);
            this.textBox.Name = "textBox1";
            this.textBox.Size = new System.Drawing.Size(280, 20);
            this.textBox.TabIndex = 3;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(16, 18);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(304, 45);
            this.trackBar1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(16, 69);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
                "Red",
                "Yellow",
                "Blue",
                "Green"});
            this.listBox1.Location = new System.Drawing.Point(16, 117);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(280, 56);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectionMode = SelectionMode.MultiSimple;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(16, 239);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 4;

            Controls.Add(this.textBox);
            Controls.Add(this.trackBar1);
            Controls.Add(this.dateTimePicker1);
            Controls.Add(this.checkBox1);
            Controls.Add(this.listBox1);

            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
        }
    }
}