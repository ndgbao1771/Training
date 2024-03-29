﻿using Training.Service.ViewModel.BookWarehouse;

namespace Training.Service.Interfaces
{
    public interface IBookService
    {
        List<BookViewModel> GetAll(string? keyword);

        BookViewModel GetById(int id);

        BookViewUpdateModel Add(BookViewUpdateModel bookViewUpdateModel);

        void Update(BookViewUpdateModel bookViewUpdateModel);

        void Delete(int id);
    }
}