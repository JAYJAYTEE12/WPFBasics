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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFBasics
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		bool _working = false;

		public MainWindow()
		{
			InitializeComponent();

			DataContext = this;

			_worker.DoWork += (s, e) =>
			{
				for(int i = 0; i <= 100; i++)
				{
					System.Threading.Thread.Sleep(100);
					WorkerState = i;
				}
				MessageBox.Show("fin");
				Environment.Exit(2);
			};
		}

		private void SampleButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("wow very epic fortnite vbux! share width friend", "fortbnit vbux generate", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		private void AboutButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Created by JAYJAYTEE", "fortbnit vbux generate", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			Environment.Exit(1);
		}

		private BackgroundWorker _worker = new BackgroundWorker();
		private int _workerState;

		public event PropertyChangedEventHandler PropertyChanged;

		public int WorkerState
		{
			get { return _workerState; }
			set
			{
				_workerState = value;
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("WorkerState"));
			}
		}

		private void GenButton_Click(object sender, RoutedEventArgs e)
		{
			if(_working == false)
			{
				_worker.RunWorkerAsync();
				_working = true;
			}
		}
	}
}
