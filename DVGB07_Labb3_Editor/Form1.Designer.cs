namespace DVGB07_Labb3_Editor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TextBox = new RichTextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            clearTextareaToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            status1 = new ToolStripStatusLabel();
            value1 = new ToolStripStatusLabel();
            status2 = new ToolStripStatusLabel();
            value2 = new ToolStripStatusLabel();
            status3 = new ToolStripStatusLabel();
            value3 = new ToolStripStatusLabel();
            status4 = new ToolStripStatusLabel();
            value4 = new ToolStripStatusLabel();
            ErrorMsg = new Label();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // TextBox
            // 
            TextBox.Location = new Point(12, 27);
            TextBox.Name = "TextBox";
            TextBox.Size = new Size(776, 398);
            TextBox.TabIndex = 0;
            TextBox.Text = "";
            TextBox.TextChanged += TextBox_TextChanged;
            TextBox.KeyDown += TextBox_KeyDown;
            TextBox.KeyUp += TextBox_KeyUp;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menu";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(180, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(180, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clearTextareaToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // clearTextareaToolStripMenuItem
            // 
            clearTextareaToolStripMenuItem.Name = "clearTextareaToolStripMenuItem";
            clearTextareaToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;
            clearTextareaToolStripMenuItem.Size = new Size(189, 22);
            clearTextareaToolStripMenuItem.Text = "Clear Textarea";
            clearTextareaToolStripMenuItem.Click += clearTextareaToolStripMenuItem_click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { status1, value1, status2, value2, status3, value3, status4, value4 });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // status1
            // 
            status1.Name = "status1";
            status1.Size = new Size(138, 17);
            status1.Text = "Total Chars (With Space):";
            // 
            // value1
            // 
            value1.Name = "value1";
            value1.Size = new Size(0, 17);
            // 
            // status2
            // 
            status2.Margin = new Padding(50, 3, 0, 2);
            status2.Name = "status2";
            status2.Size = new Size(156, 17);
            status2.Text = "Total Chars (Without Space):";
            // 
            // value2
            // 
            value2.Name = "value2";
            value2.Size = new Size(0, 17);
            // 
            // status3
            // 
            status3.Margin = new Padding(50, 3, 0, 2);
            status3.Name = "status3";
            status3.Size = new Size(73, 17);
            status3.Text = "Wordcount: ";
            // 
            // value3
            // 
            value3.Name = "value3";
            value3.Size = new Size(0, 17);
            // 
            // status4
            // 
            status4.Margin = new Padding(50, 3, 0, 2);
            status4.Name = "status4";
            status4.Size = new Size(38, 17);
            status4.Text = "Rows:";
            // 
            // value4
            // 
            value4.Name = "value4";
            value4.Size = new Size(0, 17);
            // 
            // ErrorMsg
            // 
            ErrorMsg.AutoSize = true;
            ErrorMsg.ForeColor = Color.Red;
            ErrorMsg.Location = new Point(98, 10);
            ErrorMsg.Name = "ErrorMsg";
            ErrorMsg.Size = new Size(0, 15);
            ErrorMsg.TabIndex = 3;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ErrorMsg);
            Controls.Add(statusStrip1);
            Controls.Add(TextBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Untitled.txt";
            FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            Load += new EventHandler(Form1_Load);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox TextBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem clearTextareaToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel status1;
        private ToolStripStatusLabel status2;
        private ToolStripStatusLabel status3;
        private ToolStripStatusLabel status4;
        private ToolStripStatusLabel value1;
        private ToolStripStatusLabel value2;
        private ToolStripStatusLabel value3;
        private ToolStripStatusLabel value4;
        private Label ErrorMsg;
    }
}
