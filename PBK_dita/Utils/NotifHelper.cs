namespace PBK_dita.Utils
{
    public class NotifHelper
    {
        public bool Type { get; set; }
        public string Message { get; set; }
    }
    
    public class NotifMessage
    {
        public static string AddSuccess = "Data berhasil ditambahkan";
        public static string AddFailed = "Data gagal ditambahkan";
        public static string EditSuccess = "Data berhasil diubah";
        public static string EditFailed = "Data gagal diubah";
        public static string DeleteSuccess = "Data berhasil dihapus";
        public static string DeleteFailed = "Data gagal dihapus";
        public static string NotExist = "Data tidak ditemukan";
        
    }
}