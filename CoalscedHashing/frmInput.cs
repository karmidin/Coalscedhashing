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
    public partial class frmInput : Form
    {
        TextBox[] txtInput;
        Label[] lblInput;
        int x, y,jumlah;
        int[] indexBilangan;

        public int[] IndexBilangan
        {
            get
            {
                return this.indexBilangan;
            }
            set
            {
                this.indexBilangan = value;
            }
        }

        public TextBox[] TxtInput
        {
            get
            {
                return this.txtInput;
            }
            set
            {
                this.txtInput = value;
            }
        }
        
        public frmInput(int _jumlah)
        {
            x=10;
            y=10;
            jumlah = _jumlah;
            indexBilangan = new int[jumlah];
            InitializeComponent();
            btnOk.DialogResult = DialogResult.OK;
            txtInput = new TextBox[_jumlah];
            lblInput = new Label[_jumlah];

            for (int i = 0; i < _jumlah; i++) {

                if (i == 10) {
                    x = 200;
                    y = 10;
                }

                txtInput[i] = new TextBox();
                lblInput[i] = new Label();

                txtInput[i].Width = 30;
                lblInput[i].Text = "Bilangan Ke -" + (i + 1);

                lblInput[i].Location = new Point(x, y);
                txtInput[i].Location = new Point(x+100, y);

                this.Controls.Add(lblInput[i]);
                this.Controls.Add(txtInput[i]);
                y = y + 40;

            }
        }
    }
}
