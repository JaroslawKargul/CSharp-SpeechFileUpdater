using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpeechFileUpdater.Forms
{
    public partial class PleaseWaitForm : Form
    {
        public PleaseWaitForm()
        {
            InitializeComponent();
        }

        private void CenterParent(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}
