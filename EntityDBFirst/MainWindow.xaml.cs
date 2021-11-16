using EntityDBFirst.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public MainWindow()
        {
            InitializeComponent();

            //add

            Add();


            //Get();

            //Remove();

            //update
            //Update();


            Get();
            this.DataContext = this;

        }
       
        public  void Add()
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
                //var result =  context.SaveChanges();
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

        public void Get()
        {
            using (var context = new LibraryEntities())
            {

                //var book = await context
                //    .Books
                //    .Include("Author") //Eager Loading  ,it brings navigation properties
                //    .Include("Category")
                //    .FirstOrDefaultAsync(b=>b.Id==3);
                //var list = new List<Book>();
                //list.Add(book);
                //mydatagrid.ItemsSource = list;

                //mydatagrid.ItemsSource = context.MyBooks.ToList();
                //mydatagrid.ItemsSource = context.GetBookById(2).ToList();

                var books = new ObservableCollection<Book>(context.Books.Include("Author").ToList());
                AllBooks = books;
            }
        }
        public async void Remove()
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
                Thread.Sleep(4000);
                var book = context.Books.FirstOrDefault(b => b.Id == 17);
                context.Entry(book).State = EntityState.Deleted;
                var result = await context.SaveChangesAsync();
                var books = new ObservableCollection<Book>(context.Books.Include("Author").ToList());
                AllBooks = books;
            }
        }
        private ObservableCollection<Book> allBooks;

        public ObservableCollection<Book> AllBooks
        {
            get { return allBooks; }
            set { allBooks = value; OnPropertyChanged(); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task(Remove);
            task.Start();
            
        }
    }
}
