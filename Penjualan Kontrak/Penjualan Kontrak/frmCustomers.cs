using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Penjualan_Kontrak
{
    public partial class frmCustomers : Form
    {
        
        
        public frmCustomers()
        {
            InitializeComponent();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.tbl_Customers' table. You can move, or remove it, as needed.
            this.tbl_CustomersTableAdapter1.Fill(this.dataSet.tbl_Customers);
           
            //dgvTampil.DataSource = 
            dgvTampil.Columns[0].HeaderText = "ID";
            dgvTampil.Columns[1].HeaderText = "Customers";
            cboFilter.Items.Add("Semua");
            cboFilter.Items.Add("Aktif");
            cboFilter.Items.Add("Non Aktif");
            cboFilter.SelectedIndex = 0;

        }

        

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cboFilter.SelectedIndex == 0)
            {
                dataSet.DataCustomers.DefaultView.RowFilter = "";
                dgvTampil.DataSource = dataSet.DataCustomers.DefaultView;
            }
            else if (cboFilter.SelectedIndex == 1)
            {
                dataSet.DataCustomers.DefaultView.RowFilter = "status_order = '" + cboFilter.SelectedItem + "'";
                dgvTampil.DataSource = dataSet.DataCustomers.DefaultView;

            }
            else if (cboFilter.SelectedIndex == 2)
            {
                dataSet.DataCustomers.DefaultView.RowFilter = "status_order = '" + cboFilter.SelectedItem + "'";
                dgvTampil.DataSource = dataSet.DataCustomers.DefaultView;
            }
        }

        private void dgvTampil_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgvTampil.Rows.Count - 2)
            {
                lblID.Text= dgvTampil.Rows[e.RowIndex].Cells[0].Value.ToString();
                tabControl1.SelectedIndex = 0;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            Class.dr = dataSet.tbl_Customers.NewRow();
            Class.dr["nama_perusahaan"] = txtNamaPerusahaan.Text;
            Class.dr["alamat"] = txtAlamat.Text;
            Class.dr["kecamatan"] = txtKecamatan.Text;
            Class.dr["kota"] = txtKota.Text;
            Class.dr["provinsi"] = txtProvinsi.Text;
            Class.dr["kode_pos"] = txtPos.Text;
            Class.dr["npwp"] = txtnpwp.Text;
            Class.dr["phone"] = txtPhone.Text;
            Class.dr["email"] = txtEmail.Text;
            Class.dr["nama_direksi"] = txtDireksi.Text;
            Class.dr["Status_order"] = "Non Aktif";
            dataSet.tbl_Customers.Rows.Add(Class.dr);

            Class.cbl = new SqlCommandBuilder();
        }


    }
}
