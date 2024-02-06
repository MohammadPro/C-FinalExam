using Microsoft.EntityFrameworkCore;
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
using WpfApp1.Context;
using WpfApp1.Entities;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _context;

        public MainWindow(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
            LoadUser();
        }

        public void LoadUser()
        {
            dogList.Items.Clear();
            var dogs = _context.dogs!.AsNoTracking().ToList();

            foreach (var dog in dogs)
            {
                dogList.Items.Add(dog);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dog dog = new Dog();

            
            dog.Name = userNameInp.Text;
            dog.Gender = userLastnameInp.Text;

            _context.dogs!.Add(dog);
            _context.SaveChanges();

            LoadUser();
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            int index = dogList.SelectedIndex;
            if (index == -1) return;

            Dog dog = (Dog)dogList.Items[index];
            dog.Name = userNameInp.Text;
            dog.Gender = userLastnameInp.Text;
            _context.dogs!.Update(dog);

            _context.SaveChanges();
            LoadUser();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int index = dogList.SelectedIndex;

            if (index == -1) return;

            Dog dog = (Dog)dogList.Items[index];

            _context.dogs!.Remove(dog);

            _context.SaveChanges();
            LoadUser();
        }

        public void LoadUser_1()
        {
            toyList.Items.Clear();
            var myToys = _context.toys!.AsNoTracking().ToList();

            foreach (var myToy in myToys)
            {
                toyList.Items.Add(myToys);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Toy toy = new Toy();
            toy.Id = Guid.NewGuid();
            toy.DogId = Guid.NewGuid();
            toy.YearOfManufacture = yearofManufactureInput.Text;
            toy.Weight = WeightInput.Text;

            _context.toys!.Add(toy);
            _context.SaveChanges();

            LoadUser_1();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            int index = toyList.SelectedIndex;

            if (index == -1) return;

            Toy toy = (Toy)dogList.Items[index];

            _context.toys!.Remove(toy);

            _context.SaveChanges();
            LoadUser_1();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int index = toyList.SelectedIndex;
            if (index == -1) return;

            Toy toy = (Toy)toyList.Items[index];
            toy.YearOfManufacture = yearofManufactureInput.Text;
            toy.Weight = WeightInput.Text;
            _context.toys!.Update(toy);

            _context.SaveChanges();
            LoadUser_1();
        }

       
    }
}
