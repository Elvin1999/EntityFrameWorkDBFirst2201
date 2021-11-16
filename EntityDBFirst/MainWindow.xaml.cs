using EntityDBFirst.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace EntityDBFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //add

           // Add();


            //Get();

            //Remove();

            //update
            //Update();


            Get();


        }
        public async Task<int> Remove()
        {
            using (var context = new LibraryEntities())
            {

                //remove
                //var book = context.Books.FirstOrDefault(b => b.Id == 13);
                //if (book != null)
                //{
                //    context.Books.Remove(book);
                //    context.SaveChanges();
                //}

                var book = context.Books.FirstOrDefault(b => b.Id ==1);
                context.Entry(book).State = EntityState.Deleted;
                var result=await context.SaveChangesAsync();

                return result;
            }
        }
        public async void Add()
        {
            using (var context = new LibraryEntities())
            {
                //var book = new Book
                //{
                //  AuthorId=1,
                //  CategoryId=1,
                //  Name="New Book",
                //  Pages=1100
                //};

                //context.Books.Add(book);
                //context.SaveChanges();


                //var book = new Book
                //{
                //    AuthorId = 1,
                //    CategoryId = 1,
                //    Name = "New Book",
                //    Pages = 1100
                //};

                //context.Entry(book).State = EntityState.Added;
                //var result=await context.SaveChangesAsync();
                //MessageBox.Show($"{result} affected");
            }
        }
        public async void Update()
        {
            using (var context = new LibraryEntities())
            {
                //update
                var book = context.Books.FirstOrDefault(b => b.Id == 7);
                book.Name = "C++ Book";
                context.Entry(book).State = EntityState.Modified;
                var result = await context.SaveChangesAsync();

                Get();
            }
        }

        public async void Get()
        {
            using (var context = new LibraryEntities())
            {

                var book = await context
                    .Books
                    .Include("Author") //Eager Loading  ,it brings navigation properties
                    .Include("Category")
                    .FirstOrDefaultAsync(b=>b.Id==3);
                var list = new List<Book>();
                list.Add(book);
                mydatagrid.ItemsSource = list;

                //var books = context.Books.ToList();
                //mydatagrid.ItemsSource = books;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var result=await Remove();
            Get();
        }
    }
}
