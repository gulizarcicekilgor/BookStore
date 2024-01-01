using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public int BookId {get; set;}
    
        public GetBookDetailQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).FirstOrDefault(); //singleordefult hata veriyor
            if(book is null)
                throw new InvalidCastException("Kitap bulunamadı");
            //book 'u view modele maplame işlemi
            //ilk olarak view model nenesi oluşturmak gerekiyor.
            BookDetailViewModel vm = new BookDetailViewModel();
            vm.Title = book.Title;
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            return vm;
        }

    }

    //her view için model oluşturulmalı
    public class BookDetailViewModel
    {
        public string Title {get; set;}
        public string Genre {get; set;}
        public int PageCount {get; set;}
        public string PublishDate {get; set;}


    }

}