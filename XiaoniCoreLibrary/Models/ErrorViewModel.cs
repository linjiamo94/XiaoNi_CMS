using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XiaoniCoreLibrary.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

  
        public class Entity
        {
        }
        public enum Degrees
        {
            CollegeStudent,
            Postgraduate,
            DoctorateDegree
        }
        public enum BookState
        {
            /// <summary>
            /// 可借阅
            /// </summary>
            Normal,

            /// <summary>
            /// 管内阅览
            /// </summary>
            Readonly,

            /// <summary>
            /// 已借出
            /// </summary>
            Borrowed,

            /// <summary>
            /// 被续借
            /// </summary>
            ReBorrowed,

            /// <summary>
            /// 被预约
            /// </summary>
            Appointed
        }


        /// <summary>
        /// 用于借阅的书籍信息
        /// </summary>
        public class Book
        {
            /// <summary>
            /// 条形码
            /// </summary>
            [Key]
            public string BarCode { get; set; }

            public string ISBN { get; set; }

            /// <summary>
            /// 书名
            /// </summary>
            [Required]
            public string Name { get; set; }

            /// <summary>
            /// 取书号
            /// </summary>
            public string FetchBookNumber { get; set; }

            /// <summary>
            /// 所在书架
            /// </summary>
            //public Bookshelf Bookshelf { get; set; }
            public ICollection<Bookshelf> BookMiddles { get; set; }

            /// <summary>
            /// 借出时间
            /// </summary>
            public DateTime? BorrowTime { get; set; }

            /// <summary>
            /// 到期时间
            /// </summary>
            public DateTime? MatureTime { get; set; }

            /// <summary>
            /// 预约最晚借书日期
            /// </summary>
            public DateTime? AppointedLatestTime { get; set; }

            /// <summary>
            /// 借阅状态
            /// </summary>
            public BookState State { get; set; }

            /// <summary>
            /// 持有者，指定外键
            /// </summary>
            public Student Keeper { get; set; }
        }

        /// <summary>
        /// 书籍自身的详细信息
        /// </summary>
        public class BookDetails
        {
            [Key]
            public string ISBN { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Author { get; set; }
            [Required]
            public string Press { get; set; }

            /// <summary>
            /// 出版时间
            /// </summary>
            [Required]
            public DateTime PublishDateTime { get; set; }

            /// <summary>
            /// 书籍版本
            /// </summary>
            [Required]
            public int Version { get; set; }

            /// <summary>
            /// 载体形态，包括页数、媒介等信息
            /// </summary>
            public string SoundCassettes { get; set; }

            /// <summary>
            /// 简介
            /// </summary>
            public string Description { get; set; }
        }

        public class Bookshelf
        {
            /// <summary>
            /// 书架ID
            /// </summary>
            [Key]
            public int BookshelfId { get; set; }

            /// <summary>
            /// 书架的书籍类别
            /// </summary>

            [Required]
            public string Sort { get; set; }
            /// <summary>
            /// 最小取书号
            /// </summary>
            [Required]
            public string MinFetchNumber { get; set; }
            [Required]
            public string MaxFetchNumber { get; set; }

            /// <summary>
            /// 书架位置
            /// </summary>
            [Required]
            public string Location { get; set; }

            /// <summary>
            /// 全部藏书
            /// </summary>
            public ICollection<Book> Books { get; set; }
        }

        public class RecommendedBook
        {
            [Key]
            public string ISBN { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Author { get; set; }
            [Required]
            public string Press { get; set; }

            /// <summary>
            /// 出版时间
            /// </summary>
            [Required]
            public DateTime PublishDateTime { get; set; }

            /// <summary>
            /// 书籍版本
            /// </summary>
            [Required]
            public int Version { get; set; }

            /// <summary>
            /// 载体形态，包括页数、媒介等信息
            /// </summary>
            public string SoundCassettes { get; set; }
        }

        public class Student : IdentityUser
        {
            /// <summary>
            /// 学号
            /// </summary>
            [ProtectedPersonalData]
            [RegularExpression("[UI]\\d{9}")]
            public override string UserName { get; set; }

            [Required]
            public string Name { get; set; }

            /// <summary>
            /// 学位，用来限制借书数目
            /// </summary>
            [Required]
            public Degrees Degree { get; set; }

            /// <summary>
            /// 最大借书数目
            /// </summary>
            [Required]
            public int MaxBooksNumber { get; set; }

            /// <summary>
            /// 已借图书
            /// </summary>
            public IEnumerable<Book> KeepingBooks { get; set; }

            /// <summary>
            /// 预约的书
            /// </summary>
            public string AppointingBookBarCode { get; set; }

            [StringLength(14, MinimumLength = 11)]
            public override string PhoneNumber { get; set; }

            /// <summary>
            /// 罚款
            /// </summary>
            public decimal Fine { get; set; }
        }

        public class Admin
        {
            [Key]
            public string UserName { get; set; }

            [Required]
            public string PhoneNumber { get; set; }

            [Required]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }
        
    }
    public class Content
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 状态 1正常 0删除
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime add_time { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime modify_time { get; set; }
    }

    public class ContentViewModel
    {
        /// <summary>
        /// 内容列表
        /// </summary>
        public List<Content> Contents { get; set; }
    }
}