using DomainLogic;
using Interfaces;
using LibraryCache;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace UI
{
    public partial class AssemblyChooser : Form
    {
        public AssemblyChooser()
        {
            InitializeComponent();
        }

        private void btnLoadUsers_Click(object sender, EventArgs e)
        {
            var userHandler = new UserHandler();
            var users = userHandler.GetUsers();
            lbUsers.Items.Clear();

            foreach (var user in users)
            {
                lbUsers.Items.Add(user);
            }
        }

        List<Type> types = new List<Type>();

        private void Form1_Load(object sender, EventArgs e)
        {
            var assemblyNames = Directory.GetFiles(".", "*.dll");
            foreach (var assemblyName in assemblyNames)
            {
                Assembly a = Assembly.LoadFrom(assemblyName);
                var matchingType = a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IRepository))).FirstOrDefault();
                if (matchingType != null)
                {
                    types.Add(matchingType);
                }
            }

            comboBox1.Items.AddRange(types.ToArray());
            comboBox1.SelectedValueChanged += ComboBox1_SelectedValueChanged;
        }

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Cache.ForceInterfaceMapping(typeof(IRepository), (Type)comboBox1.SelectedItem);
        }
    }
}
