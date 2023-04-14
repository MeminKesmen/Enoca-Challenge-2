using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.Constans
{
    public static class Message
    {
        
        //Create
        public readonly static string CarrierCreatedIsFailed = "Kargo firması oluşturulamadı!";
        public readonly static string CarrierConfigurationCreatedIsFailed = "Kargo firma ayarları oluşturulamadı!";
        public readonly static string OrderCreatedIsFailed = "Sipariş oluşturulamadı!";

        public readonly static string CarrierCreatedIsSuccess = "Kargo firması oluşturuldu!";
        public readonly static string CarrierConfigurationCreatedIsSuccess = "Kargo firma ayarları oluşturuldu!";
        public readonly static string OrderCreatedIsSuccess = "Sipariş oluşturuldu!";
      
        //Update
        public readonly static string CarrierUpdatedIsFailed = "Kargo firması güncellenemedi!";
        public readonly static string CarrierConfigurationUpdatedIsFailed = "Kargo firma ayarları güncellenemedi!";
        public readonly static string OrderUpdatedIsFailed = "Sipariş güncellenemedi!";

        public readonly static string CarrierUpdatedIsSuccess = "Kargo firması güncellendi!";
        public readonly static string CarrierConfigurationUpdatedIsSuccess = "Kargo firma ayarları güncellendi!";
        public readonly static string OrderUpdatedIsSuccess = "Sipariş güncellendi!";
       
        //Delete
        public readonly static string CarrierDeletedIsFailed = "Kargo firması silinemedi!";
        public readonly static string CarrierConfigurationDeletedIsFailed = "Kargo firma ayarları silinemedi!";
        public readonly static string OrderDeletedIsFailed = "Sipariş silinemedi!";

        public readonly static string CarrierDeletedIsSuccess = "Kargo firması silindi!";
        public readonly static string CarrierConfigurationDeletedIsSuccess = "Kargo firma ayarları silindi!";
        public readonly static string OrderDeletedIsSuccess = "Sipariş silindi!";

        //Get
        public readonly static string CarrierNotFound = "Kargo firması/firmaları bulunamadı!";
        public readonly static string CarrierConfigurationNotFound = "Kargo firma ayarları bulunamadı!";
        public readonly static string OrderNotFound = "Sipariş/siparişler bulunamadı!";

        public readonly static string CarrierFound = "Kargo firması/firmaları getirildi !";
        public readonly static string CarrierConfigurationFound = "Kargo firma ayarları getirildi!";
        public readonly static string OrderFound = "Sipariş/siparişler getirildi!";

        
    }
}
