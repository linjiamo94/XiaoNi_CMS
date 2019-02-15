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
            /// �ɽ���
            /// </summary>
            Normal,

            /// <summary>
            /// ��������
            /// </summary>
            Readonly,

            /// <summary>
            /// �ѽ��
            /// </summary>
            Borrowed,

            /// <summary>
            /// ������
            /// </summary>
            ReBorrowed,

            /// <summary>
            /// ��ԤԼ
            /// </summary>
            Appointed
        }


        /// <summary>
        /// ���ڽ��ĵ��鼮��Ϣ
        /// </summary>
        public class Book
        {
            /// <summary>
            /// ������
            /// </summary>
            [Key]
            public string BarCode { get; set; }

            public string ISBN { get; set; }

            /// <summary>
            /// ����
            /// </summary>
            [Required]
            public string Name { get; set; }

            /// <summary>
            /// ȡ���
            /// </summary>
            public string FetchBookNumber { get; set; }

            /// <summary>
            /// �������
            /// </summary>
            //public Bookshelf Bookshelf { get; set; }
            public ICollection<Bookshelf> BookMiddles { get; set; }

            /// <summary>
            /// ���ʱ��
            /// </summary>
            public DateTime? BorrowTime { get; set; }

            /// <summary>
            /// ����ʱ��
            /// </summary>
            public DateTime? MatureTime { get; set; }

            /// <summary>
            /// ԤԼ�����������
            /// </summary>
            public DateTime? AppointedLatestTime { get; set; }

            /// <summary>
            /// ����״̬
            /// </summary>
            public BookState State { get; set; }

            /// <summary>
            /// �����ߣ�ָ�����
            /// </summary>
            public Student Keeper { get; set; }
        }

        /// <summary>
        /// �鼮�������ϸ��Ϣ
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
            /// ����ʱ��
            /// </summary>
            [Required]
            public DateTime PublishDateTime { get; set; }

            /// <summary>
            /// �鼮�汾
            /// </summary>
            [Required]
            public int Version { get; set; }

            /// <summary>
            /// ������̬������ҳ����ý�����Ϣ
            /// </summary>
            public string SoundCassettes { get; set; }

            /// <summary>
            /// ���
            /// </summary>
            public string Description { get; set; }
        }

        public class Bookshelf
        {
            /// <summary>
            /// ���ID
            /// </summary>
            [Key]
            public int BookshelfId { get; set; }

            /// <summary>
            /// ��ܵ��鼮���
            /// </summary>

            [Required]
            public string Sort { get; set; }
            /// <summary>
            /// ��Сȡ���
            /// </summary>
            [Required]
            public string MinFetchNumber { get; set; }
            [Required]
            public string MaxFetchNumber { get; set; }

            /// <summary>
            /// ���λ��
            /// </summary>
            [Required]
            public string Location { get; set; }

            /// <summary>
            /// ȫ������
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
            /// ����ʱ��
            /// </summary>
            [Required]
            public DateTime PublishDateTime { get; set; }

            /// <summary>
            /// �鼮�汾
            /// </summary>
            [Required]
            public int Version { get; set; }

            /// <summary>
            /// ������̬������ҳ����ý�����Ϣ
            /// </summary>
            public string SoundCassettes { get; set; }
        }

        public class Student : IdentityUser
        {
            /// <summary>
            /// ѧ��
            /// </summary>
            [ProtectedPersonalData]
            [RegularExpression("[UI]\\d{9}")]
            public override string UserName { get; set; }

            [Required]
            public string Name { get; set; }

            /// <summary>
            /// ѧλ���������ƽ�����Ŀ
            /// </summary>
            [Required]
            public Degrees Degree { get; set; }

            /// <summary>
            /// ��������Ŀ
            /// </summary>
            [Required]
            public int MaxBooksNumber { get; set; }

            /// <summary>
            /// �ѽ�ͼ��
            /// </summary>
            public IEnumerable<Book> KeepingBooks { get; set; }

            /// <summary>
            /// ԤԼ����
            /// </summary>
            public string AppointingBookBarCode { get; set; }

            [StringLength(14, MinimumLength = 11)]
            public override string PhoneNumber { get; set; }

            /// <summary>
            /// ����
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
        /// ����
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// ״̬ 1���� 0ɾ��
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime add_time { get; set; }
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        public DateTime modify_time { get; set; }
    }

    public class ContentViewModel
    {
        /// <summary>
        /// �����б�
        /// </summary>
        public List<Content> Contents { get; set; }
    }
}