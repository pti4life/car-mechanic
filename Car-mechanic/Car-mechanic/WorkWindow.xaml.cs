using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Car_mechanic.DataProviders;
using Car_mechanic.Modells;

namespace Car_mechanic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        private Work _work;
        public WorkWindow(Work work)
        {
            InitializeComponent();

            _work = work;
            DetailOfIssues.Content = _work.DetailOfIssues;
            CarLicensePlate.Content = _work.CarLicensePlate;
            StateOfWork.Text = _work.StateOfWork;

        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            _work.StateOfWork = StateOfWork.Text;
            WorkDataProvider.UpdateWork(_work);

            DialogResult = true;
            Close();
        }
    }
}
