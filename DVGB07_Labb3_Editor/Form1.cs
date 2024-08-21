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

        //Load event för Form
        private void Form1_Load(object sender, EventArgs e)
        {
            TextBox.AllowDrop = true;
            TextBox.DragDrop += new DragEventHandler(TextBox_DragDrop);
        }

        //DragDrop till Textbox
        private void TextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (hiddenValue == "ctrl") //Om användaren håller inne ctrl
            {
                foreach (string file in files)
                {
                    //Läser av text och lägger på den sist i TextBox
                    text = File.ReadAllText(file);
                    TextBox.Text += text;
                }
            }
            else if (hiddenValue == "shift") //Om användaren håller inne shift
            {
                foreach (string file in files)
                {
                    /*Kollar vart pekaren är och läser av fil.
                    kopierar in den nya texten vid pekarens position i TextBox.*/
                    Clipboard.SetText(File.ReadAllText(file));
                    TextBox.Paste();
                }
            }
            else if (hiddenValue == " ") //Om användaren inte håller inne någon knapp
            {
                path = DeleteAsterisk(); //hämtar sökväg utan (*)

                if (path == "Untitled.txt") //Om sökväg är Untitled.txt så finns inte filen sparad
                {
                    text = ""; //Så är då därför en tom sträng
                }
                else //Filen finns sparad
                {
                    //Läser text i fil och sparar ner den i variabel (text)
                    text = File.ReadAllText(path);
                }

                text = text.Replace("\r", ""); //Tar bort \r text


                /*Om sparad fil och textarea inte är lika.
                 Kontrollera om användaren vill spara först*/
                if (text != TextBox.Text)
                {
                    DialogResult dialogResult = MessageBox.Show(
                    "Vill du spara fil först?",
                    "Spara", MessageBoxButtons.YesNoCancel);

                    //Om JA: Spara och sen skriv ut nya filen.
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveText();
                        dialogResult = DialogResult.No; //Gå till NEJ där vi skriver ut fil
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

                    //Om AVBRYT: Gör ingeting

                }
                /*Om sparad fil och textarea är lika.
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

        //Öppna.. Click
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            path = DeleteAsterisk(); //hämtar sökväg utan (*)

            if (path == "Untitled.txt") //Om sökväg är Untitled.txt så finns inte filen sparad
            {
                text = ""; //Så är därför en tom sträng
            }
            else //Filen finns sparad
            {
                text = File.ReadAllText(path); //Läser fil och sparar i variabel (text)
            }

            text = text.Replace("\r", ""); //Tar bort \r ur text

            if (text == TextBox.Text) //Om fil text = TextBox -> Öppna fil
            {
                OpenFil();
            }
            else //Fråga om användaren vill spara först
            {
                DialogResult dialogResult = MessageBox.Show(
                "Vill du spara ändringar först innan du öppnar ny fil?",
                "Spara först?", MessageBoxButtons.YesNoCancel);

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

            if (text != TextBox.Text) //Om inte lika fråga om användaren vill spara fil först
            {
                DialogResult dialogResult = MessageBox.Show(
                "Vill du spara fil först?",
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

        //Registrerar ändringar i TextBox
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            ErrorMsg.Text = ""; //Nollställer eventuella felmedelanden
            path = DeleteAsterisk(); //Hämtar sökväg och plockar bort (*)

            if (path != "Untitled.txt") //Om fil finns sparad
            {
                text = File.ReadAllText(path);
                text = text.Replace("\r", "");
            }

            //Om text är ändrad
            if (text != TextBox.Text)
            {
                this.Text = "*" + path; //Lägg till (*) och sökväg
            }
            //Om text inte är ändrad
            else
            {
                this.Text = path; //Lägg till sökväg
            }

            UpdateStatus(); //Uppdatera statusbar
        }

        //Exitknapp Click
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        //När program stängs ner
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

            //Om text inte är samma som sparad text från fil
            if (text != TextBox.Text)
            {
                AskForClose(e); //Fråga användaren om att spara först
            }

        }

        //Kontrollerar om ctrl eller shift är nedtryckta
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            ErrorMsg.Text = ""; //Nollställer eventuella felmedelanden

            //Om användaren håller inne ctrl
            if (e.KeyCode == Keys.ControlKey)
            {
                hiddenValue = "ctrl"; //gömmer "ctrl" i hiddenvalue
            }

            //Om användaren håller inne shift
            if (e.KeyCode == Keys.ShiftKey)
            {
                hiddenValue = "shift"; //gömmer "shift" i hiddenvalue
            }
        }

        //Användaren har släppt ctrl eller shift
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //När användaren släpper knapp nollställ hidenvalue till tom sträng
            hiddenValue = " ";
        }

        //Funktioner

        //Spara ner fil som...
        private void SaveAs()
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog(); //Skapar nytt fönster för att spara
                sfd.Title = "Spara fil som";
                sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.ShowDialog(); //visar fönster

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
                ErrorMsg.Text = "Error: Något gick fel när filen skulle sparas";
            }

        }

        //Spara fil
        private void SaveText()
        {
            text = TextBox.Text;
            path = DeleteAsterisk();

            //Om fil inte finns sparad anropa "spara som" SaveAs() istället
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

        //Öppna fil...
        private void OpenFil()
        {
            //Skapar fönster
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Välj fil att öppna";
            dlg.ShowDialog();
            try
            {
                //Läser av text från öppnad fil och skriver in den i TextBox
                text = File.ReadAllText(dlg.FileName);
                TextBox.Text = text;
                this.Text = dlg.FileName;

                UpdateStatus(); //Uppdatera StatusBar
            }
            catch
            {
                /*Förhindrar Krasch..
                 Om användaren skulle stänga ner fönstret*/
                ErrorMsg.Text = "Error: Något gick fel med att öppna filen";
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
            text = TextBox.Text; //Hämtar text
            char[] c = new char[] { ' ', '\r', '\n' }; //Tecken som inte räknas som ord

            CharsWithSpace = text.Length;
            CharsWithoutSpace = text.Replace(" ", "").Length;
            TotalWords = text.Split(c, StringSplitOptions.RemoveEmptyEntries).Length;
            TotalRows = text.Split('\n').Length;

            value1.Text = CharsWithSpace.ToString();
            value2.Text = CharsWithoutSpace.ToString();
            value3.Text = TotalWords.ToString();
            value4.Text = TotalRows.ToString();
        }

        /*Frågar om användaren vill avsluta program.
         Vid avslut där ändringar gjorts*/
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
                e.Cancel = true; //Avbryt avstängning
            }
        }
    }
}