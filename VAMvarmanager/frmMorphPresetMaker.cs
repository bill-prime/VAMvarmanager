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

    public partial class frmMorphPresetMaker : Form
    {
        private frmVARManager _frmVM;
        private List<varmanager.varfile> _lstMorphVars;
        private List<string> _lstSelectedVars;

        public frmMorphPresetMaker(frmVARManager frmVM)
        {
            InitializeComponent();
            _frmVM = frmVM;

            _lstMorphVars = _frmVM.vm.GetMorphVars();

            _lstSelectedVars = new List<string>();

            this.clbMorphvars.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbMorphvars_ItemCheck);

            comboSex.Items.Clear();
            comboSex.Items.Add("female");
            comboSex.Items.Add("male");
            comboSex.SelectedIndex = 0;
            clbMorphvars.Items.Clear();

            foreach(var varfile in _lstMorphVars)
            {
                clbMorphvars.Items.Add(varfile.fi.Name,false);
            }

            clbMorphvars.Sorted = true;
        }

        private void clbMorphvars_ItemCheck(Object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                if (!_lstSelectedVars.Contains(clbMorphvars.GetItemText(clbMorphvars.Items[e.Index])))
                {
                    _lstSelectedVars.Add(clbMorphvars.GetItemText(clbMorphvars.Items[e.Index]));
                }
            }
            else
            {
                if (_lstSelectedVars.Contains(clbMorphvars.GetItemText(clbMorphvars.Items[e.Index])))
                {
                    _lstSelectedVars.Remove(clbMorphvars.GetItemText(clbMorphvars.Items[e.Index]));
                }
            }
        }
        private void txtNameFilter_TextChanged(object sender, EventArgs e)
        {
            clbFilter(ref clbMorphvars, txtNameFilter.Text);
        }

        private void clbFilter(ref CheckedListBox clb, string strfilter)
        {
            var itemsNeeded = from varFile in _lstMorphVars
                              where varFile.fi.Name.Contains(strfilter, StringComparison.OrdinalIgnoreCase)
                              select varFile.fi.Name;

            //Add Items
            foreach (var i in itemsNeeded)
            {
                if (!clb.Items.Contains(i))
                {
                    if (_lstSelectedVars != null)
                    {
                        if (_lstSelectedVars.Contains(i)) { clb.Items.Add(i, true); }
                        else { clb.Items.Add(i, false); }
                    }
                    else { clb.Items.Add(i, false); }
                }
            }

            //Remove Iitems
            for (int i = clb.Items.Count - 1; i >= 0; i--)
            {
                if (!itemsNeeded.Contains(clb.Items[i].ToString()))
                {
                    clb.Items.RemoveAt(i);
                }
            }

            clb.Sorted = true;

        }

        private void btnSaveMorphPreset_Click(object sender, EventArgs e)
        {

        }

        private void btnReturnToVM_Click(object sender, EventArgs e)
        {

        }
    }
}
