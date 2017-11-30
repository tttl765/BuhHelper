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
                }
                else
                {
                    lblResult.Text = "";
                    MessageBox.Show($"{result.Error}{Environment.NewLine}------------------{Environment.NewLine}Вы ничего не можете с этим сделать...", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
        private void cbCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblResult.Text = "";
            var command = cbCommands.SelectedItem as ICommandWithDesc;
            if(command != null)
            {
                lblResult.Text = command.Description;
            }
            ////если при смене команды поле с даднными не пустое, то запросить, нужно ли удалять
            ////но мне также нравится идея, что после выбора команды атоматически вставать 
            //на поле с данными и выделять текст.
            //У обоих вариантотв есть плюсы и минусы:
            //всплывающее окно - отвлечение и доп. нажатие кнопки
            //перемещение на поле с данными и выделение текста:
            //- автоматическое перескакивание - не есть хорошо, например, если не ту команду выбрали,
            //    а без перескакивания могут забыть исправить данные;
            //- выделение текста повышение вероятности, что стерут текст случайно.
            //Выберу первый вариант, на ночь глядя больше ничего не придумывается
            ////А вот если получить возможность использовать в ЭЛМЕ редактируемую таблицу без отдельного окна
            //    и я была бы почти абсолютно счастлива;) а пользователи как были бы счастливы!

            if (tbInput == null)
            {
                const string message =
                "Вы сменили команду. Удалить ранее указанные данные?";
                const string caption = "Вопрос";
                var resultFormMessageBox = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                // If the no button was pressed ...
                if (resultFormMessageBox == DialogResult.Yes)
                {
                    tbInput = null;
                }
            }
        }
    }
}
