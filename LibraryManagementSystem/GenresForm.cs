using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class GenresForm : Form
    {
        public GenresForm()
        {
            InitializeComponent();
        }

        Genre genre = new Genre();

        private void GenresForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string name = txtName.Text;

            if (name.Trim().Equals(""))
            {
                MessageBox.Show("Enter the Genre Name",
                    "Empty Genre",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                if (genre.addGenre(name))
                {
                    MessageBox.Show("New Genre Added Successfully",
                        "New Genre",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    dgGenres.DataSource = genre.GenreList();
                }
                else
                {
                    MessageBox.Show("Genre Not Added",
                        "Add Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                string name = txtName.Text;

                if (name.Trim().Equals(""))
                {
                    MessageBox.Show("Enter the Genre Name",
                        "Empty Genre",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    if (genre.editGenre(id, name))
                    {
                        MessageBox.Show("Genre Name Update Successfully",
                            "Edit Genre",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        dgGenres.DataSource = genre.GenreList();
                    }
                    else
                    {
                        MessageBox.Show("Genre Not Update",
                            "Edit Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid ID");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);

                if (genre.removeGenre(id))
                {
                    MessageBox.Show("Genre delete Successfully",
                        "Delete Genre",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    txtId.Text = "";
                    txtName.Text = "";

                    dgGenres.DataSource = genre.GenreList();
                }
                else
                {
                    MessageBox.Show("Genre Not Deleted",
                        "Delete Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid ID");
            }
        }

        private void dgGenres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgGenres.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dgGenres.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
