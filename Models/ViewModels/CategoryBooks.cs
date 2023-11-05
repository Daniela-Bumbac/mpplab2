namespace Bumbac_Daniela_Lab2.Models.ViewModels
{
    public class CategoryBooks
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
