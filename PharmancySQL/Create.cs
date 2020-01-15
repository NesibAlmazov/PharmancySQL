using PharmancySQL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmancySQL
{
    public partial class Create : Form
    {
        private AptekEntities _db;
        private ComboBox _cmb;
        public Create( ComboBox cmb)
        {
            _cmb = cmb;
            _db = new AptekEntities();
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string name = textnamecrt.Text.Trim();
            if (name =="")
            {
                MessageBox.Show("Fill All Input", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_db.DrugsTypes.Any(t=> t.Name==name))
            {
                MessageBox.Show($"{name} already exits", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DrugsType type = new DrugsType { Name = name };
            _db.DrugsTypes.Add(type);
            await _db.SaveChangesAsync();
            
            MessageBox.Show("Successfully added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
            textnamecrt.Text = "";

            _cmb.Items.Clear();
            _cmb.Items.AddRange(_db.DrugsTypes.Select(dt => new CB_DrugsType
            {
                Id = dt.Id,
                Name = dt.Name
            }).ToArray());
        }

        
    }
    
}
