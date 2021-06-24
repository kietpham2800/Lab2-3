using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Book
    {
        private int id;
        private string tittle;
        private string author;
        private string image_cover;

        public Book() { }
        public Book(int id,string tittle, string author, string image_cover)
        {
            this.id = id;
            this.tittle = tittle;
            this.author = author;
            this.image_cover = image_cover;
        }
        public int Id
        {
            get { return id; }
            set { Id = value; }
        }
        [Required(ErrorMessage ="Tiêu đề không được bỏ trống")]
        [StringLength(250,ErrorMessage ="Tiêu đề sách không vượt quá 250 kí tự")]
        [Display(Name ="Tiêu đề")]
        public string Tiitle
        {
            get { return tittle; }
            set { Tiitle = value; }
        }
        public string Author
        {
            get { return author; }
            set { Author = value; }
        }
        public string ImageCover
        {
            get { return image_cover; }
            set { ImageCover = value; }
        }
        

    }
}