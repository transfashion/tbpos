using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TBPOS
{
    public partial class FormSplash : Form
    {
        public FormSplash()
        {
            InitializeComponent();
        }

        private void FormSplash_Load(object sender, EventArgs e)
        {

        }



        public void setStatus(string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(setStatus), status);
                return;
            }
            lblStatus.Text = status;
        }
    }
}
