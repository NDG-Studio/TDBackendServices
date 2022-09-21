
namespace SharedLibrary.Helpers
{
    public static class OperationMessages{
        public const string GeneralError = "Hata nedeniyle işleminiz gerçekleştirilemedi";

        public const string DbError = "Veritabanı hatası nedeni ile işlem gerçekleştirilemedi";
        public const string AuthenticateError = "Yanlış kullanıcı adı veya şifre";

        public const string DbItemNotFound = "Kayıt bilgisi bulunamadığından işlem gerçekleştirilemedi";

        public const string NoChanges = "Kayıtta değişiklik yapılmadığı için kayıt edilmedi.";

        public const string Success = "İşleminiz başarıyla gerçekleştirildi";

        public const string ModelStateNotValid = "Lütfen girilen bilgileri kontrol edip tekrar deneyiniz";

        public const string DuplicateRecord = "Bu kayıt daha önceden eklendiğinden tekrar eklenemez.";
        public const string DuplicateMail = "Bu mail sisteme kayıtlı!";

        public const string TokenFail = "İzinsiz giriş denemesi!";

        public const string UserAllreadyActive = "Kullanıcı zaten aktif olduğundan işleminiz gerçekleşmedi!";
        public const string ProcessAllreadyExist= "İşlem aktif olduğundan işleminiz gerçekleşmedi!";
        public const string InfoNull = "İşlemi gerçekleştirmek için yeterli bilgiye ulaşılamadı!";
        public const string HeroAllreadyMaxLevel = "Daha fazla yükseltilemez!";
        public const string PlayerHaveNoHero = "Kullanıcı işlem yapmak istediği heroya sahip değil!";
        public const string PlayerDoesNotHaveResource = "Kullanıcı gerekli kaynaklara sahip değil!";
        public const string TrainingMustBeDone = "Eğitimin bitmesini bekleyin!";
    }
}