
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
        public const string HeroAllreadyExist= "Oyuncu heroya zaten sahip!";
        public const string InfoNull = "İşlemi gerçekleştirmek için yeterli bilgiye ulaşılamadı!";
        public const string HeroAllreadyMaxLevel = "Daha fazla yükseltilemez!";
        public const string PlayerHaveNoHero = "Kullanıcı işlem yapmak istediği heroya sahip değil!";
        public const string PlayerHeroBusy = "Kullanıcının işlem yapmak istediği hero müsait değil!";
        public const string PlayerIsUnderProtection = "Saldırı yapmak için her iki tarafın da prison,hospital ve barrack binaları olmalı ";
        public const string PlayerDoesNotHaveResource = "Kullanıcı gerekli kaynaklara sahip değil!";
        public const string TrainingMustBeDone = "Eğitimin bitmesini bekleyin!";
        public const string HealingMustBeDone = "İyileştirme işleminin bitmesini bekleyin!";
        public const string UpgradingMustBeDone = "Bina yükseltme işleminin bitmesini bekleyin!";
        public const string ItemNotUsable = "Bu item kullanılamaz!";
        public const string MaxLevel = "Tebrikler son seviyedesiniz.";
        public const string InputError = "Beklenen input değerine ulaşılamadı!!";
        public const string PlayerAllreadyGangMember = "Oyuncu zaten bir çete üyesi!!";
        public const string GangAllreadyExist = "Aynı isimli bir çete zaten mevcut!!";
        public const string PlayerIsNotInGangMember = "Oyuncu çete çete üye değil!!";
        public const string PlayerNotHavePermission = "Oyuncu gerekli yetkiye sahip değil!!";
        public const string GangShortNameTaken = "Bu kısaltma başka bir çeteyi temsil ediyor!!";
        public const string ItemBuyedButNotUsed = "Item envantere aktarıldı!";
        public const string BeforeUpgradeThis = "Önce şu binayı yükseltmelisin!";
        public const string BuildingAllreadyExist = "Bina zaten aktif olduğundan işleminiz gerçekleşmedi!";
        public const string WaveRewardAllreadyReceived = "Bu wave ödülleri zaten alınmış!!";
        public const string NoReward = "Ödül yok!";
        public const string WrongCoordinate = "Hatalı koordinat!!";
        public const string GangInviteTimeout = "Davet artık geçersiz!!";
        public const string TargetHasCityShield = "Saldırmak istediğiniz kullanıcının kalkanı var. Saldıramazsınız!!";
    }
}