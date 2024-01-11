﻿namespace Training.Service.ViewModel.BookWarehouse
{
    public class LibrarianViewModel
    {
        public LibrarianViewModel()
        { }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}