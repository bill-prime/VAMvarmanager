using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VAMvarmanager
{
    public partial class frmDuplicateItemManager : Form
    {
        private frmVARManager _frmVM;
        private List<string> _mastervars;
        private List<string> _masteritems;

        public frmDuplicateItemManager(frmVARManager frmVM)
        {
            InitializeComponent();
            _frmVM = frmVM;

            try 
            { 
                var mv = (System.Collections.Specialized.StringCollection)Properties.Settings.Default["mastervars"];
                _mastervars = mv.Cast<string>().ToList();
            }
            catch
            {
                Properties.Settings.Default["mastervars"] = null;
                Properties.Settings.Default.Save();
            }

            try
            {
                var mi = (System.Collections.Specialized.StringCollection)Properties.Settings.Default["masteritems"];
                _masteritems = mi.Cast<string>().ToList();
            }
            catch
            {
                Properties.Settings.Default["masteritems"] = null;
                Properties.Settings.Default.Save();
            }

        }

        private void frmDuplicateItemManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            _frmVM.Show();
        }
    }
}
