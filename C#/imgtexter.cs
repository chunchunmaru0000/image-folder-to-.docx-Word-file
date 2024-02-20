using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Threading;
using System.Diagnostics;

namespace image_folder_to_text
{
    public partial class imgtexter : Form
    {
        public string currentFolderPath;
        public bool numerable = true;
        public bool severable = true;
        public Thread thread;

        public imgtexter()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += FormKeyDown;
            FormClosing += new FormClosingEventHandler(CloseForm);

            consoleBox.AppendText("нумерация активированна" + '\n');
            consoleBox.AppendText("разрыв страниц включен" + '\n');
        }

        private void CloseForm(object sender, FormClosingEventArgs e)
        {
            if (thread != null && thread.IsAlive)
                thread.Abort();
        }

        private bool GoodLetter(string c) 
        {
            var unforgivable = new string[] { "(", ")", "«", "»", ".", ",", ":", ";" };
            return c == c.ToLower() && !unforgivable.Contains(c); 
        }

        //its very strange but i just rewrited it from python where its even somehow can looks like reasonable
        private string EditPage(string page)
        {
            List<string> strs = new List<string>();
            foreach (string paragraph in page.Split('\n'))
                if (!string.IsNullOrWhiteSpace(paragraph) && !string.IsNullOrEmpty(paragraph))
                    strs.Add(paragraph);
            List<string> news = new List<string>() { strs[0] };
            var strangeSymbols = new string[] { ")", "»", "," };

            for (int i = 1; i < strs.Count(); i++)
            {
                int nlen = news.Count() - 1;
                if (strs[i - 1].Last() == '-')
                    news[nlen] = string.Join("" ,news[nlen].Take(nlen)) + strs[i];
                else if (strs[i - 1].Last() == ' ')
                    news[nlen] = strs[i];
                else if (
                    (GoodLetter("" + strs[i - 1].Last()) && "" + strs[i][0] == ("" + strs[i][0]).ToLower()) ||
                    (strangeSymbols.Contains("" + strs[i - 1].Last()) && GoodLetter("" + strs[i][0]))
                    ) news[nlen] += ' ' + strs[i];
                else
                    news.Add(strs[i]);
            }
            return string.Join("\n", news.ToArray()).Replace('}', ')').Replace(']', ')').Replace('{', '(').Replace('[', '(');
        }

        private string[] ReadPages(string path)
        {
            try
            {
                var pages = new List<string>();
                var photosNames = Directory.GetFiles(path).Select(p => Convert.ToInt32(p.Split('\\').Last().Split('.')[0])).OrderBy(x => x).ToArray();
                var photosPaths = Directory.GetFiles(path).OrderBy(p => Convert.ToInt32(p.Split('\\').Last().Split('.')[0])).ToArray();
                Dictionary<string, int> photos = new Dictionary<string, int>();
                for (int i = 0; i < photosNames.Length; i++)
                    photos[photosPaths[i]] = photosNames[i];
                TimeSpan timeSpan = new TimeSpan();

                // should only be in folder that name is tessdata
                string dir = Environment.CurrentDirectory + "\\tessdata";
                using (var engine = new TesseractEngine(dir, "rus"))
                {
                    foreach(var photo in photos)
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();

                        Invoke((MethodInvoker)delegate
                        {
                            consoleBox.SelectionColor = System.Drawing.Color.Aqua;
                            consoleBox.AppendText(photo.Value + " | НАЧАЛО | " + timeSpan + '\n');
                            consoleBox.Focus();
                        });

                        var image = Pix.LoadFromFile(photo.Key);
                        var page = engine.Process(image);
                        pages.Add((numerable ? "------------------------------" + photo.Value + "------------------------------": "")  +  
                                                                         EditPage(page.GetText()));
                        page.Dispose();

                        stopwatch.Stop();
                        timeSpan += stopwatch.Elapsed;

                        Invoke((MethodInvoker)delegate
                        {
                            consoleBox.SelectionColor = System.Drawing.Color.LawnGreen;
                            consoleBox.AppendText(photo.Value + " |  КОНЕЦ  | " + timeSpan + '\n');
                            consoleBox.Focus();
                        });
                    }
                    engine.Dispose();
                }
                Invoke((MethodInvoker)delegate
                {
                    consoleBox.SelectionColor = System.Drawing.Color.LawnGreen;
                    consoleBox.AppendText(" | ОБЩЕЕ ВРЕМЯ | " + timeSpan + '\n');
                    consoleBox.Focus();
                });
                return pages.ToArray();
            }
            catch (Exception error)
            {
                Invoke((MethodInvoker)delegate
                {
                    consoleBox.SelectionColor = System.Drawing.Color.Red;
                    consoleBox.AppendText("####### ERROR #######" + '\n' + error.ToString().Split('\n')[0] + '\n');
                    //consoleBox.AppendText("####### ERROR #######" + '\n' + error.ToString() + '\n');
                });
            }
            return null;
        }

        private void WordWrite(string dirToSave, string[] pages)
        {
            //using (StreamWriter writer = new StreamWriter(dirToSave + ".docx")) { }
            using (WordprocessingDocument document = WordprocessingDocument.Create(dirToSave, 
                DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = document.AddMainDocumentPart();
                mainPart.Document = new Document();

                Body body = mainPart.Document.AppendChild(new Body());
                foreach(string page in pages)
                {
                    foreach(string paragraph in page.Split('\n'))
                    {
                        Paragraph par = new Paragraph(new Run(new Text(paragraph)));
                        body.Append(par);
                    }
                    Paragraph pageBreak = new Paragraph(new Run(new Break() { Type = BreakValues.Page }));
                    body.Append(pageBreak);
                }
            }
        }

        private void ScanAllPhotos(string path, string[] pages)
        {
            if (pages != null)
            {
                var folds = path.Split('\\').ToArray();
                var temp = new string[folds.Length - 1];
                Array.Copy(folds, temp, folds.Length - 1);
                string dirToSave = string.Join("\\", temp) + "\\" + folds[folds.Length - 1] + 
                                   DateTime.Now.ToLongTimeString().Replace(':', '.') + ".docx";

                Invoke((MethodInvoker)delegate
                {
                    consoleBox.SelectionColor = System.Drawing.Color.Magenta;
                    consoleBox.AppendText(" | ОТСКАНИРОВАННО УСПЕШНО | " + '\n');
                    consoleBox.Focus();
                });

                WordWrite(dirToSave, pages);

                Invoke((MethodInvoker)delegate
                {
                    consoleBox.SelectionColor = System.Drawing.Color.MediumAquamarine;
                    consoleBox.AppendText(" | ЗАКОНЧЕНО УСПЕШНО | " + '\n' + dirToSave + '\n');
                    consoleBox.Focus();
                });
            }
        }

        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.Enter:
                    folderButton_Click(folderButton, new EventArgs());
                    break;
                default:
                    break;
            }
        }

        private void folderButton_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            
            if(result == DialogResult.OK)
            {
                currentFolderPath = folderBrowserDialog.SelectedPath;
                consoleBox.SelectionColor = System.Drawing.Color.GreenYellow;
                consoleBox.AppendText(currentFolderPath + '\n');

                thread = new Thread(() => ScanAllPhotos(currentFolderPath ,ReadPages(currentFolderPath)));
                thread.Start();
            }
            else
            {
                consoleBox.SelectionColor = System.Drawing.Color.Red;
                consoleBox.AppendText("####### ПУСТОЙ ВЫБОР #######" + '\n');
            }
        }

        private void numerationButton_Click(object sender, EventArgs e)
        {
            numerable = true;
            consoleBox.AppendText("нумерация активированна" + '\n');
        }

        private void numerationNotButton_Click(object sender, EventArgs e)
        {
            numerable = false;
            consoleBox.AppendText("нумерация отключена" + '\n');
        }

        private void severButton_Click(object sender, EventArgs e)
        {
            severable = true;
            consoleBox.AppendText("разрыв страниц включен" + '\n');
        }

        private void severNotButton_Click(object sender, EventArgs e)
        {
            severable = false;
            consoleBox.AppendText("разрыв страниц выключен" + '\n');
        }
    }
}
