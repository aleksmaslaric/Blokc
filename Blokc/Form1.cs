﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blokc
{
    public partial class frmBlokc : Form
    {
        public static int stevec = 1;
        public frmBlokc()
        {
            InitializeComponent();
        }

        // širina za txtLinije
        public int sirina()
        {
            int s = 25;
            int linija = txtBlokc.Lines.Length;

            if (linija <= 99)
            {
                s = 20 + (int)txtBlokc.Font.Size;
            } else if (linija <= 999)
            {
                s = 30 + (int)txtBlokc.Font.Size;
            } else
            {
                s = 60 + (int)txtBlokc.Font.Size;
            }
            return s;
        }

        // dodajanje št linij v txtLinije
        public void dodajStLin()
        {
            Point pt = new Point(0, 0);

            int PrviIndeks = txtBlokc.GetCharIndexFromPosition(pt);
            int PrvaLinija = txtBlokc.GetLineFromCharIndex(PrviIndeks);

            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;

            int ZadnjiIndeks = txtBlokc.GetCharIndexFromPosition(pt);
            int ZadnjaLinija = txtBlokc.GetLineFromCharIndex(ZadnjiIndeks);

            txtLinije.SelectionAlignment = HorizontalAlignment.Center;
            txtLinije.Text = "";
            txtLinije.Width = sirina();
            
            for (int i = PrvaLinija; i <= ZadnjaLinija + 1; ++i)
            {
                txtLinije.Text += i + 1 + "\n";
            }
        }

        // dodatna koda za txtLinije - potrebno prečekirat / popravit določene zadeve (npr. vključen word wrap ne bi smel prikazovati nove linije pri nadaljevanju texta)
        private void frmBlokc_Load(object sender, EventArgs e)
        {
            txtLinije.Font = txtBlokc.Font;
            txtBlokc.Select();
            dodajStLin();
        }

        private void txtBlokc_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = txtBlokc.GetPositionFromCharIndex(txtBlokc.SelectionStart);
            if (pt.X == 1)
            {
                dodajStLin();
            }
        }

        private void txtBlokc_VScroll(object sender, EventArgs e)
        {
            txtLinije.Text = "";
            dodajStLin();
            txtLinije.Invalidate();
        }

        // prikaz podatkov v statusni vrstici + v rtb (txtLinije)
        private void txtBlokc_TextChanged(object sender, EventArgs e)
        {
            // statusna vrstica:
            int stLinij = txtBlokc.Lines.Length;
            txtLinije.Text = "";

            for (int i = 0; i != stLinij; ++i)
            {
                txtLinije.AppendText((i + 1) + "\n");
            }
            lblStatus.Text = "Linija: " + stLinij.ToString() + " - Znaki: " + txtBlokc.Text.Length.ToString();

            // prikaz linij na levi strani (txtLinije)
            if (txtBlokc.Text == "")
            {
                dodajStLin();
            }
        }

        // koda za pisavo v txtLinije
        private void txtBlokc_FontChanged(object sender, EventArgs e)
        {
            txtLinije.Font = txtBlokc.Font;
            txtBlokc.Select();
            dodajStLin();
        }

        private void txtLinije_MouseDown(object sender, MouseEventArgs e)
        {
            txtBlokc.Select();
            txtLinije.DeselectAll();
        }

        // klicanje metode dodajStLin()
        private void frmBlokc_Resize(object sender, EventArgs e)
        {
            dodajStLin();
        }

        // nov Blok'c
        private void novToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBlokc.Modified == true)
            {
                // kliče sfdShrani, če je v txtBlokc zaznana sprememba (zapisan text,...) in uporabnik pritisne na "Nov" v menustrip-u
                shraniKotToolStripMenuItem_Click(sender, e);
            }
        }

        // odpri Blok'c
        private void odpriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // odpri datoteko
            ofdOdpri.Filter = "Blok'c besedila (*.txt)|*.txt|Vse datoteke (*.*)|*.*";
            ofdOdpri.FilterIndex = 1; // izbran filter (*.txt), 2 = *.*
            ofdOdpri.RestoreDirectory = true;

            if (ofdOdpri.ShowDialog() == DialogResult.OK)
            {
                using (var sr = new StreamReader(ofdOdpri.FileName))
                {
                    txtBlokc.Text = sr.ReadToEnd();
                }
            }
        }

        // shrani Blok'c
        private void shraniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBlokc.Modified == true)
            {
                sfdShrani.Filter = "Blok'c besedila (*.txt)|*.txt|Vse datoteke (*.*)|*.*";
                sfdShrani.FileName = "Neimenovan Blok'c";
                DialogResult dg = MessageBox.Show("Ali želiš shraniti trenutni Blok'c?", "Shrani Blok'c?", MessageBoxButtons.YesNoCancel);

                if (dg == DialogResult.Yes)
                {
                    sfdShrani.ShowDialog();
                    using (var sw = new StreamWriter(sfdShrani.FileName))
                    {
                        sw.WriteLineAsync(txtBlokc.Text);
                    }
                }
                else if (dg == DialogResult.Cancel)
                {
                    // ...
                }
                else if (dg == DialogResult.No)
                {
                    txtBlokc.Clear();
                }
            }
        }

        private void shraniKotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfdShrani.Filter = "Blok'c besedila (*.txt)|*.txt|Vse datoteke (*.*)|*.*";
            sfdShrani.FileName = "Neimenovan Blok'c";
            DialogResult dg = MessageBox.Show("Ali želiš shraniti trenutni Blok'c?", "Shrani Blok'c?", MessageBoxButtons.YesNoCancel);

            if (dg == DialogResult.Yes)
            {
                sfdShrani.ShowDialog();
                using (var sw = new StreamWriter(sfdShrani.FileName))
                {
                    sw.WriteLineAsync(txtBlokc.Text);
                }
            }
            else if (dg == DialogResult.Cancel)
            {
                // ...
            }
            else if (dg == DialogResult.No)
            {
                txtBlokc.Clear();
            }
        }

        // priprava za tiskanje
        private void pripravaStraniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDokument;
            printPreviewDialog.ShowDialog();
        }

        // natisni Blok'c
        private void natisniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDokument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDokument.Print();
            }
        }

        private void printDokument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtBlokc.Text, txtBlokc.Font, Brushes.Black, 12, 10);
        }

        // razveljavi, povrni, izreži, kopiraj, prilepi, izbriši, izbriši vse (dodaj kodo), izberi vse, datum / ura
        private void razveljaviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBlokc.Undo();
        }

        private void povrniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBlokc.Redo();
        }

        private void izrežiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBlokc.Cut();
        }

        private void kopirajToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txtBlokc.Copy();
        }

        private void prilepiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBlokc.Paste();
        }

        private void izbrišiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBlokc.SelectedText = "";
        }

        private void izbrišiVseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ...
            txtBlokc.Clear();
        }

        private void izberiVseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBlokc.SelectAll();
        }

        private void datumUraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBlokc.SelectedText = Convert.ToString(DateTime.Now) + " ";
            //txtBlokc.Select(txtBlokc.Text.Length, 0); // postavi kazalko tipkovnice na konec dokumenta.
        }

        // word wrap
        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked == false)
            {
                wordWrapToolStripMenuItem.Checked = true;
                txtBlokc.WordWrap = true;
            } else
            {
                wordWrapToolStripMenuItem.Checked = false;
                txtBlokc.WordWrap = false;
            }
        }

        // pisava
        private void pisavaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult pisava = fdPisava.ShowDialog();
            fdPisava.ShowColor = true;

            // označeno besedilo se spremeni v željen font + neoznačeno besedilo "se nadaljuje" v željenem fontu... 
            if (pisava == DialogResult.OK)
            {
                if (txtBlokc.SelectionLength > 0)
                {
                    txtBlokc.SelectionFont = fdPisava.Font;
                    txtBlokc.SelectionColor = fdPisava.Color;
                } else if (txtBlokc.Text.Length > 0)
                {
                    txtBlokc.SelectionFont = fdPisava.Font;
                    txtBlokc.SelectionColor = fdPisava.Color;
                } else
                {
                    txtBlokc.Font = fdPisava.Font;
                    txtBlokc.ForeColor = fdPisava.Color;
                }
            }
        }

        // označi / highlight
        private void rumenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBlokc.SelectionBackColor = Color.Yellow;
            txtBlokc.SelectionColor = Color.Black;
        }

        private void rdečeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBlokc.SelectionBackColor = Color.Crimson;
            txtBlokc.SelectionColor = Color.Gainsboro;
        }

        private void zelenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBlokc.SelectionBackColor = Color.LawnGreen;
            txtBlokc.SelectionColor = Color.Black;
        }

        private void modroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBlokc.SelectionBackColor = Color.RoyalBlue;
            txtBlokc.SelectionColor = Color.White;
        }

        // krepko, ležeče, podčrtano, prečrtano
        private void krepkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBlokc.SelectionFont != null)
            {
                System.Drawing.Font trenutniFont = txtBlokc.SelectionFont;
                System.Drawing.FontStyle noviFontStil;

                if (txtBlokc.SelectionFont.Bold == true)
                {
                    noviFontStil = FontStyle.Regular;
                } else
                {
                    noviFontStil = FontStyle.Bold;
                }
                txtBlokc.SelectionFont = new Font(trenutniFont.FontFamily, trenutniFont.Size, noviFontStil);
            }
        }

        private void poševnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBlokc.SelectionFont != null)
            {
                System.Drawing.Font trenutniFont = txtBlokc.SelectionFont;
                System.Drawing.FontStyle noviFontStil;

                if (txtBlokc.SelectionFont.Italic == true)
                {
                    noviFontStil = FontStyle.Regular;
                } else
                {
                    noviFontStil = FontStyle.Italic;
                }
                txtBlokc.SelectionFont = new Font(trenutniFont.FontFamily, trenutniFont.Size, noviFontStil);
            }
        }

        private void podčrtanoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBlokc.SelectionFont != null)
            {
                System.Drawing.Font trenutniFont = txtBlokc.SelectionFont;
                System.Drawing.FontStyle noviFontStil;

                if (txtBlokc.SelectionFont.Underline == true)
                {
                    noviFontStil = FontStyle.Regular;
                } else
                {
                    noviFontStil = FontStyle.Underline;
                }
                txtBlokc.SelectionFont = new Font(trenutniFont.FontFamily, trenutniFont.Size, noviFontStil);
            }
        }

        private void prečrtanoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBlokc.SelectionFont != null)
            {
                System.Drawing.Font trenutniFont = txtBlokc.SelectionFont;
                System.Drawing.FontStyle noviFontStil;

                if (txtBlokc.SelectionFont.Strikeout == true)
                {
                    noviFontStil = FontStyle.Regular;
                }
                else
                {
                    noviFontStil = FontStyle.Strikeout;
                }
                txtBlokc.SelectionFont = new Font(trenutniFont.FontFamily, trenutniFont.Size, noviFontStil);
            }
        }

        // male in velike črke
        private void maleČrkeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBlokc.SelectedText = txtBlokc.SelectedText.ToLower();
        }

        private void vELIKEČRKEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBlokc.SelectedText = txtBlokc.SelectedText.ToUpper();
        }

        // bullets (pike)
        private void dodajPikoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                txtBlokc.BulletIndent = 10;
                txtBlokc.SelectionBullet = true;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Zgodila se je čudna napača. Poskusi še enkrat.");
            }
        }

        private void odstraniPikoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                txtBlokc.BulletIndent = 0;
                txtBlokc.SelectionBullet = false;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Zgodila se je čudna napača. Poskusi še enkrat.");
            }
            
        }

        // zoom
        private void povečajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBlokc.ZoomFactor < 64.5)
            {
                txtBlokc.ZoomFactor = txtBlokc.ZoomFactor + 0.25f;
            }
        }

        private void pomanjšajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBlokc.ZoomFactor > 0.515625)
            {
                txtBlokc.ZoomFactor = txtBlokc.ZoomFactor - 0.125f;
            }
        }

        private void prvotniPogledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBlokc.ZoomFactor > 1 || txtBlokc.ZoomFactor < 1)
            {
                txtBlokc.ZoomFactor = 1.0f;
            }
        }

        private void iščiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Iskalnik iskalnik = new Iskalnik();
            iskalnik.Show();
        }

        // pomoč
        private void pomočToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        // about
        private void oProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // izhod
        private void izhodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBlokc.Modified == true)
            {
                sfdShrani.Filter = "Blok'c besedila (*.txt)|*.txt|Vse datoteke (*.*)|*.*";
                sfdShrani.FileName = "Neimenovan Blok'c";
                DialogResult dg = MessageBox.Show("Ali želiš shraniti trenutni Blok'c?", "Shrani Blok'c?", MessageBoxButtons.YesNoCancel);

                if (dg == DialogResult.Yes)
                {
                    sfdShrani.ShowDialog();
                    using (var sw = new StreamWriter(sfdShrani.FileName))
                    {
                        sw.WriteLineAsync(txtBlokc.Text);
                    }
                }
                else if (dg == DialogResult.Cancel)
                {
                    // ...
                }
                else if (dg == DialogResult.No)
                {
                    txtBlokc.Clear();
                }
            } else
            {
                this.Close();
            }
        }
    }
}


// stara koda

/*
        private void statusnaVSprememba()
        {
            if (statusnaVrstica.Visible)
            {
                statusnaVrsticaToolStripMenuItem.Checked = false;
                statusnaVrstica.Visible = false;
            } else
            {
                statusnaVrsticaToolStripMenuItem.Checked = true;
                statusnaVrstica.Visible = true;
            }
        }

        private void statusnaVPosodobi()
        {
            int statusBarLine = txtBlokc.GetLineFromCharIndex(txtBlokc.GetFirstCharIndexOfCurrentLine());
            int statusBarColumn = txtBlokc.SelectionStart - txtBlokc.GetFirstCharIndexOfCurrentLine();
            lblStatusBar.Text = "Ln " + statusBarLine.ToString() + ", Col " + statusBarColumn.ToString();
        }

        private void txtBlokc_Changed (object sender, EventArgs e)
        {
            this.statusnaVPosodobi();
        }

        private void statusnaVrsticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusnaVSprememba();
        }
*/