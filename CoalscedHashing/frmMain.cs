using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoalscedHashing
{
    public partial class frmMain : Form
    {
        frmInput formInput;
        Inserting insrt;
        Searching scrt;

        int jumlahBilangan = 0;
        int bilanganCari = 0;
        int[] indexBilangan;

        public frmMain()
        {
            InitializeComponent();
            txtCari.ReadOnly = true;
            btnCari.Enabled = false;
        }


        private void btnInput_Click(object sender, EventArgs e)
        {
            string data, link;
            try
            {
                if (int.Parse(txtJumlah.Text) <= 20)
                {
                    if (ShowInputForm() == false)
                    {

                        rtbInput.Text = "DAFTAR BILANGAN : ";
                        for (int i = 0; i < indexBilangan.Length; i++)
                        {
                            rtbInput.Text = rtbInput.Text + indexBilangan[i] + "   |   ";
                        }

                        insrt = new Inserting(indexBilangan.Length, indexBilangan);

                        rtbInput.Text = rtbInput.Text + insrt.prosesInput() +"\n";

                        rtbInput.Text = rtbInput.Text + "\n\nHASIL INSERT \n\n|  ADDR  |  DATA  |  LINK  |\n";
                        for (int i = 0; i < insrt.Input; i++)
                        {
                            data = (insrt.IndexData[i] != -1) ? insrt.IndexData[i].ToString() : " ";
                            link = (insrt.IndexLink[i] != -1) ? insrt.IndexLink[i].ToString() : " ";
                            rtbInput.Text = rtbInput.Text + "|     " + i + "     |     " + data + "     |     " + link + "     |" + "\n";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Maaf nilai maksimal jumlah bilangan adalah 20","Message",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Harap mengisi jumlah dengan benar !","Alert",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ShowInputForm()
        {
            bool close;
            jumlahBilangan = int.Parse(txtJumlah.Text);

            formInput = new frmInput(jumlahBilangan);

            if (formInput.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    indexBilangan = new int[jumlahBilangan];
                    for (int i = 0; i < jumlahBilangan; i++)
                    {
                        indexBilangan[i] = int.Parse(formInput.TxtInput[i].Text);
                    }
                   

                    btnInput.Enabled = false;
                    txtJumlah.ReadOnly = true;
                    close = false;
                    txtCari.ReadOnly = false;
                    btnCari.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Harap mengisi jumlah dengan benar !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    close = true;
                }
                
            }
            else
            {
                close = true;
            }

            return close;
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                scrt = new Searching(insrt.IndexData, insrt.IndexLink, insrt.Input);
                bilanganCari = int.Parse(txtCari.Text);
                rtbSearch.Text = rtbSearch.Text + scrt.prosesSearching(bilanganCari) + "\n";
            }
            catch (Exception ex) {
                MessageBox.Show("Harap mengisi jumlah dengan benar !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            rtbInput.Text = "";
            rtbSearch.Text = "";
            jumlahBilangan = 0;
            bilanganCari = 0;
            txtJumlah.Text = "";
            txtCari.Text = "";
            btnInput.Enabled = true;
            txtJumlah.ReadOnly = false;
            btnCari.Enabled = false;
            txtCari.ReadOnly = true;
        }


    }
}
