using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace M014;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
		CB.ItemsSource = new List<string>() { "1", "2", "3" };
		LB.ItemsSource = new List<string>() { "1", "2", "3" };
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		TB.Text = "Ein Text";
		MessageBoxResult res = MessageBox.Show("Möchtest du beenden?", "Beenden", MessageBoxButton.YesNo, MessageBoxImage.Question);
		if (res == MessageBoxResult.Yes)
		{
			Environment.Exit(0);
		}
		else
		{
			TB.Text = "Beenden abgebrochen";
		}
	}

	private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		TB.Text = e.AddedItems[0] + " wurde ausgewählt";
	}

	private void LB_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
	{
		TB.Text = string.Join(',', LB.SelectedItems.OfType<string>()) + " wurde ausgewählt";
	}

	private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
	{
		TB.Text = "Checkbox ungechecked";
	}

	private void CheckBox_Checked(object sender, RoutedEventArgs e)
	{
		TB.Text = "Checkbox gechecked";
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		Window1 w1 = new Window1();
		//w1.Show();
		w1.ShowDialog();
	}

	private void Button_Click_2(object sender, RoutedEventArgs e)
	{
		Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
		bool oeffnenGeklickt = ofd.ShowDialog() == true;
		if (oeffnenGeklickt)
		{
			string filePath = ofd.FileName;
			TB.Text = File.ReadAllText(filePath);
		}
	}
}
