using Core.DataAccess.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        IRoleRepository Roles { get; }

        INotifyEventRepository NotifyEvents { get; }

        ISmsOperationResultRepository SmsOperationResults { get; }

        INotificationRepository Notifications { get; }

        IUserActivationRepository UserActivations { get; }

        IUserRestoreRepository UserRestores { get; }

        ITranslationRepository Translations { get; }

        IAnnouncementRepository Announcements { get; }

        IAnnouncementPhotoRepository AnnouncementPhotos { get; }

        IAnnouncementVideoRepository AnnouncementVideos { get; }

        INavbarComponentRepository NavbarComponents { get; }

        IPageSettingRepository PageSetting { get; }

        IPhonePrefixRepository PhonePrefixes { get; }

        Task CommitAsync();
    }
}
