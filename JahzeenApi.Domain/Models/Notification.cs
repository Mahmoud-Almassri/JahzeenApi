using JahzeenApi.Domain.Models.Common;

namespace JahzeenApi.Domain.Models
{
    public partial class Notification : BaseModel
    {
        public string NotificationTitle { get; set; }
        public string NotificationBody { get; set; }
        public string NotificationType { get; set; }
        public string IsOpened { get; set; }
        public long? ApplicationUserId { get; set; }
    }
}
