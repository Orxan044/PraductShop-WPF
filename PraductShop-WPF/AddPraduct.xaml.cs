﻿using Microsoft.Win32;
using PraductShop_WPF.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PraductShop_WPF;

public partial class AddPraduct : Window
{
    OpenFileDialog openFileDialog = new OpenFileDialog();
    private Product _product;

    public AddPraduct()
    {
        InitializeComponent();
        DataContext = this;
    }


    private void ImageShow_Click(object sender, RoutedEventArgs e)
    {
        openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg";
        openFileDialog.FilterIndex = 2;
        if (openFileDialog.ShowDialog() == true)
        {
            string selectedImagePath = openFileDialog.FileName;
            BitmapImage bitmap = new BitmapImage(new Uri(selectedImagePath));
            ImageBox.Source = bitmap;
        }
    }

    private void AddPraduct_Click(object sender, RoutedEventArgs e)
    {
        if (ImageBox is not null && txtBoxName is not null && double.TryParse(txtBoxPrice.Text, out double result))
        {
            _product = new()
            {
                Name = txtBoxName.Text,
                Price = result,
                Image = openFileDialog.FileName
            };
            ((MainWindow)Application.Current.MainWindow).Praducts.Add(_product);
            MessageBox.Show($"{txtBoxName.Text} Add Praduct !!!");
            txtBoxName.Text = null;
            ImageBox.Source = null;
            txtBoxPrice.Text = null;
        }
        else MessageBox.Show("Please Enter Correct Information !!!");
    }
}
