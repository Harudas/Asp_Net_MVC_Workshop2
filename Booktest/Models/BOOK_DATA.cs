using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booktest.Models
{//test2333
    public class BOOK_DATA
    {
        [DisplayName("書名")]
        public string BOOK_NAME { get; set; }
        [DisplayName("書ID")]
        public string BOOK_ID { get; set; }
        [DisplayName("書籍類別")]
        public string BOOK_CLASS_ID { get; set; }

        [DisplayName("購書日期")]
        public string BOOK_BOUGHT_DATE { get; set; }
        [DisplayName("借閱狀態")]
        public string BOOK_STATUS { get; set; }

        [DisplayName("出版商")]
        public string BOOK_PUBLISHER        { get; set; }
        [DisplayName("內容簡介")]
        public string BOOK_NOTE        { get; set; }

        [DisplayName("類別名稱")]
        public string BOOK_CLASS_NAME { get; set; }
        [DisplayName("借閱型態")]
        public string CODE_ID { get; set; }
        [DisplayName("借閱狀態")]
        public string CODE_NAME { get; set; }
        [DisplayName("借閱人")]
        public string BOOK_KEEPER { get; set; }
    }
}