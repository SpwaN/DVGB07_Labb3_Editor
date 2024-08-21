namespace DVGB07_Labb3_Editor
{
    public partial class Form1 : Form
    {
        //.Net 8.0
        //Kevin Berling 2024-03-11
        //DVGB07

        private string text = "";
        private string path = "Untitled.txt";
        private string hiddenValue = "";

        private int CharsWithSpace = 0;
        private int CharsWithoutSpace = 0;
        private int TotalWords = 0;
        private int TotalRows = 0;

        public Form1()
        {
            InitializeComponent();
        }

        //Events

        //Load event f�r Form
        private void Form1_Load(object sender, EventArgs e)
        {
            TextBox.AllowDrop = true;
            TextBox.DragDrop += new DragEventHandler(TextBox_DragDrop);
        }

        //DragDrop till Textbox
        private void TextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (hiddenValue == "ctrl") //Om anv�ndaren h�ller inne ctrl
            {
                foreach (string file in files)
                {
                    //L�ser av text och l�gger p� den sist i TextBox
                    text = File.ReadAllText(file);
                    TextBox.Text += text;
                }
            }
            else if (hiddenValue == "shift") //Om anv�ndaren h�ller inne shift
            {
                foreach (string file in files)
                {
                    /*Kollar vart pekaren �r och l�ser av fil.
                    kopierar in den nya texten vid pekarens position i TextBox.*/
                    Clipboard.SetText(File.ReadAllText(file));
                    TextBox.Paste();
                }
            }
            else if (hiddenValue == " ") //Om anv�ndaren inte h�ller inne n�gon knapp
            {
                path = DeleteAsterisk(); //h�mtar s�kv�g utan (*)

                if (path == "Untitled.txt") //Om s�kv�g �r Untitled.txt s� finns inte filen sparad
                {
                    text = ""; //S� �r d� d�rf�r en tom str�ng
                }
                else //Filen finns sparad
                {
                    //L�ser text i fil och sparar ner den i variabel (text)
                    text = File.ReadAllText(path);
                }

                text = text.Replace("\r", ""); //Tar bort \r text


                /*Om sparad fil och textarea inte �r lika.
                 Kontrollera om anv�ndaren vill spara f�rst*/
                if (text != TextBox.Text)
                {
                    DialogResult dialogResult = MessageBox.Show(
                    "Vill du spara fil f�rst?",
                    "Spara", MessageBoxButtons.YesNoCancel);

                    //Om JA: Spara och sen skriv ut nya filen.
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveText();
                        dialogResult = DialogResult.No; //G� till NEJ d�r vi skriver ut fil
                    }

                    //Om NEJ: Skriv ut nya filen
                    if (dialogResult == DialogResult.No)
                    {
                        foreach (string file in files)
                        {
                            this.Text = file;
                            text = File.ReadAllText(file);
                            TextBox.Text = text;
                        }
                    }

                    //Om AVBRYT: G�r ingeting

                }
                /*Om sparad fil och textarea �r lika.
                 Skriv ut fil direkt*/
                else
                {
                    foreach (string file in files)
                    {
                        this.Text = file;
                        text = File.ReadAllText(file);
                        TextBox.Text = text;
                    }
                }

            }
        }

        //Spara som.. Click
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        //Spara Click
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveText();
        }

        //�ppna.. Click
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            path = DeleteAsterisk(); //h�mtar s�kv�g utan (*)

            if (path == "Untitled.txt") //Om s�kv�g �r Untitled.txt s� finns inte filen sparad
            {
                text = ""; //S� �r d�rf�r en tom str�ng
            }
            else //Filen finns sparad
            {
                text = File.ReadAllText(path); //L�ser fil och sparar i variabel (text)
            }

            text = text.Replace("\r", ""); //Tar bort \r ur text

            if (text == TextBox.Text) //Om fil text = TextBox -> �ppna fil
            {
                OpenFil();
            }
            else //Fr�ga om anv�ndaren vill spara f�rst
            {
                DialogResult dialogResult = MessageBox.Show(
                "Vill du spara �ndringar f�rst innan du �ppnar ny fil?",
                "Spara f�rst?", MessageBoxButtons.YesNoCancel);

                if (dialogResult == DialogResult.Yes)
                {
                    SaveText();
                    OpenFil();
                }
                if (dialogResult == DialogResult.No)
                {
                    OpenFil();
                }
            }
        }

        //Ny fil Click
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            path = DeleteAsterisk();

            if (path == "Untitled.txt")
            {
                text = "";
            }
            else
            {
                text = File.ReadAllText(path);
            }

            text = text.Replace("\r", "");

            if (text != TextBox.Text) //Om inte lika fr�ga om anv�ndaren vill spara fil f�rst
            {
                DialogResult dialogResult = MessageBox.Show(
                "Vill du spara fil f�rst?",
                "Spara", MessageBoxButtons.YesNoCancel);

                if (dialogResult == DialogResult.Yes)
                {
                    SaveText();
                    dialogResult = DialogResult.No;
                }

                if (dialogResult == DialogResult.No)
                {
                    this.Text = "Untitled.txt";
                    TextBox.Text = "";
                }
            }
            else //Om lika
            {
                this.Text = "Untitled.txt";
                TextBox.Text = "";
            }
        }

        //Rensa TextBox Click
        private void clearTextareaToolStripMenuItem_click(object sender, EventArgs e)
        {
            TextBox.Text = "";
        }

        //Registrerar �ndringar i TextBox
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            ErrorMsg.Text = ""; //Nollst�ller eventuella felmedelanden
            path = DeleteAsterisk(); //H�mtar s�kv�g och plockar bort (*)

            if (path != "Untitled.txt") //Om fil finns sparad
            {
                text = File.ReadAllText(path);
                text = text.Replace("\r", "");
            }

            //Om text �r �ndrad
            if (text != TextBox.Text)
            {
                this.Text = "*" + path; //L�gg till (*) och s�kv�g
            }
            //Om text inte �r �ndrad
            else
            {
                this.Text = path; //L�gg till s�kv�g
            }

            UpdateStatus(); //Uppdatera statusbar
        }

        //Exitknapp Click
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        //N�r program st�ngs ner
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            path = DeleteAsterisk();

            if (path == "Untitled.txt")
            {
                text = "";
            }
            else
            {
                text = File.ReadAllText(path);
            }

            text = text.Replace("\r", "");

            //Om text inte �r samma som sparad text fr�n fil
            if (text != TextBox.Text)
            {
                AskForClose(e); //Fr�ga anv�ndaren om att spara f�rst
            }

        }

        //Kontrollerar om ctrl eller shift �r nedtryckta
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            ErrorMsg.Text = ""; //Nollst�ller eventuella felmedelanden

            //Om anv�ndaren h�ller inne ctrl
            if (e.KeyCode == Keys.ControlKey)
            {
                hiddenValue = "ctrl"; //g�mmer "ctrl" i hiddenvalue
            }

            //Om anv�ndaren h�ller inne shift
            if (e.KeyCode == Keys.ShiftKey)
            {
                hiddenValue = "shift"; //g�mmer "shift" i hiddenvalue
            }
        }

        //Anv�ndaren har sl�ppt ctrl eller shift
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //N�r anv�ndaren sl�pper knapp nollst�ll hidenvalue till tom str�ng
            hiddenValue = " ";
        }

        //Funktioner

        //Spara ner fil som...
        private void SaveAs()
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog(); //Skapar nytt f�nster f�r att spara
                sfd.Title = "Spara fil som";
                sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.ShowDialog(); //visar f�nster

                if (sfd.ShowDialog() == DialogResult.OK) //Om allt gick bra
                {
                    //Skriver till filen och sparar den under FileName
                    StreamWriter file = new StreamWriter(sfd.FileName.ToString());
                    file.WriteLine(TextBox.Text);
                    file.Close();
                    this.Text = sfd.FileName;
                    TextBox.Text = File.ReadAllText(sfd.FileName);
                }
            }
            catch //Vid problem...
            {
                ErrorMsg.Text = "Error: N�got gick fel n�r filen skulle sparas";
            }

        }

        //Spara fil
        private void SaveText()
        {
            text = TextBox.Text;
            path = DeleteAsterisk();

            //Om fil inte finns sparad anropa "spara som" SaveAs() ist�llet
            if (path == "Untitled.txt")
            {
                SaveAs();
            }
            //Om fil finns sparad sen tidigare
            else
            {
                try
                {
                    File.WriteAllText(path, text); //Skriv till filen
                    MessageBox.Show("File saved!"); //Filen sparad (Allt gick bra!)
                }
                catch //Vid knas...
                {
                    ErrorMsg.Text = "Error: Filen kunde inte sparas";
                }
            }
        }

        //�ppna fil...
        private void OpenFil()
        {
            //Skapar f�nster
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "V�lj fil att �ppna";
            dlg.ShowDialog();
            try
            {
                //L�ser av text fr�n �ppnad fil och skriver in den i TextBox
                text = File.ReadAllText(dlg.FileName);
                TextBox.Text = text;
                this.Text = dlg.FileName;

                UpdateStatus(); //Uppdatera StatusBar
            }
            catch
            {
                /*F�rhindrar Krasch..
                 Om anv�ndaren skulle st�nga ner f�nstret*/
                ErrorMsg.Text = "Error: N�got gick fel med att �ppna filen";
            }
        }

        //Tar bort asterisk (*)
        private string DeleteAsterisk()
        {
            string nyPath = this.Text.Replace("*", "");
            return nyPath;
        }

        //Uppdaterar statusbar
        private void UpdateStatus()
        {
            text = TextBox.Text; //H�mtar text
            char[] c = new char[] { ' ', '\r', '\n' }; //Tecken som inte r�knas som ord

            CharsWithSpace = text.Length;
            CharsWithoutSpace = text.Replace(" ", "").Length;
            TotalWords = text.Split(c, StringSplitOptions.RemoveEmptyEntries).Length;
            TotalRows = text.Split('\n').Length;

            value1.Text = CharsWithSpace.ToString();
            value2.Text = CharsWithoutSpace.ToString();
            value3.Text = TotalWords.ToString();
            value4.Text = TotalRows.ToString();
        }

        /*Fr�gar om anv�ndaren vill avsluta program.
         Vid avslut d�r �ndringar gjorts*/
        private void AskForClose(FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
            "Vill du spara text innan du avslutar?",
            "Avsluta", MessageBoxButtons.YesNoCancel);

            if (dialogResult == DialogResult.Yes)
            {
                SaveText(); //Spara text
            }

            if (dialogResult == DialogResult.Cancel)
            {
                e.Cancel = true; //Avbryt avst�ngning
            }
        }
    }
}