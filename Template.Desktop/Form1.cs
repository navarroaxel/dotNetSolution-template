using System;
using System.Windows.Forms;
using Template.Core.Model.Entities;
using Template.Core.Repositories;

namespace Template.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var user = Repository.LocateIt<IUsersRepository>().Get(1);

            if (user == null)
            {
                Persist.It(() =>
                {
                    user = new User { Username = "test" };
                    // After add the user to the context, we need to persist the context.
                    Repository.LocateIt<IUsersRepository>().Add(user);
                });
            }

            MessageBox.Show(user.Id.ToString());
        }
    }
}
