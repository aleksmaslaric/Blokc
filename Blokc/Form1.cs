using System;
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
        public frmBlokc()
        {
            InitializeComponent();
        }

        private void novToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBlokc.Modified == true)
            {
                // kliče sfdShrani, če je v txtBlokc zaznana sprememba (zapisan text,...) in uporabnik pritisne na "Nov" v menustrip-u
                shraniToolStripMenuItem_Click(sender, e);
            }
        }

        private void odpriToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void shraniToolStripMenuItem_Click(object sender, EventArgs e)
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
            } else if (dg == DialogResult.Cancel)
            {
                // ...
            } else if (dg == DialogResult.No) 
            {
                txtBlokc.Clear();
            }
        }

        private void shraniKotToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pripravaStraniToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void natisniToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void razveljaviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // razveljavi
            txtBlokc.Undo();
        }

        private void povrniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // povrni
            txtBlokc.Redo();
        }

        private void izrežiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // izreži
            txtBlokc.Cut();
        }

        private void kopirajToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // kopiraj
            txtBlokc.Copy();
        }

        private void prilepiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // prilepi
            txtBlokc.Paste();
        }

        private void izbrišiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // izbriši
            txtBlokc.SelectedText = "";
        }

        private void izbrišiVseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // pred izbrisom vprašaj, če želiš vse izbrisati
            txtBlokc.Clear();
        }

        private void izberiVseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // izberi vse
            txtBlokc.SelectAll();
        }

        private void datumUraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBlokc.Text = Convert.ToString(DateTime.Now);
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // word wrap + pogojnik
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

        private void pisavaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void označiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void krepkoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void poševnoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void podčrtanoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void prečrtanoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void maleČrkeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vELIKEČRKEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dodajPikoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void odstraniPikoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void povečajToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pomanjšajToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void prvotniPogledToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pomočToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void oProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void izhodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
