using Reader.Business.Exceptions;
using Reader.Business.Helpers;
using Reader.Interfaces;
using System;
using System.Windows.Forms;

namespace Reader
{
    public partial class Main : Form
    {
        private IFileReader _fileReader;

        public Main()
        {
            InitializeComponent();

            btnPrevious.Enabled = false;
            btnFirst.Enabled = false;

            btnNext.Enabled = false;
            btnLast.Enabled = false;
        }

        private void btnLoadBook_Click(object sender, EventArgs e)
        {
            if (ofdBooks.ShowDialog() == DialogResult.OK)
            {
                HandleExceptions(() => {
                    _fileReader = FileReaderInitializeHelper.GetReader(ofdBooks.FileName);
                    _fileReader.LoadFile(ofdBooks.FileName);
                    SetPageText(_fileReader.FirstPage);
                });
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            HandleExceptions(() => SetPageText(_fileReader.FirstPage));
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            HandleExceptions(() => SetPageText(_fileReader.PreviousPage));
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            HandleExceptions(() => SetPageText(_fileReader.NextPage));
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            HandleExceptions(() => SetPageText(_fileReader.LastPage));
        }

        private void SetPageText(string pageText)
        {
            tbPage.Text = pageText;

            SetNavigationButtonsEnabling();
        }

        private void SetNavigationButtonsEnabling()
        {
            btnPrevious.Enabled = !_fileReader.IsFirstPage;
            btnFirst.Enabled = !_fileReader.IsFirstPage;

            btnNext.Enabled = !_fileReader.IsLastPage;
            btnLast.Enabled = !_fileReader.IsLastPage;
        }

        private void HandleExceptions(Action action)
        {
            try
            {
                action();
            }
            catch(PageOutOfRangeException)
            {
                MessageBox.Show("You are trying to see page out of range");
            }
            catch (WrongFileFormatException)
            {
                MessageBox.Show("You are trying to load file in wrong format");
            }
            catch (FileNotExistException)
            {
                MessageBox.Show("You are trying to load file that does not exist");
            }
            catch (FileNotLoadException)
            {
                MessageBox.Show("You did not load file");
            }
            catch (UnknownFileFormat)
            {
                MessageBox.Show("You are trying to load unknown file format");
            }
        }
    }
}
