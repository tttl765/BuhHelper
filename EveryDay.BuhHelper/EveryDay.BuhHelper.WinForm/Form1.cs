using EveryDay.BuhHelper.Console.Models;
using EveryDay.BuhHelper.Console.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveryDay.BuhHelper.WinForm
{
    public partial class Form1 : Form
    {
        private ICommandService CommandService { get; set; }

        private List<ICommand> Commands { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CommandService = new CommandService();

            // получить список команд
            Commands = CommandService.GetCommands("Ext");

            //cbCommands.Items.AddRange(Commands.Select(c => c.Name).ToArray());

            cbCommands.DataSource = Commands;
            cbCommands.DisplayMember = "Name";

            lblResult.Text = "";
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            var command = cbCommands.SelectedItem as ICommand;

            if (command != null)
            {
                var result = command.Exec(tbInput.Text);

                if (result.Success)
                {
                    lblResult.Text = result.Result;
                    lblResult.ForeColor = Color.Black;
                }
                else
                {
                    lblResult.Text = result.Error;
                    lblResult.ForeColor = Color.DarkOrange;
                }
            }
        }

        private void cbCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolTip.SetToolTip(this.button1, "");
            var command = cbCommands.SelectedItem as ICommandWithDesc;
            if(command != null)
            {
                //this.tbInput.Text = command.Description;
                this.tbInput.ForeColor = System.Drawing.SystemColors.ScrollBar;

                toolTip.SetToolTip(this.button1, command.Description);
            }
        }

        private void tbInput_Click(object sender, EventArgs e)
        {
            if(this.tbInput.ForeColor == System.Drawing.SystemColors.ScrollBar)
            {
                this.tbInput.ForeColor = System.Drawing.SystemColors.WindowText;
                tbInput.Text = "";
            }

            tbInput.SelectAll();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnExec_Click(sender, e);
        }
    }
}
